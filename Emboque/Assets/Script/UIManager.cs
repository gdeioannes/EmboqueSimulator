using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Cloud.Analytics;


public class UIManager : MonoBehaviour {

	private bool soundFlag=true;
	public bool UIflag=false;
	
	public GameObject canvasUI;
	public GameObject winUI;
	public GameObject looseUI;
	public GameObject addBtnUI;
	public GameObject loadingUI;
	public GameObject collectUI;
	public GameObject endUI;
	public GameObject PanelInfo;
	public GameObject retoInfo;
	public GameObject retoPanel;
	public GameObject isntructionsUI;

	public GameObject particleWhiteStar;
	public GameObject particleRedStar;
	public GameObject particleBlueStar;

	public GameObject particleCopihue;

	public static UIManager Instance;

	void Awake(){
		if(Instance==null){
			Instance=this;
		}
	}




	public void SoundToggle(Image image){
		if(soundFlag){
			image.color=Color.black;
			soundFlag=false;
			AudioListener.volume = 0f;
		}else{
			image.color=Color.red;
			soundFlag=true;
			AudioListener.volume = 1f;
		}
	}

	public void toggleUI(GameObject menu){
		if(menu.activeSelf){
			menu.SetActive(false);
			PanelInfo.SetActive(true);
			UIflag=false;
			InputForce.Instance.setKinematicCuerpo(false);
			canvasHide();	
		}else{
			canvasShow();
			menu.SetActive(true);
			PanelInfo.SetActive(false);
			UIflag=true;
			InputForce.Instance.setKinematicCuerpo(true);


			
			print ("Send Events Data");

		}
	}


	public void showLoadingUI(){
		loadingUI.SetActive(true);
		UIflag=true;
		canvasShow();
		instructionsHide();
	}

	public void hideLoadingUI(){
		loadingUI.SetActive(false);
		UIflag=false;
		canvasHide();
		instructionsShow();
	}

	public void skipBtn(){
		loadingUI.SetActive(false);
		looseUI.SetActive(true);
		instructionsHide();
		AdvertisementTest.Instance.setShowAddFlagFalse();
		UIflag=false;
		canvasShow();
	}

	public void showCollectUI(){
		collectUI.SetActive(true);
		hideLooseUI();
		UIflag=true;
		canvasShow();
		instructionsHide();
	}

	public void hideCollectUI(){
		PanelInfo.SetActive(true);
		collectUI.SetActive(false);
		looseUI.SetActive(false);
		UIflag=false;
		InputForce.Instance.addMoreTrys(5);
		canvasHide();
		instructionsShow();
	}

	
	public void retoUI(){
		if(retoPanel.activeSelf){
			retoPanel.SetActive(false);
			PanelInfo.SetActive(true);
			UIflag=false;
			InputForce.Instance.setKinematicCuerpo(false);
			canvasHide();
			instructionsShow();
		}else{
			canvasShow();
			PanelInfo.SetActive(false);
			retoPanel.SetActive(true);
			UIflag=true;
			InputForce.Instance.setKinematicCuerpo(true);
			instructionsHide();
			SoundManager.Instance.playLooseSound();
		}
	}

	public void refreshScene(){
		Application.LoadLevel (0);
	}

	public void nextStage(GameObject panel){
		panel.SetActive(false);
		InputForce.Instance.resetMarkers();
		PanelInfo.SetActive(true);
		UIflag=false;
		instructionsShow();
		canvasHide();
	}

	public void sameStage(GameObject panel){
		panel.SetActive(false);
		InputForce.Instance.resetMarkers();
		PanelInfo.SetActive(true);
		UIflag=false;
		canvasHide();
		instructionsShow();
	}

	public void showWinUI(){
		winUI.SetActive(true);
		PanelInfo.SetActive(false);
		UIflag=true;
		canvasShow();
		instructionsHide();
	}

	public void showLooseUI(){
		looseUI.SetActive(true);
		PanelInfo.SetActive(false);
		addBtnUI.SetActive(AdvertisementTest.Instance.showAddFlag);
		UIflag=true;
		canvasShow();
		instructionsHide();
	}

	public void hideLooseUI(){
		looseUI.SetActive(false);
		PanelInfo.SetActive(false);
		UIflag=false;
		canvasHide();
		instructionsShow();
	}
	

	public void showEndUI(){
		endUI.SetActive(true);
		PanelInfo.SetActive(false);
		UIflag=true;
		activateCopihueParticles();
		canvasShow();
		instructionsHide();
	}

	public void resetChallenges(){
		InputForce.Instance.resetStageCount();
		endUI.SetActive(false);
		PanelInfo.SetActive(true);
		UIflag=false;
		canvasHide();
		instructionsShow();
	}


	public void changeRetoText(int challengeNumber){
		retoInfo.GetComponent<Text>().text="Reto "+challengeNumber;
	}

	public void activateParticles(){
		particleBlueStar.GetComponent<ParticleSystem>().Play();
		particleRedStar.GetComponent<ParticleSystem>().Play();
		particleWhiteStar.GetComponent<ParticleSystem>().Play();

	}

	public void activateCopihueParticles(){
		particleCopihue.GetComponent<ParticleSystem>().Play();
	}

	
	public void canvasHide(){
		canvasUI.GetComponent<Image>().color=new Color32(0,0,0,0);
	}
	
	public void canvasShow(){
		canvasUI.GetComponent<Image>().color=new Color32(0,0,0,120);

	}

	public void instructionsShow(){
		isntructionsUI.SetActive(true);


	}

	public void instructionsHide(){
		isntructionsUI.SetActive(false);
	}

	public void animatePanelInfo(){
		PanelInfo.SetActive(false);
		PanelInfo.SetActive(true);
	}

}
