using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Widget : MonoBehaviour
{
    [SerializeField] private WidgetStateObject[] states;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Button nextButton; 
    [SerializeField] private Button firstButton; 
    [SerializeField] private Button secondButton; 
    [SerializeField] private Button setNameButton; 
    [SerializeField] private Button setDefaultNameButton; 
    [SerializeField] private Button setWolfNameButton;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Timer timerWidget; 
    [SerializeField] private TMP_Text wolfNameWidget; 
    [SerializeField] private TMP_Text firstButtonText; 
    [SerializeField] private TMP_Text secondButtonText; 
    [SerializeField] private TMP_Text nextButtonText; 
    [SerializeField] private TextWidget wolfText; 
    [SerializeField] private TextWidget angryText; 
    [SerializeField] private TextWidget rainbowText; 
    
    public MainScreen main;
    
    public bool Next { get; private set; }
    public bool First { get; private set; }
    public bool Second { get; private set; }

    private string _input; 

    public string Input
    {
        get => _input;
        private set
        {
            Debug.Log(value);
            _input = value;
        }
    }

    public bool SetName { get; private set; }
    public bool SetDefaultName { get; private set; }
    public bool SetWolfName { get; private set; }

    public bool TimerIsOver => timerWidget.TimerIsOver; 

    private void OnEnable()
    {
        nextButton.onClick.AddListener(() => Next = true); 
        firstButton.onClick.AddListener(() => First = true); 
        secondButton.onClick.AddListener(() => Second = true); 
        setNameButton.onClick.AddListener(() => SetName = true); 
        setDefaultNameButton.onClick.AddListener(() => SetDefaultName = true); 
        setWolfNameButton.onClick.AddListener(() => SetWolfName = true); 
        input.onEndEdit.AddListener(value => Input = value);
        input.onValueChanged.AddListener(value => Input = value);
    }

    public void SetStep(Step step, string wolfName)
    {
        foreach (var state in states)
        {
            if (state.type != step.type) 
                continue;
            
            for (var i = 0; i < gameObjects.Length; i++) 
                gameObjects[i].SetActive(state.enabled[i]);
        }

        wolfNameWidget.text = string.IsNullOrEmpty(wolfName) ? "Сергей:" : $"{wolfName}:";
        timerWidget.SetTimer(step.timer);
        wolfText.SetText(step.text);
        angryText.SetText(step.text);
        rainbowText.SetText(step.text);
        firstButtonText.text = step.firstButton;
        nextButtonText.text = step.firstButton;
        secondButtonText.text = step.secondButton;
        input.text = string.Empty;
    }

    public void ResetButtons()
    {
        Next = false;
        First = false;
        Second = false;
        SetName = false;
        SetDefaultName = false; 
        SetWolfName = false; 
    }
}

[Serializable]
public class WidgetStateObject
{
    public StepType type;
    public bool[] enabled; 
}