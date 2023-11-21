using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalEventSystem
{
    [CreateAssetMenu(menuName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public int levelID;
        public LevelView levelPrefab;
    }
}