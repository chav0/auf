using System;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] private WolfBodyStateObject[] bodyStates; 
    public AudioSource sound;
    public Animator animator;

    public void Set(WolfFaceState faceState, WolfBodyState bodyState)
    {
        foreach (var state in bodyStates)
        {
            state.gameObject.SetActive(state.state == bodyState);
        }
    }
}

[Serializable]
public class WolfBodyStateObject 
{
    public WolfBodyState state;
    public GameObject gameObject; 
}

public enum WolfFaceState
{
    Happy,
    Neutral, 
    Angry,
    Speak,
    Scream,
}

public enum WolfBodyState
{
    Sit,
    Lay, 
    Jump,
    Workout
}