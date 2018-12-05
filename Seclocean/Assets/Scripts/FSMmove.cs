using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMmove : MonoBehaviour
{
    public const string hatchet = "HatchetFish";
    public const string  snaggle = "SnaggleTooth";

    public const string squid = "Squid";
    public const string orthoCannon = "Orthocanon";
    public const string starGazer = "Stargazer";

    
    public string enemyType;

    public GameObject sideHealthBar;

    private bool DecreaseHitpoints;

    public GameObject topHealthBar;

    public float hitPoints;

    public GameObject biteSound;

    public int maxTargetTime;
    private float min ;
    private float max ;
    private int biteTimer;

    private bool patrol;
    private bool chase;
    private bool dead;
    
    private GameObject activeAngie;

    public GameObject sideSprite;
    public GameObject topSprite;

    private float initialPos;
    private float changedPos;

    private float initialHitpoints;

    public int speedMultiplier;

    public string axis;

    public float add;
    private int targetTime;

    private float deathmin;
    private float deathmax;

    private float percentHitPoint;
    // Use this for initialization

    void Start()
    {

        if(enemyType == "boss"){
           hitPoints = scoreSaver.bossHP;
        }
        initialHitpoints = hitPoints;
        
        biteTimer = 60;
        
        patrol = true;
        chase = false;
        dead = false;
    
        targetTime = 0;
        if(axis =="x"){
            min = transform.position.x ;
            max = transform.position.x + add;
        }
        else if(axis == "y"){
            min = transform.position.y;
            max = transform.position.y + add;
        }

        biteSound.SetActive(false);
         
    }

    // Update is called once per frame
    void Update()
    {
              
        if(scoreSaver.bossHP == 0){
            scoreSaver.cleared = true;
        }
        percentHitPoint = (hitPoints / initialHitpoints * 100) / 100;
       

        activeAngie = scoreSaver.activeAngie;

        if(hitPoints == initialHitpoints){
            sideHealthBar.SetActive(false);
            topHealthBar.SetActive(false);
        }
        else if (hitPoints <= initialHitpoints){
            sideHealthBar.SetActive(true);
            sideHealthBar.transform.localScale = new Vector3(percentHitPoint,4,1);
            topHealthBar.SetActive(true);
            topHealthBar.transform.localScale = new Vector3(percentHitPoint,4,1);
        }

        

        //print(hitPoints + gameObject.name);

        initialPos = transform.position.x;
        if(patrol && !dead){
            if(axis =="x")
            transform.position = new Vector3(Mathf.PingPong(Time.time * speedMultiplier, max - min) + min, transform.position.y, transform.position.z);
            else if(axis == "y")
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speedMultiplier, max - min) + min, transform.position.z);

            
        }
        else if (chase && !dead){
            if(activeAngie.tag == "Player")
            transform.position =  Vector3.MoveTowards(transform.position, activeAngie.transform.position, speedMultiplier * Time.deltaTime);
            targetTime++;
        }
        
            changedPos = transform.position.x;

        if(changedPos > initialPos){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(changedPos < initialPos){
            
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(DecreaseHitpoints){
            if(biteTimer == 60){
                hitPoints = hitPoints - 1;
                biteTimer--;
            }
            else{
                DecreaseHitpoints = false;
                biteTimer--;
            }
            if(biteTimer == 0){
                biteTimer = 60;
            }

        }

   

   
        if(hitPoints <= initialHitpoints/2){
           transform.Find("Side").GetComponent<Animator>().SetTrigger("RemoveShield");
           
        }

        if (hitPoints <= 0){
            transform.Find("Side").GetComponent<Animator>().SetTrigger("Dead");
            transform.Find("Top").GetComponent<Animator>().SetTrigger("Dead");
            dead = true;
            maxTargetTime = 200;
        }
      
        
        if (targetTime >= maxTargetTime)
        {
            timerEnded();
            targetTime = 0;
        }
        targetTime++;
        
        // if(transform.Find("Side").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("attack")){
        //     biteSound.SetActive(true);
        // }
        // else{
        //     biteSound.SetActive(false);
        // }
    }


    void timerEnded()
    {
        if(!dead){
            transform.Find("Side").GetComponent<Animator>().SetTrigger("Attack");
            transform.Find("Top").GetComponent<Animator>().SetTrigger("Attack");
            
        }
        if(dead){
            scoreSaver.kills++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
                    if((enemyType == "chase")){
                        patrol = false;
                        chase = true;
                    }
                }
                if(col.tag == "Enemy"){
                    //print("Enemy");
                }
            }      	   
    }


    public void PullTrigger(){
        if(enemyType != "boss"){
            DecreaseHitpoints = true;
        }
        else{
            hitPoints--;
            scoreSaver.bossHP = hitPoints;
            print(hitPoints);
            print(scoreSaver.bossHP);
        }
        //print("once");
        
    }

    public void PlaySound(){
         biteSound.SetActive(true);
    }

    public void StopSound(){
        biteSound.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.isTrigger){
                if ((col.tag == "Player") || (col.tag == "PlayerTop")){
                    patrol = true;
                    chase = false;
                }
            } 
    }

    
}


