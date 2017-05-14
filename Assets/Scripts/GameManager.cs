using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Player playerInfo;

    [SerializeField]
    int dificuldade = 0;
    // configurações
    private int count_horda = 1;
    GameObject prefabMutantAux;
    private Transform transformAux;

    // enemies
    [SerializeField]
    GameObject prefabMutant1;
    [SerializeField]
    GameObject prefabMutant2;
    [SerializeField]
    GameObject prefabMutant3;
    [SerializeField]
    GameObject prefabBoss;

    public GameObject winCanvas;
    public GameObject loseCanvas;

    // respawns
    [SerializeField]
    private Transform spawnPoints;

    [SerializeField]
    List<GameObject> listEnemies;

    GameObject objMutant;

    void Awake()
    {
        /*
        if (dificuldade == 0)
        {
            playerInfo.life = 100;
            playerInfo.life = 50;
        }
        else if (dificuldade == 1)
        {
            playerInfo.life = 60;
            playerInfo.life = 20;
        }
        else if (dificuldade == 2)
        {
            playerInfo.life = 1;
            playerInfo.life = 10;
        }*/
    }
    
    void Start()
    {
    }
    
    void Update()
    {
        
        if( playerInfo.isDead ){
            loseCanvas.SetActive(true);
        }
        else if (IsWins())
        {
            winCanvas.SetActive(true);
        } else {
            int count_enemy_life = 0;
            foreach (var x in listEnemies)
            {
                if (x)
                    count_enemy_life += 1;
            }

            if (count_enemy_life == 0)
                HordaController();
                
        }
    }

    bool IsWins()
    {
        if (count_horda == 6)
            return true;
        return false;
    }

    void HordaController()
    {
        GameObject.Find("Message").GetComponent<Text>().text = "Horda " + count_horda;

        if (count_horda == 1)
        {
            prefabMutantAux = prefabMutant1;
        }
        else if (count_horda == 2)
        {
            prefabMutantAux = prefabMutant3;
        }
        else if (count_horda == 3)
        {
            prefabMutantAux = prefabMutant2;
        }
        else if (count_horda == 4)
        {
            prefabMutantAux = prefabBoss;
        }

        foreach (Transform trans in spawnPoints)
        {

            objMutant = Instantiate(prefabMutantAux, trans.position, Quaternion.identity) as GameObject;
            listEnemies.Add(objMutant);
            if (count_horda == 4) {
                break;
            }
        }
        count_horda += 1;
        
    }

}
