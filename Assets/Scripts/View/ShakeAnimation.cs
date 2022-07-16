using DG.Tweening;
using UnityEngine;

public class ShakeAnimation : MonoBehaviour
{
    public float shake; 
    private void OnEnable()
    {
        DOTween.Sequence()
            .Append(transform.DOShakePosition(5, new Vector3(shake, shake, 0), fadeOut:false)); 
    }
}
