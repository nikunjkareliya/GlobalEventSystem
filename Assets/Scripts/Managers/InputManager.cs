using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameState _currentGameState;
    
    void Start()
    {
        
    }

    private void OnEnable() => Events.OnGameStateChanged.Register(OnGameStateChanged);

    private void OnDisable() => Events.OnGameStateChanged.Unregister(OnGameStateChanged);

    void OnGameStateChanged(GameState gameState)
    {
        _currentGameState = gameState;        
    }
    
    void Update()
    {
        if (_currentGameState != GameState.Gameplay) return;
        
        if (Input.GetMouseButtonDown(0))
        {            
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Events.OnMouseButtonClicked.Execute(worldPosition);            
        }

        var xVal = Input.GetAxis("Horizontal");
        var yVal = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(xVal, 0, yVal);
        Events.OnAxisValuesChanged.Execute(movementVector);            
    }
}
