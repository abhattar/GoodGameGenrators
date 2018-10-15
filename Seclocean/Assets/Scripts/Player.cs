using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public float speedValue;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        float speed = Input.GetAxis("Horizontal") * Time.deltaTime * speedValue;
        float speed2 = Input.GetAxis("Vertical") * Time.deltaTime * speedValue;

        transform.localScale = new Vector3(speed / Mathf.Abs(speed), 1, 1);

        animator.SetFloat("speed", Mathf.Abs(speed));
        animator.SetFloat("speed2", Mathf.Abs(speed));

        transform.Translate(new Vector3(speed, speed2));

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Bite");
        }

    }

}
