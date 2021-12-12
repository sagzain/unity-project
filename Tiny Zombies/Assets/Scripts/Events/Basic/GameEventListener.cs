using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private UnityEvent Response;

    private void RespondEvent()
    {
        if(Response != null)
        {
            Response.Invoke();
        }
    }

    void OnEnable()
    {
        if(_event != null)
        {
            _event.OnEventRaised += RespondEvent;
        }
    }

    void OnDisable()
    {
        if(_event != null)
        {
            _event.OnEventRaised -= RespondEvent;
        }
    }
}
