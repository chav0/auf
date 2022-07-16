using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas; 
    [SerializeField] private Button start; 
    
    public bool IsLoaded { get; private set; }

    private void Start()
    {
        DOTween.Sequence()
            .AppendInterval(2)
            .Append(canvas.DOFade(0, 1f))
            .Play(); 
        
        start.onClick.AddListener(() =>
        {
            IsLoaded = true;
            gameObject.SetActive(false);
        });
    }
}
