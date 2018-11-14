using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSaver : MonoBehaviour {

	public static float health = 123.0f;

	public static float stamina = 123.0f;
	public static int kills;
	public static int blackpearls;

	public static int  bossHP;

	public static bool defeated;





	///Layer and Portals Data
	public static int inLayer;
	public static string inPortal;
	public static float layer1Ytop;
	
	public static float layer2Ytop;

	public static float layer3Ytop;

	public static float layer4Ytop;

	public static float layer1Yside;
	
	public static float layer2Yside;

	public static float layer3Yside;

	public static float layer4Yside;

	public static float portal1TopX;

	public static float portal1SideX;

	public static float portal1TopY;

	public static float portal1SideY;

	public static float portal2TopX;

	public static float portal2SideX;

	public static float portal2TopY;

	public static float portal2SideY;

	public static float angiePosX;

	public static string layerKind;

	public static GameObject activeAngie;

	



	//UI ELEMENTS

	public Text BlackPearls;
	public GameObject healthBar;
	public GameObject staminaBar;
	public GameObject defeatedUI;

	// Use this for initialization
	void Start () {
		bossHP = 0;
		blackpearls = 0;
		health = 123.0f;
		stamina = 123.0f;
		kills = 0;
		defeated = false;
		defeatedUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		RectTransform rt = healthBar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (scoreSaver.health, rt.rect.height);

		RectTransform rts = staminaBar.GetComponent<RectTransform>();
        rts.sizeDelta = new Vector2 (scoreSaver.stamina, rts.rect.height);

		BlackPearls.text = (blackpearls/2).ToString();

		if(health <= 0){
			defeated = true;
		}
		if(defeated){
			defeatedUI.SetActive(true);	
		}
		
		

	}
}
