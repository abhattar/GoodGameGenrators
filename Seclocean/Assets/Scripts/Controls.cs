using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public GameObject sideAngie;
	public GameObject topAngie;

	public Camera Layer1Cam;

	public Camera TopLayerCam;





	// Use this for initialization
	void Start () {
		Layer1Cam.enabled = true;
		TopLayerCam.enabled = false;
		scoreSaver.activeAngie = sideAngie;
		topAngie.SetActive(false);
		sideAngie.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if(scoreSaver.layerKind != null){
				if(scoreSaver.layerKind == "Side"){
					Layer1Cam.enabled = false;
					TopLayerCam.enabled = true;	
					topAngie.SetActive(true);
					scoreSaver.activeAngie = topAngie;
					if(scoreSaver.inLayer == 1){
						topAngie.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer1Ytop);
						TopLayerCam.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer1Ytop);
					}
					else if(scoreSaver.inLayer == 2){
						topAngie.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer2Ytop);
						TopLayerCam.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer2Ytop);
					}
					else if(scoreSaver.inLayer == 3){
						topAngie.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer3Ytop);
						TopLayerCam.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer3Ytop);
					}
					else if(scoreSaver.inLayer == 4){
						topAngie.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer4Ytop);
						TopLayerCam.transform.position = new Vector3(sideAngie.transform.position.x, scoreSaver.layer4Ytop);
					}
					
					sideAngie.SetActive(false);

					
				}
				if(scoreSaver.layerKind == "Top"){
						Layer1Cam.enabled = true;
						TopLayerCam.enabled = false;
					if(scoreSaver.inLayer == 1){
						sideAngie.SetActive(true);
						scoreSaver.activeAngie = sideAngie;
						sideAngie.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer1Yside);
						Layer1Cam.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer1Yside);
						topAngie.SetActive(false);	
					}
					else if(scoreSaver.inLayer == 2){
						sideAngie.SetActive(true);
						scoreSaver.activeAngie = sideAngie;
						sideAngie.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer2Yside);
						Layer1Cam.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer2Yside);
						topAngie.SetActive(false);	
					}
					else if(scoreSaver.inLayer == 3){
						sideAngie.SetActive(true);
						scoreSaver.activeAngie = sideAngie;
						sideAngie.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer3Yside);
						Layer1Cam.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer3Yside);
						topAngie.SetActive(false);	
					}
					else if(scoreSaver.inLayer == 4){
						sideAngie.SetActive(true);
						scoreSaver.activeAngie = sideAngie;
						sideAngie.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer4Yside);
						Layer1Cam.transform.position = new Vector3(topAngie.transform.position.x, scoreSaver.layer4Yside);
						topAngie.SetActive(false);	
					}	
				}

				if(scoreSaver.layerKind == "TopPortal" || scoreSaver.layerKind == "SidePortal"){
					if(scoreSaver.layerKind == "TopPortal"){
						Layer1Cam.enabled = true;
						TopLayerCam.enabled = false;

						sideAngie.SetActive(true);
						scoreSaver.activeAngie = sideAngie;
						if(scoreSaver.inLayer == 1){
							scoreSaver.activeAngie.transform.position = new Vector3(scoreSaver.portal1SideX,scoreSaver.portal1SideY);
							Layer1Cam.transform.position = new Vector3(scoreSaver.portal1SideX,scoreSaver.portal1SideY);
						}
						else if(scoreSaver.inLayer ==2){
							scoreSaver.activeAngie.transform.position = new Vector3(scoreSaver.portal2SideX,scoreSaver.portal2SideY);
							Layer1Cam.transform.position = new Vector3(scoreSaver.portal2SideX,scoreSaver.portal2SideY);
						}
						topAngie.SetActive(false);	
					}
					else if(scoreSaver.layerKind == "SidePortal"){
						Layer1Cam.enabled = false;
						TopLayerCam.enabled = true;

						topAngie.SetActive(true);
						scoreSaver.activeAngie = topAngie;
						if(scoreSaver.inLayer == 1){
							scoreSaver.activeAngie.transform.position = new Vector3(scoreSaver.portal1TopX,scoreSaver.portal1TopY);
							TopLayerCam.transform.position = new Vector3(scoreSaver.portal1TopX,scoreSaver.portal1TopY);
						}
						else if(scoreSaver.inLayer == 2){
							scoreSaver.activeAngie.transform.position = new Vector3(scoreSaver.portal2TopX,scoreSaver.portal2TopY);
							TopLayerCam.transform.position = new Vector3(scoreSaver.portal2TopX,scoreSaver.portal2TopY);
						}
						sideAngie.SetActive(false);	
					}

				}
			}
        }


	}

}
