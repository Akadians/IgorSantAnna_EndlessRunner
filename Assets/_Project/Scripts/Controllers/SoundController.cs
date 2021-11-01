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
            GameController.instance.OnGamePause += PausedMusic;
            GameController.instance.OnGameUnpause += PausedMusic;
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

    public void DeadSound()
    {
        _audioSourceMusic.Stop();
        _audioSourceEffects.PlayOneShot(_AudioEffect[0]);
        _audioSourceEffects.PlayDelayed(1f);
    }

    public void PickSound()
    {
        _audioSourceEffects.PlayOneShot(_AudioEffect[1]);
    }

    private void PausedMusic()
    {
        if(Time.timeScale == 1)
        {
            _audioSourceMusic.Pause();
            _audioSourceEffects.Play();
        }
        else if(Time.timeScale == 0)
        {
            _audioSourceEffects.Stop();
            _audioSourceMusic.UnPause();
        }
    }

    private void OnDisable()
    {
        if (!_inTitle)
        {
            GameController.instance.OnGamePause -= PausedMusic;
            GameController.instance.OnGameUnpause -= PausedMusic;
        }
    }
}
