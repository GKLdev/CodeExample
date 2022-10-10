using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        var castResult = Physics.SphereCastAll(transform.position, GetComponent<Renderer>().bounds.size.x / 2, Vector3.up, 0);

        if (castResult.Length > 1)
            Game.Instance.OnWallHit();
    }
}
