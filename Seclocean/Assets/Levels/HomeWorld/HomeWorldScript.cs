using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeWorldScript : MonoBehaviour {


	private bool bossHomeWorld;
	private bool coryHomeWorld;
	private bool coryDialogueBool;
	private bool bossDialogueBool;

	public GameObject coryDialogue;
	public GameObject bossDialogue;
	public GameObject startText;
	

	// Use this for initialization
	void Start () {
		coryDialogueBool = false;
		bossDialogueBool = false;
		coryHomeWorld = false;
		bossHomeWorld = false;
		startText.SetActive(true);
		scoreSaver.dialogueOn = true;
		coryDialogue.SetActive(false);
		bossDialogue.SetActive(false);
		scoreSaver.dialogueOn = true;
	}

	
	// Update is called once per frame
	void Update () {
		print(scoreSaver.dialogueOn);
		if(scoreSaver.dialogueOn == true){
			if(Input.GetKeyDown(KeyCode.Space)){
				startText.SetActive(false);
				scoreSaver.dialogueOn = false;
			}
			
		}

		if(coryDialogueBool){
			//coryDialogue.SetActive(true);
			if(scoreSaver.tutorial == true && scoreSaver.Cory1v1 == false){
				ChangeLevel("Cutscene2a");
			}
			if(scoreSaver.Cory1v1){
					coryDialogue.SetActive(true);
				 if(Input.GetKeyDown(KeyCode.Return)){
			 		coryDialogue.SetActive(false);
			 		scoreSaver.dialogueOn = false;
					coryDialogueBool = false;
			 	}
			}
				
		}

		if(bossDialogueBool){
			// bossDialogue.SetActive(true);
			// if(Input.GetKeyDown(KeyCode.Space)){
			// 	bossDialogue.SetActive(false);
			// 	scoreSaver.dialogueOn = false;
			// 	bossDialogueBool = false;
			// }
			ChangeLevel("Cutscene3");
			if(Input.GetKeyDown(KeyCode.Semicolon)){
					ChangeLevel("GangInitiation");
			}
		}

		if(Input.GetKeyDown(KeyCode.Semicolon)){
			if(coryHomeWorld){
				coryDialogueBool = true;
				scoreSaver.dialogueOn = true;
			}
			else if(bossHomeWorld){
				bossDialogueBool = true;
				scoreSaver.dialogueOn = true;
			}
		}

	}

	  void OnTriggerEnter2D(Collider2D col){
		  if((col.tag == "Player")||(col.tag == "PlayerTop"))
		  {
				if(gameObject.tag == "coryHomeWorld")
				{
					
						coryHomeWorld = true;
						bossHomeWorld = false;
					
				}
				else if(gameObject.tag=="bossHomeWorld")
				{
				
					bossHomeWorld = true;
					coryHomeWorld = false;
				}
		  }
		  
	  }

	     public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	  void onTriggerExit2D(Collider2D col){
		if((col.tag == "Player")||(col.tag =="PlayerTop"))
		{
						if(gameObject.tag == "coryHomeWorld")
						{
							coryHomeWorld = false;
							
						}
						else if(gameObject.tag=="bossHomeWorld")
						{
							
							bossHomeWorld = false;
						}
				}
		}
}
