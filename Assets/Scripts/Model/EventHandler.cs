using UnityEngine;

public class EventHandler
{
    public Event Event { get; }
    public bool Ends { get; private set; }

    private int _currentStep; 
    
    public EventHandler(Event gameEvent, Data data, Widget widget, Wolf wolf)
    {
        Event = gameEvent;
        _currentStep = 0;

        if (gameEvent.steps.Count > 0)
        {
            SetStep(gameEvent.steps[0], data, widget, wolf);
        }
    }

    public void Start(Data data, Widget widget, AudioSource music, Environment environment)
    {
        if (Event.music != null)
        {
            music.clip = Event.music;
            music.loop = true;
            music.Play();
        }

        var hour = data.CurrentTime.Hour;
        environment.Set(hour > 8 && hour < 22 ? EnvironmentState.Day : EnvironmentState.Night); 
    }

    public void Handle(Data data, Widget widget, Wolf wolf)
    {
        if (Ends)
            return;
        
        if (widget.TimerIsOver)
        {
            Debug.Log($"Step end {_currentStep}");
            
            _currentStep++;

            if (Event.steps.Count <= _currentStep)
            {
                Ends = true; 
                return;
            }

            SetStep(Event.steps[_currentStep], data, widget, wolf);
        }
    }

    private void SetStep(Step step, Data data, Widget widget, Wolf wolf)
    {
        Debug.Log($"Step start {_currentStep}: {step.text}");
        widget.SetStep(step, data.WolfName);
        wolf.Set(step.face, step.body);
    }
}