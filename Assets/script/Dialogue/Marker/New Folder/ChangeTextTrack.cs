using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackBindingType(typeof(ChangeTextReceiver))]
[TrackColor(255f / 255f, 140f / 255f, 0f / 255f)]
public class ChangeTextTrack : MarkerTrack{}