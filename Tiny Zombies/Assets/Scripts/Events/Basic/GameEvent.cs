using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Events/Event", fileName = "New Event")]
public class GameEvent : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void Raise()
    {
        if(OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }
    }
}
