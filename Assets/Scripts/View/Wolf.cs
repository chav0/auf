using System;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private static readonly int Change = Animator.StringToHash("Change");
    private static readonly int Angry = Animator.StringToHash("Angry");
    private static readonly int Happy = Animator.StringToHash("Happy");
    private static readonly int Neutral = Animator.StringToHash("Neutral");
    private static readonly int Workout = Animator.StringToHash("Workout");
    
    [SerializeField] private WolfBodyStateObject[] bodyStates; 
    public AudioSource sound;
    public Animator animator;
    public AudioSource changeSound;
    public Animator changeAnimator;
    
    private WolfBodyState _state;

    public void Set(WolfFaceState faceState, WolfBodyState bodyState, AudioClip clip)
    {
        if (_state != bodyState)
        {
            foreach (var state in bodyStates)
            {
                state.gameObject.SetActive(state.state == bodyState);
            }
            
            changeAnimator.SetTrigger(Change);
            changeSound.Play();
            _state = bodyState; 
        }

        sound.clip = clip; 
        sound.Play();

        switch (faceState)
        {
            case WolfFaceState.Happy:
                animator.SetTrigger(Happy); 
                break;
            case WolfFaceState.Neutral:
                animator.SetTrigger(Neutral); 
                break;
            case WolfFaceState.Angry:
                animator.SetTrigger(Angry); 
                break;
            case WolfFaceState.Workout:
                animator.SetTrigger(Workout); 
                break;
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
    Workout
}

public enum WolfBodyState
{
    None,
    Auf,
    Sit, 
    Fly,
    Call,
    Beer,
    Talk
}