using System;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdvertisementTest : MonoBehaviour {


	
	
	public static AdvertisementTest Instance;
	private bool resultBool;
	public bool showAddFlag=false;
	private bool generateAddFlag=false;

	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.Initialize ("76235");
			Instance=this;
		} else {
			Debug.Log("Platform not supported");
		}
	}

	public void Update(){
		generateAdd();
		showAdd();

	}

	public void setShowAddFlag(){
		generateAddFlag=true;
	}

	public void setShowAddFlagFalse(){
		generateAddFlag=false;
	}
	
	public void showAdd(){

		//if(GUI.Button(new Rect(10, 10, 150, 50), Advertisement.IsReady() ? "Show Ad" : "Waiting...")) {
		if(Advertisement.IsReady()) {
			showAddFlag=true;
		}else{
			showAddFlag=false;
		}
			

	}

	public void generateAdd(){
		// Show with default zone, pause engine and print result to debug log
		if(generateAddFlag){
			Advertisement.Show(null, new ShowOptions {
				resultCallback = result => {
					UIManager.Instance.hideLoadingUI();
					switch(result)
					{
					case (ShowResult.Finished):
						resultBool = true;
						UIManager.Instance.showCollectUI();
						break;
					case (ShowResult.Failed):
						resultBool = false;
						UIManager.Instance.showCollectUI();
						break;
					case(ShowResult.Skipped):
						resultBool = false;
						UIManager.Instance.showLooseUI();
						break;
					}
					generateAddFlag=false;

					
				}
			});
		}
	}
}