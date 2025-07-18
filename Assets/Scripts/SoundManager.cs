using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] _footstepsSFX;
    [SerializeField] private AudioClip[] _hitSFX;
    [SerializeField] private AudioClip[] _dumpSFX;
    private AudioSource _audioSource;

    public static SoundManager Instance;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if(SoundManager.Instance == null )
        {
            SoundManager.Instance = this;
        }
    }



    public void PlayAudio(string audioToPlay)
    {
        if(audioToPlay == "Hit")
        {
            _audioSource.PlayOneShot(_hitSFX[Random.Range(0, _hitSFX.Length)]);
            Debug.Log("HIT AUDIO");
        }
        else if(audioToPlay == "Dump")
        {
            _audioSource.PlayOneShot(_dumpSFX[Random.Range(0, _dumpSFX.Length)]);
            Debug.Log("DUMP AUDIO");
        }
        else if (audioToPlay == "Footstep")
        {
            _audioSource.PlayOneShot(_footstepsSFX[Random.Range(0, _footstepsSFX.Length)]);
            Debug.Log("FOOTSTEP AUDIO");
        }

    }


}
