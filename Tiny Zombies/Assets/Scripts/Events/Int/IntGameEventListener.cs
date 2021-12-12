using UnityEngine;
using UnityEngine.Events;

public class IntGameEventListener : MonoBehaviour
{
    [SerializeField] private IntGameEvent _event;
    [SerializeField] private UnityEvent<int> Response;

    private void RespondEvent(int value)
    {
        if(Response != null)
        {
            Response.Invoke(value);
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
