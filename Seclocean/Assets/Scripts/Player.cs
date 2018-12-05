using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {


    public float speedValue;

    private float initSpeedValue;

    private bool staminaDecrease;

    private int blueLightOnce;

    public GameObject biteSound;

    public GameObject pearlSound;

  

    private int pearlTimer;

    private bool pearlTimerCountdown;

    

    
    


    // Use this for initialization
    void Start () {
        initSpeedValue = speedValue;
        staminaDecrease = false;
        blueLightOnce = 0;
        biteSound.SetActive(false);
        pearlSound.SetActive(false);
        pearlTimer = 30;
        pearlTimerCountdown = false;

    }
    
    // Update is called once per frame
    void Update () {
        if(scoreSaver.blueLight){
            if(blueLightOnce == 0){
                blueLightOnce = 1;
            }
            else if(blueLightOnce == 1){
                speedValue = speedValue + scoreSaver.speed;
                blueLightOnce = 2;
            }
        }



        if(pearlTimerCountdown){
            if(pearlTimer > 0){
                pearlTimer --;
            }
            else{
                pearlTimer = 30;
                pearlTimerCountdown = false;
                pearlSound.SetActive(false);
            }
        }



        if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")){
            biteSound.SetActive(true);
        }
        else{
            biteSound.SetActive(false);
        }
        
        
        if(!scoreSaver.dialogueOn){
            if(scoreSaver.health > 0){
                if (Input.GetKeyDown(KeyCode.J))
                {
                    if(scoreSaver.stamina > 0){
                        speedValue = initSpeedValue * 2;
                        staminaDecrease = true;
                    }
                    
                }
                else if (Input.GetKeyUp(KeyCode.J)){
                    speedValue = initSpeedValue;
                    staminaDecrease = false;
                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    GetComponent<Animator>().SetTrigger("Bite");
                    print("once");
                }

                if(staminaDecrease){
                    if(scoreSaver.stamina > 0)
                    scoreSaver.stamina--;
                    else if (scoreSaver.stamina <= 0) {
                        speedValue = initSpeedValue;
                    }   
                }
                else{
                    if(scoreSaver.stamina <= 123.0f)
                    scoreSaver.stamina = scoreSaver.stamina+ 0.20f;
                }
                
                
                float speed = Input.GetAxis("Horizontal") * Time.deltaTime * speedValue;
                float speed2 = Input.GetAxis("Vertical") * Time.deltaTime * speedValue;

                float xScale = 0.6515f;
                if(speed / Mathf.Abs(speed) == 1){
                    xScale = 0.6515f;
                }
                else if (speed / Mathf.Abs(speed) == -1){
                    xScale = -0.6515f;
                }

                if(Input.GetKeyDown(KeyCode.Semicolon)){
                    if(scoreSaver.health != 0){
                        if(scoreSaver.inLayer == 3){
                            if(scoreSaver.bossHP == 0){
                                ChangeLevel("HomeWorld");
                            }
                        }  
                    }
                    
                }

            transform.localScale = new Vector3(xScale, 0.6515f, 0.6515f);

                // GetComponent<Animator>().SetFloat("speed", Mathf.Abs(speed));
                // GetComponent<Animator>().SetFloat("speed2", Mathf.Abs(speed2));

                transform.Translate(new Vector3(speed, speed2));

        
            

                

                Vector3 pos = transform.position;

                if (Input.GetKeyDown(KeyCode.W)){
                    pos.y += speed * Time.deltaTime;
                }
                if(Input.GetKeyDown(KeyCode.S)){
                    pos.y -= speed * Time.deltaTime;

                }
                if(Input.GetKeyDown(KeyCode.A)){
                    pos.x -= speed * Time.deltaTime;

                }
                if(Input.GetKeyDown(KeyCode.D)){
                    pos.x += speed * Time.deltaTime;
                }
            }
            else
            {
                scoreSaver.defeated = true;
            }
        }
        

   

    }

    void OnTriggerStay2D(Collider2D col)
    {
            if(col.isTrigger){
                if (col.tag == "Enemy"){
                    if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")) { 
                        //Destroy(col.gameObject);
                    }
                    else{
                       
                    }
                    if(col.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("attack")){
                       // scoreSaver.health = scoreSaver.health - 0.25;
                        // GetComponent<RigidBody>().Addforce(new Vector2(10, 0 ));
                    }
                }
            
                if (col.tag == "BlackPearl"){
                    scoreSaver.blackpearls++;
                    if(pearlTimer == 30){
                        pearlSound.SetActive(true);
                        pearlTimerCountdown = true;
                    }
                    Destroy(col.gameObject);
                }
                if (col.tag == "Projectile"){
                     scoreSaver.health = scoreSaver.health - 1;
                }

               
            }

            	   
    }

    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
