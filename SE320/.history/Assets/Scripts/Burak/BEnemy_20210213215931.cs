using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BEnemy : MonoBehaviour
{

    [SerializeField]
    Transform player;
    [SerializeField]
    float EnemySpeed;

    [SerializeField]
    float AgroRange;

    [SerializeField]
    float EnemyJump;

    [SerializeField]
    float SkeletonDamage;

    [SerializeField]
    float SkeletonHealth;

    BAttacking attacking;
    
    public LayerMask groundMask;
    public bool isGrounded;
    public bool ontrigger= false;
    


    Animator EnemyAnim;
    Rigidbody2D  EnemyRb;

    void Start(){
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();
        Attackingg = GetComponent<BAttacking>();
        
    }
    
    void Update(){
        Attack();
       
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.0f),new Vector2(0.9f, 0.4f),0f, groundMask);

         if(distToPlayer < AgroRange){
             
            ChasePlayer();
            jumping();
            
            
          
         }

        else{
            
             StopChasingPlayer();
        }

    }
         

   
    void ChasePlayer(){
         if((transform.position.x < player.position.x + 0.1 )){
             //right move
             EnemyRb.velocity = new Vector2(EnemySpeed,EnemyRb.velocity.y);
              direction();
              
             
             //transform.localScale = new Vector2(1,-1);
             
         }


         else if (transform.position.x > player.position.x - 0.4 ){
             //left move
             EnemyRb.velocity = new Vector2(-EnemySpeed,EnemyRb.velocity.y);
             //transform.localScale = new Vector2(-1,1);
             direction();
             
         }

         EnemyAnim.SetFloat("EnemySpeed",EnemySpeed);

         

    }



    void direction(){
         if((transform.position.x < player.position.x )){
             transform.localScale = new Vector2(1,1);
             
         }

         else if (transform.position.x > player.position.x){
             transform.localScale = new Vector2(-1,1);
         }
         else if(transform.position.x == player.position.x){
             transform.localScale = new Vector2(0,1);
         }
    }

     void jumping(){

                if(player.position.y - transform.position.y > 2 && isGrounded  && ontrigger == true ){
                    //jump
                    EnemyRb.velocity = new Vector2(EnemySpeed,EnemyJump);
                
                    
                }
        } 
    
    
    void Attack(){
        if(attacking.trigger == true){
                EnemyAnim.SetTrigger("EnemyAttack");
                Debug.Log("YazıScript denemesi");


            }
    }

    
    void StopChasingPlayer(){

       EnemyRb.velocity = new Vector2(0,EnemyRb.velocity.y);
        
        EnemyAnim.SetFloat("EnemySpeed",0);
         
          
    }  
    
    
    
    
    

    //for groundmask
    void OnDrawnGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y -0.5f), new Vector2(0.9f,0.2f));
    }

    void OnTriggerEnter2D(Collider2D col){
        
         if(col.gameObject.tag == "JumpArea"){
            Debug.Log("Sa");
            ontrigger = true;
             
         }
    }

    void OnTriggerExit2D(Collider2D col){
        ontrigger = false;
    }

}





