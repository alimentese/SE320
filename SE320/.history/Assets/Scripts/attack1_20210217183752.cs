using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{

    //[SerializeField] GameObject enemy;
    public GameObject[] enemy;
    private AudioSource SwingSound;
    Enemy EnemyObject;
    public GameObject Skeleton_Enemy;
    public GameObject Playerr;
    PlayerScript player;



    void Start() {
        player = Playerr.GetComponent<PlayerScript>();
        SwingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemy) {
            EnemyObject = enemy.GetComponent<Enemy>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            Attack1(collision.gameObject);
            Debug.Log("ontrigger");
        }

    }


    private void Attack1(GameObject enemy) {
        SwingSound.Play();
        System.Random random = new System.Random();
        int damage = random.Next(1, (int)player.GetComponent<PlayerScript>().maxSTR);
        int critchance = random.Next(0, 1);
        if(critchance == 1) {
            damage += (int)player.GetComponent<PlayerScript>().maxAGI;
        }
        
        if(enemy.gameObject.name == "Slime") {
            enemy.GetComponent<Enemy>().health -= damage;
        }
        if (enemy.gameObject.name == "Skeleton_Enemy") {
            enemy.GetComponent<BEnemy>().SkeletonHealth -= damage;
        }
        if (enemy.gameObject.name == "MushRoom") {
            enemy.GetComponent<BEnemy>().SkeletonHealth -= damage;
        }

        Debug.Log("Damage: " + damage);
        if(enemy.gameObject.transform.localScale.x == -1) {
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1800);
            enemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 65);
        }
        if(enemy.gameObject.transform.localScale.x == 1) {
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1800);
            enemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 65);
        }


    }
}
