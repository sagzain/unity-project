using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Events/Int Event", fileName = "New Int Event")]
public class IntGameEvent : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void Raise(int value)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
