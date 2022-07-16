using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextWidget : MonoBehaviour
{
    [SerializeField] private TMP_Text textWidget; 
    
    private string _text; 
    private int _symbols; 
    private Sequence _sequence; 
    
    public void SetText(string text)
    {
        _text = text;
        _symbols = 0; 
        
        _sequence?.Kill();
        _sequence = null;

        _sequence = DOTween.Sequence()
            .AppendCallback(() =>
            {
                _symbols++; 
                textWidget.text = _text.Substring(0, _symbols);
            })
            .AppendInterval(0.05f)
            .SetLoops(_text.Length);
    }
}
