using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	 public static GameController Instance {
        get;
        set;
    }

	void Awake () {
        DontDestroyOnLoad (transform.gameObject);
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool tutorialComplete = false;
	public bool OneVOneComplete = false;
	public bool gangInitiationComplete = false;
	public bool chasingLevelComplete = false;
	public bool stalkingLevelComplete = false;
    public int health = 0;
    public int blackPearlsNumber = 0;

}
