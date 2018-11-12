using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideLayer : MonoBehaviour {

	public int layerNumber;
	
	public string layerKind;
	

	// Use this for initialization
	void Start () {
		  if(layerKind == "Top"){
			  if(layerNumber == 1){
					scoreSaver.layer1Ytop = transform.position.y;
			  }
			  else if(layerNumber == 2){
					scoreSaver.layer2Ytop = transform.position.y; 
			  }
			  else if(layerNumber == 3){
				  	scoreSaver.layer3Ytop = transform.position.y; 
			  }
			  else if(layerNumber == 4){
				  	scoreSaver.layer4Ytop = transform.position.y; 
			  }
		  }

		  if(layerKind == "Side"){
			  if(layerNumber == 1){
					scoreSaver.layer1Yside = transform.position.y; 
			  }
			  else if(layerNumber == 2){
					scoreSaver.layer2Yside = transform.position.y; 
			  }
			  else if(layerNumber == 3){
				  	scoreSaver.layer3Yside = transform.position.y; 
			  }
			  else if(layerNumber == 4){
				  	scoreSaver.layer4Yside = transform.position.y; 
			  }
		  }


			if(layerKind == "TopPortal"){
				if(layerNumber == 1){
					scoreSaver.portal1TopX = transform.position.x;
				  	scoreSaver.portal1TopY = transform.position.y;
				}
				else if(layerNumber == 2){
					scoreSaver.portal2TopX = transform.position.x;
				  	scoreSaver.portal2TopY = transform.position.y;
				}
			}
			if(layerKind == "SidePortal"){
				if(layerNumber == 1){
					scoreSaver.portal1SideX = transform.position.x;
					scoreSaver.portal1SideY = transform.position.y;
				}
				if(layerNumber == 2){
					scoreSaver.portal2SideX = transform.position.x;
					scoreSaver.portal2SideY = transform.position.y;
				}
			}
		 
		  
		  
	}
	
	// Update is called once per frame
	void Update () {
		   
	}


	void OnTriggerStay2D(Collider2D col)
    {
			
               if (col.tag == scoreSaver.activeAngie.tag){
				   scoreSaver.inLayer = layerNumber;
				   scoreSaver.angiePosX = col.transform.position.x;
				   scoreSaver.layerKind = layerKind;
				   print(layerKind);
				   if(layerKind == "SidePortal" || layerKind == "TopPoral"){
					   scoreSaver.inPortal = layerKind;
					   
				   }
				 
				// print(layerNumber);
				// print(layerKind);
			   }
               
    }
}
