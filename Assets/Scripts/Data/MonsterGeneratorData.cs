using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Generator/Monster Data")]
public class MonsterGeneratorData : ScriptableObject
{
    public Monster monsterPrefab;
    public float yPos;
}
