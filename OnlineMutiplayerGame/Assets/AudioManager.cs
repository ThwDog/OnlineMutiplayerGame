using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------------- Audio Source -----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------- Audio Clip -----------------")]
    //public AudioClip blackground;
    public AudioClip jump;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
