using UnityEngine;

public class EventHandler
{
    public Event Event { get; }
    public bool Ends { get; private set; }

    private int _currentStep; 
    private bool _previousFirst; 
    private bool _previousSecond; 
    
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
    }

    public void Handle(Data data, Widget widget, Wolf wolf)
    {
        if (Ends)
            return;

        if (widget.SetName)
        {
            data.Name = widget.Input;
            Data.Save(data); 
            _previousFirst = true; 
            _previousSecond = false;
        }

        if (widget.SetDefaultName)
        {
            data.Name = "БРАТ"; 
            Data.Save(data);
            _previousFirst = false;
            _previousSecond = true; 
        }

        if (widget.SetWolfName)
        {
            Debug.Log($"Set name {widget.Input}");
            data.WolfName = widget.Input; 
            Data.Save(data);
            _previousFirst = true;
            _previousSecond = false;
        }

        if (widget.First)
        {
            _previousFirst = true;
            _previousSecond = false;
        }

        if (widget.Second)
        {
            _previousFirst = false;
            _previousSecond = true; 
        }

        if (widget.TimerIsOver || widget.Next)
        {
            _previousFirst = false;
            _previousSecond = false; 
        }
        
        if (widget.TimerIsOver || 
            widget.Next || 
            widget.First || 
            widget.Second || 
            widget.SetName || 
            widget.SetDefaultName || 
            widget.SetWolfName)
        {
            Debug.Log($"Step end {_currentStep}");

            _currentStep++;
            while (Event.steps.Count > _currentStep && 
                   (Event.steps[_currentStep].previousFirst != _previousFirst || 
                    Event.steps[_currentStep].previousSecond != _previousSecond))
            {
                Debug.Log($"Step skipped {_currentStep}");
                _currentStep++; 
            }

            if (Event.steps.Count <= _currentStep)
            {
                Ends = true; 
                return;
            }

            SetStep(Event.steps[_currentStep], data, widget, wolf);
        }
        
        widget.ResetButtons();
    }

    private void SetStep(Step step, Data data, Widget widget, Wolf wolf)
    {
        Debug.Log($"[{data.WolfName}]: Step start {_currentStep}: {step.text}");
        widget.SetStep(step, data.WolfName);
        wolf.Set(step.face, step.body, step.clip);
    }
}