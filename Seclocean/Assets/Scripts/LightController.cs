using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {


	  public int lightFactor = 0;
	  public Light controlledLight01 = null;
	  public Light controlledLight02 = null;

	  public int blueLightKillsNeeded;
	  public int redLightKillsNeeded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 if(controlledLight01!=null) { // If we have a light as a field
             Light l = controlledLight01.GetComponent<Light>(); // Get the Light component
			 Light l2 = controlledLight02.GetComponent<Light>(); 
             Color c1 = Color.red;
			 Color c2 = Color.blue;
			 Color c3 = Color.yellow;
             //c.r= 1f - lightFactor / 100f;
             //c.g= lightFactor / 100f;
             //c.b= lightFactor / 100f;
             

			if(scoreSaver.kills < blueLightKillsNeeded){
				c3.a=0.5f;
             	l.color = c3;
				l2.color = c3;
				scoreSaver.blueLight = false;
				scoreSaver.yellowLight = true;
				scoreSaver.redLight = false;
			}
			else if ((scoreSaver.kills >= blueLightKillsNeeded) && (scoreSaver.kills <redLightKillsNeeded)){
				c2.a=0.5f;
				l.color = c2;
				l2.color = c2;
				scoreSaver.blueLight = true;
				scoreSaver.yellowLight = true;
				scoreSaver.redLight = false;
			}
			else if (scoreSaver.kills >= redLightKillsNeeded){
				c1.a=0.5f;
				l.color = c1;
				l2.color = c1;

				scoreSaver.blueLight = true;
				scoreSaver.yellowLight = true;
				scoreSaver.redLight = true;
			}
         }
	}
}
