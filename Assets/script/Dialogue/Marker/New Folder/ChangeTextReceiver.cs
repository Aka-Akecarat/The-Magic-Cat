using UnityEngine;
using UnityEngine.Playables;

public class ChangeTextReceiver : MonoBehaviour, INotificationReceiver
{
    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if(notification is DialogMaker dialogMaker)
        {
            dialogMaker.TriggerDialogue();
        }
    }

}
