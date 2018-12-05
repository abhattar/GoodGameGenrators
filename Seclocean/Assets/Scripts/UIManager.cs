using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{

	public GameObject Instructions;
	public GameObject CloseInstructionsButton;
	public GameObject StartButton;
	public GameObject StartInstructionsButton;

	// Use this for initialization
	void Start () {
		StartButton.SetActive(true);
		CloseInstructionsButton.SetActive(false);
		StartInstructionsButton.SetActive(true);
		Instructions.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void InstructionsActive(bool value){
		if(value){
			Instructions.SetActive(true);
			StartButton.SetActive(false);
			CloseInstructionsButton.SetActive(true);
			StartInstructionsButton.SetActive(false);
		}
		else if(!value){
			Instructions.SetActive(false);
			StartButton.SetActive(true);
			CloseInstructionsButton.SetActive(false);
			StartInstructionsButton.SetActive(true);
		}
	}
}
