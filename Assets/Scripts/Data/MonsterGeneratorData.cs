using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generating
{

    [CreateAssetMenu(fileName = "Monster Data", menuName = "Generator/Monster Data")]
    public class MonsterGeneratorData : ScriptableObject
    {
        public Monster monsterPrefab;
        public float yPos;
    }
}