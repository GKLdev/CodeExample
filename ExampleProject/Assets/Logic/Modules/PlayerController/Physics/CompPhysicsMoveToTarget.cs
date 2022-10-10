using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompPhysicsMoveToTarget
    {
        // *****************************
        // ProcessMoveToTarget
        // *****************************
        public static void ProcessMoveToTarget(StatePlayerController _state)
        {
            // skip if not needed //
            bool wantMove = _state.dynamicData.needMoveToDestination;
            if (!wantMove)
            {
                return;
            }

            Vector3 direction               = _state.dynamicData.currentDirection;
            float   blendTime               = _state.dynamicData.config.p_blendToDestinationTime;
            float   velocityRate            = Mathf.Approximately(blendTime, 0f) ? _state.dynamicData.config.p_floatMaxValue : 1f / blendTime;
            float   deltaTime               = velocityRate * Time.deltaTime;
            float   translationPerFrame     = (direction).magnitude * deltaTime;
            float   cdtRadius               = _state.plrCollider.radius;

            bool stepResolveMode = _state.dynamicData.config.p_stepResovleMovement;
            if (stepResolveMode)
            {
                StepResolvedMovement(_state, direction, translationPerFrame, cdtRadius);
                return;
            }

            SimpleMovement(_state, direction, translationPerFrame, cdtRadius);
        }

        // *****************************
        // SimpleMovement
        // *****************************
        static void SimpleMovement(StatePlayerController _state, Vector3 _direction, float _translationPerFrame, float _cdtRadius)
        {
            Vector3 virtualPosition = _state.root.position;
            bool movementFinished = TryMove(_state, _direction, _translationPerFrame, _cdtRadius, ref virtualPosition);
            if (movementFinished)
            {
                ApplyPosAndFinish(_state, virtualPosition);
            }

            _state.root.position = virtualPosition;
        }

        // *****************************
        // StepResolvedMovement
        // *****************************
        static void StepResolvedMovement(StatePlayerController _state, Vector3 _direction, float _translationPerFrame, float _cdtRadius)
        {
            // this  resolves frame movement by small steps defined at configs
            // this is needed to avoid passing through collision at high speeds or low FPS
            // each step method checks if collision happened
            // and finish movement of collided
            // also checks interaction with triggers

            Vector3 virtualPosition         = _state.root.position;
            float   resolveStep             = _state.dynamicData.config.p_movementResolveStep;
            int     resolveStepsCount       = (int)(_translationPerFrame / resolveStep);
            float   translationRemainder    = _translationPerFrame % resolveStep;
            bool    movementFinished        = false;

            // resolve step movement //
            for (int i = 0; i < resolveStepsCount; i++)
            {
                movementFinished = TryMove(_state, _direction, resolveStep, _cdtRadius, ref virtualPosition);
                if (movementFinished)
                {
                    ApplyPosAndFinish(_state, virtualPosition);
                    return;
                }
            }

            movementFinished = TryMove(_state, _direction, translationRemainder, _cdtRadius, ref virtualPosition);
            if (movementFinished)
            {
                ApplyPosAndFinish(_state, virtualPosition);
                return;
            }

            // apply virtual pos //
            _state.root.position = virtualPosition;
        }

        // *****************************
        // TryMove
        // *****************************
        /// <summary>
        /// returns true if movement was completed
        /// </summary>
        static bool TryMove(StatePlayerController _state, Vector3 _direction, float _distance, float _radius, ref Vector3 _virtualPosition)
        {
            Vector3 desiredVirtualPos = _virtualPosition + _direction.normalized * _distance;
            bool    collisionHappened = CompCollision.CheckCollision(_state, desiredVirtualPos, _radius);

            // stop on collision //
            if (collisionHappened)
            {
                // here we are using last safe virtual pos(where there is no collsions) for both trigger and position
                CompCollision.CheckTriggers(_state, _virtualPosition, _radius);
                return true;
            }

            // stop on travel completion //
            bool reachedOrPassedDestination = CheckIfReachedOrPassedDestination(_state.dynamicData.destinationPoint, _direction.normalized, desiredVirtualPos);
            if (reachedOrPassedDestination)
            {
                // here we are using destination pos for both trigger and position
                CompCollision.CheckTriggers(_state, _state.dynamicData.destinationPoint, _radius);
                _virtualPosition = _state.dynamicData.destinationPoint;
                return true;
            }

            // apply desired to current virtual pos //
            CompCollision.CheckTriggers(_state, desiredVirtualPos, _radius);
            _virtualPosition = desiredVirtualPos;

            return false;
        }

        // *****************************
        // ApplyPosAndFinish
        // *****************************
        static void ApplyPosAndFinish(StatePlayerController _state, Vector3 _pos)
        {
            _state.root.position = _pos;
            FinishMovement(_state);
        }

        // *****************************
        // FinishMovement
        // *****************************
        static void FinishMovement(StatePlayerController _state)
        {
            _state.dynamicData.needMoveToDestination = false;
        }

        // *****************************
        // CheckIfReachedOrPassedDestination
        // *****************************
        static bool CheckIfReachedOrPassedDestination(Vector3 _destination, Vector3 _direction, Vector3 _currPos)
        {
            float dot = Vector3.Dot(_direction.normalized, (_destination - _currPos).normalized);

            bool    passedDestinationPoint  = dot < 0f && !Mathf.Approximately(dot, 0f);
            float   dist                    = (_destination - _currPos).magnitude;
            bool    atDestinationPoint      = Mathf.Approximately(dist, 0f);

            bool result = passedDestinationPoint || atDestinationPoint;
            return result;
        }

    }
}