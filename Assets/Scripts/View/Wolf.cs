using UnityEngine;

public class Wolf : MonoBehaviour
{

    public AudioSource sound;
    public Animator animator;

    public void Set(WolfFaceState faceState, WolfBodyState bodyState)
    {
        
    }
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
}