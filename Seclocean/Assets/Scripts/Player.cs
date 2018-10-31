using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    Animator animator;
    public int layer;

    public float speedValue;
    public Camera sideCamera;
    public Camera sideCamera2;
    public Camera overheadCamera;
    
    private int test;
    private float initSpeedValue;
    private float maxHealth;
    private int activeLayer;
    
    


    // Use this for initialization
    void Start () {
        maxHealth = 65.0f;
        animator = GetComponent<Animator>();
        initSpeedValue = speedValue;
        test = 0;
    }
    
    // Update is called once per frame
    void Update () {

        
          
        if(sideCamera.enabled){
            activeLayer = 1;
        }
        else if(sideCamera2.enabled){
            activeLayer = 2;
        }
        else if(overheadCamera.enabled){
            activeLayer = 0;
        }
        else{
            activeLayer = 23;
        }


        if(activeLayer == layer) {

            if (Input.GetKeyDown(KeyCode.J))
            {
                speedValue = initSpeedValue * 2;   
            }
            else if (Input.GetKeyUp(KeyCode.J)){
                speedValue = initSpeedValue;
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

         transform.localScale = new Vector3(xScale, 0.6515f, 0.6515f);

            // animator.SetFloat("speed", Mathf.Abs(speed));
            // animator.SetFloat("speed2", Mathf.Abs(speed2));

            transform.Translate(new Vector3(speed, speed2));

    
        

            if (Input.GetKeyDown(KeyCode.K))
            {
                GetComponent<Animator>().SetTrigger("Bite");
            }

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

                if (Input.GetKeyUp(KeyCode.Space))
                {
                        print(layer);
                        print(activeLayer);
         
                        if((sideCamera.enabled)){
                            sideCamera.enabled = false;
                            sideCamera2.enabled = false;  
                            overheadCamera.enabled = true;
                        }
                        else if((overheadCamera.enabled)){
                            overheadCamera.enabled = false;
                            sideCamera.enabled = true;
                          
                        }
                        
                }
            
        }

   

    }

    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")) { 
				    Destroy(col.gameObject);
                }
                else{
                    if(scoreSaver.health > 0)
                    scoreSaver.health--;
                }
                
            
            }	   
    }

}
