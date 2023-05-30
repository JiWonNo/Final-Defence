using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeContrl : MonoBehaviour
{
    public AudioSource bgmAudio;

    public GameObject effect;

    public GameObject SettingPannel;

    public void BgmMute()
    {
        bgmAudio.mute = true;
    }

    public void BgmStart()
    {
        bgmAudio.mute = false;
    }

   public void SettingStart()
    {
        SettingPannel.SetActive(true);
    }

    public void SettingExit()
    {
        SettingPannel.SetActive(false);
    }

    public void EffectSoundOn()
    {
        effect.SetActive(true);
    }

    public void EffectSoundOff()
    {
        effect.SetActive(false);
    }
}

