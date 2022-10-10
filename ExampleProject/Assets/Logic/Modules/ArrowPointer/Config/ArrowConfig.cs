using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowConfig", menuName = "ReferenceDb/Configs/ArrowConfig")]
public class ArrowConfig : DbEntryBase
{
    [SerializeField]
    float maxHeadScaleFactor = 1.5f;
    [SerializeField]
    float maxMainHorScaleFactor = 1f;
    [SerializeField]
    float minMainHorScaleFactor = 0.2f;
    [SerializeField]
    float minHeadScaleFactor = 0.2f;

    public float p_maxHeadScaleFactor       => maxHeadScaleFactor;
    public float p_maxMainHorScaleFactor    => maxMainHorScaleFactor;
    public float p_minMainHorScaleFactor    => minMainHorScaleFactor;
    public float p_minHeadScaleFactor       => minHeadScaleFactor;

}
