using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{

    //[SerializeField] GameObject enemy;
    public GameObject[] enemy;
    private AudioSource SwingSound;
    Enemy enemyscript;
    //public GameObject[] Skeleton_Enemy;
   // BEnemy bTakenDamage;
    public GameObject Playerr;
    PlayerScript player;
    
    // Start is called before the first frame update
    void Start()
    {   
        player = Playerr.GetComponent<PlayerScript>();
        //bTakenDamage = Skeleton_Enemy.GetComponent<BEnemy>();
        SwingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemy) {
            enemyscript = enemy.GetComponent<Enemy>();
        }

        //Skeleton_Enemy = GameObject.FindGameObjectsWithTag("Skeleton_EEnemy");
        foreach (GameObject Skeleton_Enemy in Skeleton_Enemy) {
            bTakenDamage = Skeleton_Enemy.GetComponent<BEnemy>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Attack1(collision.gameObject);        
        }

      /* else if(collision.gameObject.tag == "Skeleton_EEnemy"){
            SwingSound.Play();
           bTakenDamage.TakenDamage(25);
           Debug.Log("djakljlsaaddds"); 
        }
        */

    }

    /*private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            Attack1(collision.gameObject);
        }
    }*/
    private void Attack1(GameObject enemy) {
        SwingSound.Play();
        enemy.GetComponent<Enemy>().health -= 25;
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 5));

    }
}
