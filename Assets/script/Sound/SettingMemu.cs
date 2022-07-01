using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMemu : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetVolume_BGM(float volume)
    {
        mixer.SetFloat("BGM",volume);
    }
    public void SetVolume_SFX(float volume)
    {
        mixer.SetFloat("SFX", volume);
    }
}
