using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Data
{
    private static readonly string DataKey = "player_data";
    
    public List<string> CompletedEvents;
    public bool IsWoman;
    public string Name;
    public string WolfName;
    public float Relationship;
    
    public DateTime CurrentTime => DateTime.Now;

    public static void Save(Data data)
    {
        var serialized = JsonConvert.SerializeObject(data); 
        PlayerPrefs.SetString(DataKey, serialized);
    }

    public static Data Get()
    {
        var serialized = PlayerPrefs.GetString(DataKey);
        return !string.IsNullOrEmpty(serialized) ? 
            JsonConvert.DeserializeObject<Data>(serialized) : 
            new Data {CompletedEvents = new List<string>()};
    }
}