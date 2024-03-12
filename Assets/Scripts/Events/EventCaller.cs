using UnityEngine;

public class EventCaller : MonoBehaviour
{
    public void CallEvent(GameEvent eventToCall)
    {
        eventToCall.Raise();
    }
}
