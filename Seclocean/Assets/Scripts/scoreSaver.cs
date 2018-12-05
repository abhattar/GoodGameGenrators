using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSaver : MonoBehaviour {


	//Stats

	public static float health = 123.0f;
	public static float stamina = 123.0f;
	public static int kills;
	public static int blackpearls;


	public static int attackPoints;
	public static int speed;
	public static int damageScaler;

	public static float checkPointX;

    public static float checkPointY;


	public static float  bossHP;

	public static bool defeated;
	public static bool cleared;

	//Level Clear
	public static bool tutorial = false;
	public static bool Cory1v1 = false;
	public static bool GangInitiation = false;



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

	public static float portal3TopX;

	public static float portal3SideX;

	public static float portal3TopY;

	public static float portal3SideY;

	
	public static float portal4TopX;

	public static float portal4SideX;

	public static float portal4TopY;

	public static float portal4SideY;

	public static float angiePosX;

	public static string layerKind;

	public static GameObject activeAngie;

	public static bool dialogueOn;

	public static bool yellowLight;

	public static bool blueLight;

	public static bool redLight;
	



	//UI ELEMENTS
	public GameObject bossHPUI;
	public GameObject bossHPBar;
	public Text BlackPearls;
	public GameObject healthBar;
	public GameObject staminaBar;
	public GameObject defeatedUI;
	public GameObject clearedUI;
	public GameObject bloodSplatLight;
	public GameObject bloodSplatDark;

	public static bool bloodSplatLightActive;
	public static bool bloodSplatDarkActive;

	public GameObject lowHealthSound;
	public GameObject BackgroundSound;

	// Use this for initialization
	void Start () {
		bossHP = 123.0f;
		health = 123.0f;
		stamina = 123.0f;
		kills = 0;
		defeated = false;
		cleared = false;
		defeatedUI.SetActive(false);
		clearedUI.SetActive(false);
		bossHPUI.SetActive(false);
		bossHPBar.SetActive(false);
		dialogueOn = false;
		bloodSplatLight.SetActive(false);
		bloodSplatDark.SetActive(false);
		bloodSplatLightActive = false;
		bloodSplatDarkActive = false;
		
		speed = 0;

		lowHealthSound.SetActive(true);
		BackgroundSound.SetActive(true);

		yellowLight = false;
		blueLight = false;
		redLight = false;

		
		//LvlCleared
	}


	
	// Update is called once per frame
	void Update () {

		if(blueLight){
			speed = 5;
		}
		if(redLight){
			attackPoints = 2;
			damageScaler = -2;
		}
		
		RectTransform rt = healthBar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (scoreSaver.health, rt.rect.height);

		RectTransform rts = staminaBar.GetComponent<RectTransform>();
        rts.sizeDelta = new Vector2 (scoreSaver.stamina, rts.rect.height);

		BlackPearls.text = (blackpearls/2).ToString();

		RectTransform rtb = bossHPBar.GetComponent<RectTransform>();
        rtb.sizeDelta = new Vector2 (scoreSaver.bossHP, rt.rect.height);

		if(scoreSaver.health <= 0){
			defeated = true;
		}

		if(scoreSaver.health <= 50.0f){
			BackgroundSound.GetComponent<AudioSource>().volume = 0.0f;
			lowHealthSound.GetComponent<AudioSource>().volume = 1.0f;
		}

		if(scoreSaver.health >= 50.0f){
			BackgroundSound.GetComponent<AudioSource>().volume = 1.0f;
			lowHealthSound.GetComponent<AudioSource>().volume = 0.0f;
		}

		if(defeated){
			defeatedUI.SetActive(true);	
		}
		if(cleared){
			clearedUI.SetActive(true);
		}

		if(bloodSplatDarkActive){
			bloodSplatDark.SetActive(true);
		}
		else{
			bloodSplatDark.SetActive(false);
		}
		if(bloodSplatLightActive){
			bloodSplatLight.SetActive(true);
		}
		else {
			bloodSplatLight.SetActive(false);
		}

	
	}
	 void OnTriggerEnter2D(Collider2D col)
    {
		bossHPUI.SetActive(true);
		bossHPBar.SetActive(true);
	}
}
