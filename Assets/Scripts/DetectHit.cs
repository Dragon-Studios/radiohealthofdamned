using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectHit : MonoBehaviour {

    public int playerDamage = 10;
    public int life = 100;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot"))
        {
            Debug.Log("HIT " + playerDamage);
            life -= playerDamage;
            if (life <= 0)
            {
                anim.SetBool("isDead", true);
            }
        }

        /*if (other.CompareTag("Boss"))
        {
            life -= 50;
        }
        else if (other.CompareTag("Enemy1"))
        {
            life -= 10;
        }
        else if (other.CompareTag("Enemy2"))
        {
            life -= 20;
        }
        else if (other.CompareTag("Enemy3"))
        {
            life -= 30;
        }
        Debug.Log("Dano recebido = " + life);


        if (life <= 0)
        {
            Debug.Log("MORREU");
        }

        GameObject.Find("LifeText").GetComponent<Text>().text = life.ToString();*/

    }
}
