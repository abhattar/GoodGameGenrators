using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {


    Animator animator;
	public GameObject Player;
	public GameObject other;

	// Use this for initialization
	void Start () {
		animator = Player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D()
    {
			
			 if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bite")) { 
				 Destroy(other);
			  }
			   
    }




}
