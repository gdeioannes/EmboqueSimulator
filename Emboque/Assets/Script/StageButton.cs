using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageButton : MonoBehaviour {

	public int stageNum ;
	public bool stagePass=false ;
	private float count=0;
	private float countMax=3;
	private string saveText;
	private bool textFlag;

	// Use this for initialization
	void Start () {
		print(stageNum);

	}
	
	// Update is called once per frame
	void Update () {
		if(textFlag){
			count+=Time.deltaTime;
			if(count>countMax){
				textFlag=false;
				gameObject.GetComponent<Text>().text=saveText;
				count=0;
			}
		}

	}

	public void paintText(){
		if(!stagePass){
			gameObject.GetComponent<Text>().color=Color.red;
		}else{
			gameObject.GetComponent<Text>().color=Color.white;
		}
	}

	public void setStage(){
		if(stagePass){
			UIManager.Instance.UIflag=true;
			InputForce.Instance.starSpecificStage(stageNum);
			UIManager.Instance.retoUI();
		}else{
			saveText=gameObject.GetComponent<Text>().text;
			gameObject.GetComponent<Text>().text=gameObject.GetComponent<Text>().text+"/Gana El Reto Anterior";
			textFlag=true;
		}
	}
}
