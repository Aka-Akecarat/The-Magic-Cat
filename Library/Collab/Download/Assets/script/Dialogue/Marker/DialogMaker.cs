using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogMaker : Marker, INotification, INotificationOptionProvider
{
    public Dialogue dialogue;
    [SerializeField] private bool retroactive = false;
    [SerializeField] private bool emitOnce = false;
    [SerializeField] private bool Wait = false;
    [SerializeField] private bool pause = false;
    public PropertyName id => new PropertyName();
    public NotificationFlags flags =>
        (retroactive ? NotificationFlags.Retroactive : default) |
        (emitOnce ? NotificationFlags.TriggerOnce : default);

    public void TriggerDialogue()
    {
        if (pause == true && Wait == false)
        {
            FindObjectOfType<DialogueManager>().StopTimeline();
        }

        else if (Wait == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else if (Wait == true)
        {
            FindObjectOfType<DialogueManager>().nextDialog += 1;
        }
    }
    /*
    public void TriggerDialogue(DialogMaker.Wait)
    {
        switch (Wait, pause)
        {
            case (false, true):
                {
                    FindObjectOfType<DialogueManager>().StopTimeline();
                    break;
                }
            case (true, false):
                {
                    FindObjectOfType<DialogueManager>().nextDialog += 1;
                    break;
                }
            default:
                {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    break;

                }
        }
    }
    */
}
        

    
