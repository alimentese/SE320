using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed =2f;
    public float health = 50f;
    Rigidbody2D myRigidbody2D;
    public GameObject player;
    //BoxCollider2D periscope;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //periscope = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (IsFacingRight()) {
            myRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }

        else 
        {
            myRigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        }

        if(health <=0) {
            DestroyObject(this.gameObject);
        }
    }

       private bool IsFacingRight() {
            return transform.localScale.x > 0;
       }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.health -= 10f;
        } 
    }*/

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.GetComponent<PlayerScript>().currentHP -= 10f;
        }
    }


}
