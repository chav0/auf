using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Step
{
    public StepType type; 
    public string text; 
    public WolfFaceState face;
    public WolfBodyState body;

}

public enum StepType
{
    RainbowText,
    NormalText,
    AngryText,
    OneAnswer,
    TwoAnswers, 
    InputField,
    Image,
    URL
}
