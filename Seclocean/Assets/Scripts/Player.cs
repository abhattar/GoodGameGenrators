using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public float speedValue;
    public Camera sideCamera;
    public Camera overheadCamera;

    private float initSpeedValue;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        initSpeedValue = speedValue;
   
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            speedValue = initSpeedValue * 2;   
        }
        else if (Input.GetKeyUp(KeyCode.J)){
            speedValue = initSpeedValue;
        }

        float speed = Input.GetAxis("Horizontal") * Time.deltaTime * speedValue;
        float speed2 = Input.GetAxis("Vertical") * Time.deltaTime * speedValue;

        
        

        // transform.localScale = new Vector3(speed / Mathf.Abs(speed), 1, 1);

        // animator.SetFloat("speed", Mathf.Abs(speed));
        // animator.SetFloat("speed2", Mathf.Abs(speed));

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

       




        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(sideCamera){
                overheadCamera.enabled= true;
                sideCamera.enabled=false;
            }
      
        }

   

    }

    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.isTrigger){
                
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Angie Bite")) { 
				    Destroy(col.gameObject);
                }
                
            
            }	   
    }

}
