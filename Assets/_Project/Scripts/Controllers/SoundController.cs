using UnityEngine;
using UnityEngine.Audio;
public sealed class SoundController : MonoBehaviour
{
    public AudioMixer mainMixer;

    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioClip[] _AudioEffect = new AudioClip[5];
    [SerializeField] private bool _inTitle = false;


    public void Initializations()
    {
        if (!_inTitle)
        {
            GameController.instance.OnGameOver += DeadSound;
        }
    }

    private void Start()
    {
        Initializations();
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

    private void DeadSound()
    {
        _audioSourceMusic.Stop();
        _audioSourceEffects.PlayOneShot(_AudioEffect[0]);

    }

    private void OnDisable()
    {
        if (!_inTitle)
        {
            GameController.instance.OnGameOver -= DeadSound;
        }
    }
}
