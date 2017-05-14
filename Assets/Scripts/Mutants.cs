using UnityEngine;
using System.Collections;

public class Mutants : MonoBehaviour {

    [SerializeField]
    private Player playerInfo;
    public Transform player;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    public int angulo_visao_mutant = 30;
    public int distancia_visao_inimigo = 15;
    public int vida;
    public int dano;
    private bool dead = false;
    private bool isAttack = false;

    private float vol = 0.2f;
    [SerializeField]
    private float runTimeLeft = 5.0f;
    private float lastSoundTime = 0;

    private AudioSource source;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public AudioClip damageSound;
    public AudioClip runSound;

    GameObject objItem;
    [SerializeField]
    GameObject prefabCura;
    [SerializeField]
    GameObject prefabMunicao;
    private int drop = 0;

    public void TakeDamage(int damagePlayer)
    {
        vida -= damagePlayer;
        if (vida <= 0)
        {
            if ( drop < 1) {
                dropItem();
            }
            
            dead = true;
            GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
            //GetComponent<BoxCollider>().enabled = false;
            agent.enabled = false;
            anim.SetBool("isDead", true);
            source.PlayOneShot(deathSound, vol);
        }
        else {
            source.PlayOneShot(damageSound, vol);
        }
    }

    void dropItem() {

        if ( !GetComponent<Collider>().CompareTag("Boss") ) {
            int randomValue = Random.Range(0, 3);

            if (randomValue == 0)
            {
                objItem = Instantiate(prefabCura, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
            }
            else if (randomValue == 1)
            {
                objItem = Instantiate(prefabMunicao, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
            }
            else
            {

            }
            drop += 1;
        }
        
    }

    void setAttack()
    {
        isAttack = !isAttack;
    }

    public bool getAttack()
    {
        return isAttack;
    }

    void Start() {
        anim = GetComponent<Animator>();
        player = GameObject.Find("FPSController").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!playerInfo.isDead) {

            if (vida <= 0)
            {
                if(GetComponent<Collider>().CompareTag("Boss")){
                    Destroy(gameObject);
                }
                else {
                    Destroy(gameObject, 3f);

                }
                return;
            }

            if(dead == false){

                Vector3 direction = player.position - this.transform.position;
                float angle = Vector3.Angle(direction, this.transform.forward);
                if (Vector3.Distance(player.position, this.transform.position) < distancia_visao_inimigo && angle < angulo_visao_mutant)
                {

                    if (!getAttack())
                    {
                        agent.destination = player.position;
                    }

                    anim.SetBool("isIdle", true);
                    if (direction.magnitude > agent.stoppingDistance)
                    {
                        if (Time.time  >= lastSoundTime + runTimeLeft)
                        {
                            source.PlayOneShot(runSound, vol);
                            lastSoundTime = Time.time;
                        }

                        anim.SetBool("isRuning", true);
                        anim.SetBool("isAttacking", false);

                    }
                    else
                    {
                        anim.SetBool("isRuning", false);
                        anim.SetBool("isAttacking", true);
                        if (Time.time >= lastSoundTime + runTimeLeft)
                        {
                            source.PlayOneShot(attackSound, vol);
                            lastSoundTime = Time.time;
                        }
                    

                    }


                }
                else {

                    anim.SetBool("isIdle", true);
                    anim.SetBool("isRuning", false);
                    anim.SetBool("isAttacking", false);

                }

                }
            }
    }


}
