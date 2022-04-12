using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Platform Data", menuName = "Generator/PlatformData")]
public class PlatformGeneratorData : ScriptableObject
{
    public BlockMovement blockPrefab;
    public float startY;
    public float yInterval;

    public const float minX = -2.3f;
    public const float xInterval = 0.46f;
}
