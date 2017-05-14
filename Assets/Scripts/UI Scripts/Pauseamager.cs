using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pauseamager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    public AudioMixer mixer;


    public void SetMusicVol(float vol)
    {
        mixer.SetFloat("MusicVol", vol);
    }


    public void SetSFXVol(float vol)
    {
        mixer.SetFloat("SFXVol", vol);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
	}

    public void Pause()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void QuitAction()
    {
        SceneManager.LoadScene("menu");
    }
}
