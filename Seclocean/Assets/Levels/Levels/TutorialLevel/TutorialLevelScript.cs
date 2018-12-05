using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLevelScript : MonoBehaviour {

	public static float portal1XTop;
	public static float portal1YTop;
	public static float portal1XSide;
	public static float portal1YSide;

	public static float portal2XTop;
	public static float portal2YTop;
	public static float portal2XSide;
	public static float portal2YSide;

	public static bool attackBoxOn;
	public static bool lightBoxOn;
	public static bool stuckBoxOn;
	public static bool batteryBoxOn;
	public static bool caveBoxOn;

	public GameObject dialogueBox;
	public GameObject attackBox;
	public GameObject lightBox;
	public GameObject stuckBox;
	public GameObject batteryBox;
	public GameObject caveBox;


	// Use this for initialization
	void Start () {
		dialogueBox.SetActive(true);
		attackBox.SetActive(false);
		lightBox.SetActive(false);
		stuckBox.SetActive(false);
		batteryBox.SetActive(false);
		caveBox.SetActive(false);
		scoreSaver.dialogueOn = true;

		
		attackBoxOn = false;
		lightBoxOn = false;
		stuckBoxOn = false;
		batteryBoxOn = false;
		caveBoxOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!scoreSaver.dialogueOn){
		 if(Input.GetKeyDown(KeyCode.Semicolon)){
			 	dialogueBox.SetActive(false);
                if(scoreSaver.defeated){
					print("Lost");
                    ChangeLevel("TutorialLevel");
                } if(scoreSaver.cleared) {
					scoreSaver.tutorial = true;
					ChangeLevel("HomeWorld");
				}
            }
		
			
		}
		else {
			if(Input.GetKeyDown(KeyCode.Return)){
				scoreSaver.dialogueOn = false;
				dialogueBox.SetActive(false);
				attackBox.SetActive(false);
				lightBox.SetActive(false);
				stuckBox.SetActive(false);
				batteryBox.SetActive(false);
				caveBox.SetActive(false);

				attackBoxOn = false;
				lightBoxOn = false;
				stuckBoxOn = false;
				batteryBoxOn = false;
				caveBoxOn = false;
			}

			if(attackBoxOn)
			attackBox.SetActive(true);

			if(lightBoxOn)
			lightBox.SetActive(true);

			if(stuckBoxOn)
			stuckBox.SetActive(true);

			if(batteryBoxOn)
			batteryBox.SetActive(true);

			if(caveBoxOn)
			caveBox.SetActive(true);
		}
	}

	 public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
