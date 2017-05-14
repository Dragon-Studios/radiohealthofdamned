using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    private bool started = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            started = true;
            Menu();
        }
    }

    public void Menu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
       // Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
