using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeHandler : MonoBehaviour 
{
	void Start ()
    {
        GameObject obj = GameObject.Find("EffectSlider");
        obj.GetComponent<UnityEngine.UI.Slider>().onValueChanged.AddListener(SetVolume);
        SetVolume(obj.GetComponent<UnityEngine.UI.Slider>().value);
    }

    void OnDestroy()
    {
        GameObject obj = GameObject.Find("EffectSlider");
        if(obj != null)
        {
            obj.GetComponent<UnityEngine.UI.Slider>().onValueChanged.RemoveListener(SetVolume);
        }
    }

    void SetVolume (float volume)
    {
        GetComponent<AudioSource>().volume = volume;
	}
}
