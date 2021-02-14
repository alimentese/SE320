using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{

    //[SerializeField] GameObject enemy;
    public GameObject[] enemy;
    private AudioSource SwingSound;
    Enemy enemyscript;
    
    // Start is called before the first frame update
    void Start()
    {

        SwingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemy) {
            enemyscript = enemy.GetComponent<Enemy>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Attack1(collision.gameObject);        
        }

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
