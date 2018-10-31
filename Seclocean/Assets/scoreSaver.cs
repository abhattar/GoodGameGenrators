using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSaver : MonoBehaviour {

	public static int health = 65;
	public static int kills;
	public static int blackpearls;

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

		BlackPearls.text = blackpearls.ToString();

	}
}
