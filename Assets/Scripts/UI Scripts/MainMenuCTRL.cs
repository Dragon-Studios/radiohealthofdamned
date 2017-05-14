using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuCTRL : MonoBehaviour
{

    public GameObject optPanel;
    public GameObject difficultyPanel;

    public void PlayAction()
    {
        difficultyPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OptAction()
    {
        optPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitAction()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
