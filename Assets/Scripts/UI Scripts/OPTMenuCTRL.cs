using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class OPTMenuCTRL : MonoBehaviour
{

    public GameObject menuPanel;
    public AudioMixer mixer;


    public void BackMenu()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
	
    public void SetMusicVol(float vol)
    {
        mixer.SetFloat("MusicVol", vol);
    }


    public void SetSFXVol(float vol)
    {
        mixer.SetFloat("SFXVol", vol);
    }

}
