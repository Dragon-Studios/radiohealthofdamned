using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DifficultyCTRL : MonoBehaviour
{

    public GameObject menuPanel;    

    public void EasyMode()
    {
        SceneManager.LoadScene("Scene"); //cena1 = scene do jogo
    }

    public void MediumMode()
    {
        SceneManager.LoadScene("Scene"); //cena1 = scene do jogo
    }

    public void HardMode()
    {
        SceneManager.LoadScene("Scene"); //cena1 = scene do jogo
    }

    public void BackMenu()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

}
