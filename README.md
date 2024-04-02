# Custom Event System/Observer Design Pattern

Observer is a behavioral design pattern that allows some objects to notify other objects about changes in their state.




## Usage/Examples

```cs
public static class EventManager 
{
    private static Dictionary <string, Action> _eventDictionary = new Dictionary <string, Action>();

    public static void Register(string eventType, Action eventHandler) 
    {
        if (!_eventDictionary.ContainsKey(eventType)) 
        {
            _eventDictionary[eventType] = eventHandler;
        } 
        else 
        {
            _eventDictionary[eventType] += eventHandler;
        }
    }

    public static void Unregister(string eventType, Action eventHandler) 
    {
        if (_eventDictionary.ContainsKey(eventType)) 
        {
            _eventDictionary[eventType] -= eventHandler;
        }
    }

    public static void Execute(string eventType) 
    {
        if (_eventDictionary.ContainsKey(eventType)) 
        {
            _eventDictionary[eventType]?.Invoke();
        }
    }
}
```

## Events Definition
```cs
public static class EventKeys 
{     
    // List of events goes here . .
    public static readonly string GAME_STATE_CHANGED = "EventKeys.GameStateChanged";
    public static readonly string SCORE_UPDATED = "EventKeys.ScoreUpdated";    
    // .
    // .etc
}
```

## Subject
```cs
public class Subject: MonoBehaviour 
{
    private int _score = 0;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _score += 10;
            EventManager<float>.Execute(EventKeys.SCORE_UPDATED, _score);
        }
    }
}
```

## Observer
```cs
public class Observer: MonoBehaviour 
{
    private void Start() 
    {
        EventManager<float>.Register(EventKeys.SCORE_UPDATED, HandleScoreUpdated);
    }

    private void OnDestroy() 
    {
        EventManager<float>.Unregister(EventKeys.SCORE_UPDATED, HandleScoreUpdated);
    }

    private void HandleScoreUpdated(float score) 
    {
        Debug.Log($"Score is updated: {score}");
    }
}

```


## 🔗 References

https://gameprogrammingpatterns.com/observer.html

https://refactoring.guru/design-patterns/observer/csharp/example#example-0

