using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] music;

    [SerializeField] private AudioClip startVFX;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        if(PlayerPrefs.GetInt("currentTrack") < music.Length - 1)
        {
            PlayerPrefs.SetInt("currentTrack", PlayerPrefs.GetInt("currentTrack") + 1);
        }

        else
        {
            PlayerPrefs.SetInt("currentTrack", 0);
        }

        //audioSource.PlayOneShot(music[PlayerPrefs.GetInt("currentTrack")]);
        audioSource.clip = music[PlayerPrefs.GetInt("currentTrack")];

        if(PlayerPrefs.GetInt("musicOff") == 0)
        {
            audioSource.Play();
        }      
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("vfxOff") == 0)
            audioSource.PlayOneShot(startVFX);
    }


}
