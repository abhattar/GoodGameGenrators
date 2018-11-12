using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSaver : MonoBehaviour {

	public static int health = 65;
	public static int kills;
	public static int blackpearls;
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

	public static float portalTopX;

	public static float portalSideX;

	public static float portalTopY;

	public static float portalSideY;

	public static float angiePosX;

	public static string layerKind;

	public static GameObject activeAngie;

	public Text BlackPearls;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {

		blackpearls = 0;
		health = 65;
		kills = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		RectTransform rt = healthBar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (scoreSaver.health, rt.rect.height);

		BlackPearls.text = (blackpearls/2).ToString();
		print(inLayer);
		print(layerKind);
		

	}
}
