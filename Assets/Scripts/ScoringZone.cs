using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();

        if (ball == null) return;
        
        _audioManager.Play("Goal");
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        scoreTrigger.Invoke(eventData);
    }
}
