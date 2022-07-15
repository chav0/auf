using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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