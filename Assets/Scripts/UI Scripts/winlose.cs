using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class winlose : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    public AudioMixer mixer;

    public void QuitAction()
    {
        SceneManager.LoadScene("menu");
    }
}
