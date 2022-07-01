using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkipManager : MonoBehaviour
{
    private PlayableDirector _currentDirector;
    private bool _sceneSkipped = true;
    private float _timeToSkipTo;
    private SkipManager _instance;

    private void Awake()
    {
        _instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !_sceneSkipped)
        {
            _currentDirector.time = 8.0f;
            _sceneSkipped = true;
        }
    }
    public void GetDirector(PlayableDirector director)
    {
        _sceneSkipped = false;
        _currentDirector = director;
    }
    public void GetSkipTime(float skipTime)
    {
        _timeToSkipTo = skipTime;
    }
}
