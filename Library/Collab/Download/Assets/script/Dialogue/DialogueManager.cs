using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public PlayableDirector _currentDirector;
    public bool _sceneSkipped = true;
    private TimelineAsset timelineAsset;
    private GroupTrack dialogGroupTrack;
    private IEnumerable<TrackAsset> track;
    private IMarker[] markers;
    public int nextDialog = 0;
    public  int MarkerCount;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue (Dialogue dialogue) 
    {
        timelineAsset = _currentDirector.playableAsset as TimelineAsset;
        dialogGroupTrack = timelineAsset.GetRootTrack(2) as GroupTrack;
        track = dialogGroupTrack.GetChildTracks();
        foreach (TrackAsset t in track)
        {
            if (t is DialogTrack)
            {
                markers = t.GetMarkers().ToArray();
                    MarkerCount = markers.Count();
            }
        }
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        StartTimeline();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        nextDialog += 1;
        if (nextDialog < MarkerCount)
        {
            _currentDirector.time = markers[nextDialog].time - 0.25;
        }
        animator.SetBool("IsOpen", false);
        _sceneSkipped = true;
    }
    public void StartTimeline()
    {
        _currentDirector.time = _currentDirector.time;
        _currentDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
    public void StopTimeline()
    {
        _currentDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

}
