using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Script script;
    [SerializeField] private Wolf wolf;
    [SerializeField] private Widget widget; 
    [SerializeField] private Environment environment;
    [SerializeField] private AudioSource music;

    private Data _data;
    private EventHandler _currentEventHandler; 
    
    private void Start()
    {
        _data = Data.Get();

        var completed = new StringBuilder();
        foreach (var e in _data.CompletedEvents)
        {
            completed.Append($"{e},"); 
        }
        
        Debug.Log($"Completed events {completed}");
        
        var hour = _data.CurrentTime.Hour;
        Debug.Log($"Now {hour} hours");
        environment.Set(hour > 8 && hour < 21 ? EnvironmentState.Day : EnvironmentState.Night); 
    }

    private void Update()
    {
        if (!widget.main.IsLoaded)
            return;
        
        if (_currentEventHandler == null || _currentEventHandler.Ends)
        {
            if (_currentEventHandler != null)
            {
                _data.CompletedEvents.Add(_currentEventHandler.Event.name);
                Data.Save(_data);
                Debug.Log($"End event {_currentEventHandler.Event.name}");
            }
            
            _currentEventHandler = FindEvent();
            _currentEventHandler?.Start(_data, widget, music, environment);
        }

        _currentEventHandler?.Handle(_data, widget, wolf);
        widget.ResetButtons();
    }

    private EventHandler FindEvent()
    {
        foreach (var gameEvent in script.Events)
        {
            if (gameEvent.Fits(_data))
            {
                Debug.Log($"Start new event {gameEvent.name}");
                return new EventHandler(gameEvent, _data, widget, wolf);
            } 
        }

        return null; 
    }
}