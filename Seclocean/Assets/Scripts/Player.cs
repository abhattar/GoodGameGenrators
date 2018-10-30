using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public int layer;
    public float speedValue;
    public Camera sideCamera;
    public Camera sideCamera2;
    public Camera overheadCamera;

    private float initSpeedValue;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        initSpeedValue = speedValue;
        sideCamera.enabled = true;
        overheadCamera.enabled = false;
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

        float xScale = 0.6515f;
        if(speed / Mathf.Abs(speed) == 1){
            xScale = 0.6515f;
        }
        else if (speed / Mathf.Abs(speed) == -1){
            xScale = -0.6515f;
        }

      transform.localScale = new Vector3(xScale, 0.6515f, 0.6515f);

        //animator.SetFloat("speed", Mathf.Abs(speed));
        //animator.SetFloat("speed2", Mathf.Abs(speed));

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

       



        if(layer == 1){
            if (Input.GetKeyUp(KeyCode.Space))
            {
                    print(sideCamera.enabled);
                    print(overheadCamera.enabled);
                
                    if((sideCamera.enabled)){
                        print("yeet");
                        overheadCamera.enabled = true;
                        sideCamera.enabled = false;
                    }
                    else if((overheadCamera.enabled)){
                        print("clothing");
                        sideCamera.enabled = true;
                        overheadCamera.enabled = false;  
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
                
            
            }	   
    }

}
