using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject attackBox;
    Animator anim;
    public GameObject player;
    public float attackDistance = 3f;
    public float seekDistance = 35f;
    public float speed = 10f;
    public bool dying = false;
    public int mashroomdamage = 20;
    int mushroomhealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        attackBox = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        checkAlive();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < attackDistance)
            {
                anim.SetTrigger("IsAttacking");
                Invoke("Attack", .4f);
            }
            else if (distance < seekDistance)
            {
                MoveTowardPlayer();
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }
        }
    }

    void MoveTowardPlayer()
    {
        if (!dying)
        {
            int direction = player.transform.position.x < transform.position.x ? -1 : 1;
            if (player.transform.position.x < transform.position.x)
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-4f, 4f, 0f);
                }
            }
            else
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(4f, 4f, 0f);
                }
            }
            transform.Translate(transform.right * direction * speed * Time.deltaTime);
            anim.SetBool("IsRunning", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            Attack();
        } 
        
    }

    private void checkAlive() {
        if(mushroomhealth <= 0) {
            dying = true;
            anim.SetBool("Death", true);
            Destroy(gameObject, 1f);
        }
    }
    private void Attack()
    {
        
        
        if (!dying)
        { 
            attackBox.SetActive(true);
            Invoke("EndAttack", 0.26f);
        }
    }

    void EndAttack()
    {
        attackBox.SetActive(false);
    }
}
