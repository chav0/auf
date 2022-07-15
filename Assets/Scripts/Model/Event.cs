using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventHandler
{
    public Event Event { get; }
    public bool Ends => true; 
    
    public EventHandler(Event gameEvent)
    {
        Event = gameEvent;
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
        Debug.Log(hour);
        environment.Set(hour > 8 && hour < 22 ? EnvironmentState.Day : EnvironmentState.Night); 
    }

    public void Handle(Data data, Widget widget, Wolf wolf)
    {
        
    }
}

[Serializable]
public class Event
{
    public string name; 
    public Condition condition;
    public List<Step> steps;
    public AudioClip music;
    public bool completable;

    public bool Fits(Data data)
    {
        if (completable && data.CompletedEvents.Contains(name))
            return false;
        if (condition.isWoman != data.IsWoman)
            return false;
        if (condition.minRelationship > data.Relationship)
            return false;
        if (condition.maxRelationship < data.Relationship)
            return false;

        return condition.completedEvents.All(completedEvent => data.CompletedEvents.Contains(completedEvent));
    }
}