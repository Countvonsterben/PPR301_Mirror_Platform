using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioSource SFXSource;
    [Header("Audio Clips")]
    public AudioClip checkpoint; //if we want visible audio cue the player did a puzzle
    public AudioClip background;
    public AudioClip levelComplete; //?

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        //SFXSource.PlayOneShot(clip);
    }
}
