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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 if(Input.GetKeyDown(KeyCode.Semicolon)){
                if(scoreSaver.defeated){
					print("Lost");
                    ChangeLevel("TutorialLevel");
                } 
            }
	}

	 public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
