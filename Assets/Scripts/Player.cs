using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public int life = 100;
    public int damage = 50;
    public bool isDead = false;
    public GameObject loseCanvas;

    public int maximoDeBalaNnaArma = 7;
    public int MunicaoNaArma = 7;
    public int TotalDeMunicao = 100;
    public int cura = 50;
    public int municao = 50;

    public Rigidbody projectile;
    public Transform shotPos;

    private float vol = 0.2f;
    private AudioSource source;
    public AudioClip shootSound;
    public AudioClip deathSound;
    public AudioClip damageSound;
    public AudioClip noBulletSound;
    public AudioClip municaoSound;
    public AudioClip curaSound;
    public AudioClip reloadSound;

    // Use this for initialization
    void Start () {
        GameObject.Find("LifeText").GetComponent<Text>().text = life.ToString();
        source = GetComponent<AudioSource>();
        GameObject.Find("WeaponBulletText").GetComponent<Text>().text = MunicaoNaArma.ToString();
        GameObject.Find("TotalBulletText").GetComponent<Text>().text = TotalDeMunicao.ToString();
    }

    void SoundDead() {
        if ( life <= 0 && !isDead)
        {
            source.PlayOneShot(deathSound, vol);
            isDead = true;
        }
    }

    void setLife(int life) {
        if (life > 100)
        {
            this.life = 100;
        }
        else if (life < 0)
        {
            this.life = 0;
        }
        else
        {
            this.life = life;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (life <= 0)
        {
            isDead = true;
        }
        else {
            
            SoundDead();

            if (Input.GetButtonDown("Fire1"))
            {
                if (MunicaoNaArma > 0)
                {
                    MunicaoNaArma--;
                    GameObject.Find("WeaponBulletText").GetComponent<Text>().text = MunicaoNaArma.ToString();
                    Fire();

                }
                else
                {
                    source.PlayOneShot(noBulletSound, vol);
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (MunicaoNaArma < maximoDeBalaNnaArma)
                {
                    source.PlayOneShot(reloadSound, 7.0f);
                    int BalaQueFaltam = maximoDeBalaNnaArma - MunicaoNaArma;
                    if (BalaQueFaltam <= TotalDeMunicao)
                    {
                        MunicaoNaArma = MunicaoNaArma + BalaQueFaltam;
                        TotalDeMunicao = TotalDeMunicao - BalaQueFaltam;
                    }
                    else
                    {
                        MunicaoNaArma += TotalDeMunicao;
                        TotalDeMunicao = 0;
                    }


                    GameObject.Find("WeaponBulletText").GetComponent<Text>().text = MunicaoNaArma.ToString();
                    GameObject.Find("TotalBulletText").GetComponent<Text>().text = TotalDeMunicao.ToString();

                }
            }
        }

    }

    void Fire()
    {
        ShotEffects();
        try
        {
            RaycastHit hit;
            if (Physics.Raycast(shotPos.position, shotPos.forward, out hit, 250))
            {
                hit.collider.transform.root.GetComponent<Mutants>().TakeDamage(damage);
            }

        }
        catch
        {

        }
        
    }

    void ShotEffects()
    {
        source.PlayOneShot(shootSound, vol);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isDead) {
        
            Mutants mut;
            if (other.CompareTag("BossAttack") || other.CompareTag("Enemy01Attack") || other.CompareTag("Enemy02Attack") || other.CompareTag("Enemy03Attack"))
            {

                //gameObject.layer = LayerMask.GetMask("EnemyDead");

                mut = other.transform.root.GetComponent<Mutants>();
                if (mut.getAttack())
                {
                    setLife(life -= mut.dano);
                    source.PlayOneShot(damageSound, vol);
                }
            }

            if (other.CompareTag("Cura"))
            {
                setLife(life += cura);
                source.PlayOneShot(curaSound, vol);
            }

            if (other.CompareTag("Municao"))
            {
                TotalDeMunicao +=municao;
                source.PlayOneShot(municaoSound, vol);
                GameObject.Find("TotalBulletText").GetComponent<Text>().text = TotalDeMunicao.ToString();
            }

            GameObject.Find("LifeText").GetComponent<Text>().text = life.ToString();

            if (life <= 0)
            {
                isDead = true;
            }
        }
    }
}
