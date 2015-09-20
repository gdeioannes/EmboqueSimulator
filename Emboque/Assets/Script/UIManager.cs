using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	private bool soundFlag=true;
	public bool UIflag=false;

	public GameObject winUI;
	public GameObject looseUI;
	public GameObject endUI;
	public GameObject PanelInfo;
	public GameObject retoInfo;
	public GameObject retoPanel;

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
		}else{

			menu.SetActive(true);
			PanelInfo.SetActive(false);
			UIflag=true;
			InputForce.Instance.setKinematicCuerpo(true);
		}
	}

	public void retoUI(){
		if(retoPanel.activeSelf){
			retoPanel.SetActive(false);
			PanelInfo.SetActive(true);
			UIflag=false;
			InputForce.Instance.setKinematicCuerpo(false);
		}else{

			PanelInfo.SetActive(false);
			retoPanel.SetActive(true);
			UIflag=true;
			InputForce.Instance.setKinematicCuerpo(true);
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
	}

	public void sameStage(GameObject panel){
		panel.SetActive(false);
		InputForce.Instance.resetMarkers();
		PanelInfo.SetActive(true);
		UIflag=false;
	}

	public void showWinUI(){
		winUI.SetActive(true);
		PanelInfo.SetActive(false);
		UIflag=true;
	}

	public void showLooseUI(){
		looseUI.SetActive(true);
		PanelInfo.SetActive(false);
		UIflag=true;
	}

	public void showEndUI(){
		endUI.SetActive(true);
		PanelInfo.SetActive(false);
		UIflag=true;
		activateCopihueParticles();
	}

	public void resetChallenges(){
		InputForce.Instance.resetStageCount();
		endUI.SetActive(false);
		PanelInfo.SetActive(true);
		UIflag=false;
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

}
