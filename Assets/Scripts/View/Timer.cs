using DG.Tweening;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private float _timer; 
    private Sequence _sequence;

    public bool TimerIsOver => _timer <= 0; 

    public void SetTimer(float timer)
    {
        _timer = timer; 
        
        _sequence?.Kill();
        _sequence = null;

        _sequence = DOTween.Sequence()
            .AppendCallback(() =>
            {
                _timer -= 1;
                text.text = $"00:{_timer:N2}";
            })
            .AppendInterval(1)
            .SetLoops((int) _timer); 
    }
}