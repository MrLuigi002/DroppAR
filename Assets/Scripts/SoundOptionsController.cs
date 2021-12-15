using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptionsController : MonoBehaviour
{
    int musicOff = 0;
    int vfxOff = 0;

    [SerializeField] private Image musicButtonImage;
    [SerializeField] private Image vfxButtonImage;

    [SerializeField] private Sprite[] buttonSprite;

    private void OnEnable()
    {
        CheckState();
    }

    public void MusicButton()
    {
        if(musicOff == 0)
        {
            musicOff = 1;
        }

        else
        {
            musicOff = 0;
        }

        PlayerPrefs.SetInt("musicOff", musicOff);

        CheckState();
    }

    public void VFXButton()
    {
        if(vfxOff == 0)
        {
            vfxOff = 1;
        }

        else
        {
            vfxOff = 0;
        }

        PlayerPrefs.SetInt("vfxOff", vfxOff);

        CheckState();
    }

    void CheckState()
    {
        musicOff = PlayerPrefs.GetInt("musicOff");
        vfxOff = PlayerPrefs.GetInt("vfxOff");

        musicButtonImage.sprite = buttonSprite[musicOff];
        vfxButtonImage.sprite = buttonSprite[vfxOff];
    }
}
