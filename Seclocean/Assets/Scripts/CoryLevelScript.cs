using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoryLevelScript : MonoBehaviour {

	public GameObject round1;
	public GameObject round2;
	public GameObject round3;


	public static bool round1Active;
	public static bool round2Active;
	public static bool round3Active;
	public static bool defeat;

	// Use this for initialization
	void Start () {
			round1Active = true;
			round2Active = false;
			round3Active = false;
			scoreSaver.dialogueOn = false;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreSaver.cleared){
			if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                ChangeLevel("HomeWorld");
            }
		}
		if(round1Active){
			round1.SetActive(true);
			if(scoreSaver.bossHP <= 0){
				round1Active = false;
				round2Active = true;
				scoreSaver.bossHP = 123.0f;
				coryFSM.coryHealth = 123.0f;
			}
		}
		else{
			round1.SetActive(false);
		}
		if(round2Active){
			round2.SetActive(true);
			if(scoreSaver.bossHP <= 0){
				round2Active = false;
				round3Active = true;
				scoreSaver.bossHP = 123.0f;
				coryFSM.coryHealth = 123.0f;
			}
		}
		else{
			round2.SetActive(false);
		}
		if(round3Active){
			round3.SetActive(true);
			if(scoreSaver.bossHP <= 0){
				scoreSaver.cleared = true;
			}
		}
		else{
			round3.SetActive(false);
		}
	}

	   public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
