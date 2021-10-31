using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    public AudioMixer mainMixer;    


    public void Initializations()
    {

    }
    
    private void Start()
    {
        Initializations();
    }

    
    void Update()
    {
        
    }

    public void SetVolumeMaster(float volume)
    {
        mainMixer.SetFloat("volumeMaster", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        mainMixer.SetFloat("volumeSFX", volume);
    }

    public void SetVolumeBGM(float volume)
    {
        mainMixer.SetFloat("volumeBGM", volume);
    }

}
