using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventHandler
{
    public Event Event { get; private set; }
    public bool Ends => true; 
    
    public EventHandler(Event gameEvent)
    {
        Event = gameEvent;
    }

    public void Start(Widget widget)
    {
        
    }

    public void Handle(Data data, Widget widget)
    {
        
    }
}

[Serializable]
public class Event
{
    public string name; 
    public Condition condition;
    public List<Event> events;
    public AudioClip music;
    public string animation;
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