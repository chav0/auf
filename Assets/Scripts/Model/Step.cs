using System;
using UnityEngine;

[Serializable]
public class Step
{
    public bool previousFirst;
    public bool previousSecond;
    public StepType type; 
    public string text; 
    public WolfFaceState face;
    public WolfBodyState body;
    public float timer;
    public string firstButton;
    public string secondButton; 
    public AudioClip clip; 
}

public enum StepType
{
    RainbowText,
    NormalText,
    AngryText,
    OneAnswer,
    TwoAnswers, 
    ChangeName,
    ChangeWolfName,
    Image,
    Video,
    Timer
}
