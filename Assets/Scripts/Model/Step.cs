using System;

[Serializable]
public class Step
{
    public StepType type; 
    public string text; 
    public WolfFaceState face;
    public WolfBodyState body;
    public float timer;
    public string firstButton;
    public string secondButton; 
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
