using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    LevelView _currentLevelView;

    private void Awake()
    {
        Events.OnLevelInitialized.Register(OnLevelInitialized);
    }

    private void OnDestroy()
    {
        Events.OnLevelInitialized.Unregister(OnLevelInitialized);
    }
    void OnLevelInitialized(LevelData levelData)
    {
        if (_currentLevelView != null) Destroy(_currentLevelView.gameObject);
        _currentLevelView = Instantiate(levelData.levelPrefab);
    }
}
