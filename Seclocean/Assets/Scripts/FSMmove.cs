using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMmove : MonoBehaviour
{
    public int hitPoints;
    public int maxTargetTime;
    private float min ;
    private float max ;

    private bool patrol;
    private bool chase;
    private bool dead;
    
    private GameObject activeAngie;

    private float initialPos;
    private float changedPos;

    private float initialHitpoints;

    public int speedMultiplier;

    public string axis;

    public float add;
    private int targetTime;

    private float deathmin;
    private float deathmax;
    // Use this for initialization

    void Start()
    {
        initialHitpoints = hitPoints;
        patrol = true;
        chase = false;
        dead = false;
    
        targetTime = 0;
        if(axis =="x"){
            min = transform.position.x;
            max = transform.position.x + add;
        }
        else if(axis == "y"){
            min = transform.position.y;
            max = transform.position.y + add;
        }
    }

    // Update is called once per frame
    void Update()
    {
        initialPos = transform.position.x;
        if(patrol && !dead){
            if(axis =="x")
            transform.position = new Vector3(Mathf.PingPong(Time.time * speedMultiplier, max - min) + min, transform.position.y, transform.position.z);
            else if(axis == "y")
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speedMultiplier, max - min) + min, transform.position.z);
        }
        else if (chase && !dead){
            
        }
        changedPos = transform.position.x;


        if(changedPos > initialPos)
        transform.localScale = new Vector3(-1, 1, 1);
        else if(changedPos < initialPos)
        transform.localScale = new Vector3(1, 1, 1);

        targetTime++;

        if(dead){
            transform.position = new Vector3(transform.position.x, -1*Mathf.PingPong(Time.time * 3, deathmax - deathmin) + deathmin, transform.position.z);
        }

        if(hitPoints == initialHitpoints/2){
            transform.Find("Hatchet Fish Side").GetComponent<Animator>().SetTrigger("RemoveShield");
        }
        else if (hitPoints == 0){
            transform.Find("Hatchet Fish Side").GetComponent<Animator>().SetTrigger("Dead");
            dead = true;
            targetTime = 0;
            maxTargetTime = 100;
            deathmin = transform.position.y;
            deathmax = transform.position.y + add;
        }
      

        if (targetTime >= maxTargetTime)
        {
            timerEnded();
            targetTime = 0;
        }
    }


    void timerEnded()
    {
        if(!dead)
        transform.Find("Hatchet Fish Side").GetComponent<Animator>().SetTrigger("Attack");
        else
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D col)
    {
            if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
                    patrol = false;
                    chase = true;
                }
                
                
            }      	   
    }

    void OnTriggerExit2d(Collider2D col){
        if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
                    patrol = true;
                    chase = false;
                }
            } 
    }
}


