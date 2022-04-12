using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Platform Data", menuName = "Generator/PlatformData")]
public class PlatformGeneratorData : ScriptableObject
{
    public BlockMovement blockPrefab;
    public float startY;
    public float yInterval;
}
