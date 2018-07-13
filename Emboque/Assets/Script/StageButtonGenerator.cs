using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StageButtonGenerator : MonoBehaviour
{

	public GameObject button;
	private float space = 0;
	private float heigthUnit = Screen.height / 20;
	private List<GameObject> buttonList = new List<GameObject> ();
	public static StageButtonGenerator Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	// Use this for initialization
	void Start ()
	{
		space = 1.1f * heigthUnit;
		int stageNum = (StageManager.Instance.stageList.Count);
		print (stageNum);
		//gameObject.GetComponent<RectTransform> ().position=new Vector2(0,(-150*stageNum)/2);
		gameObject.GetComponent<RectTransform> ().sizeDelta=new Vector2(758,85*stageNum);
		for (int num=0; num<stageNum; num++) {
			GameObject buttonClone = Instantiate (button) as GameObject;
			if (num <= GameData.Instance.higestStage) {
				buttonClone.GetComponent<StageButton> ().stagePass = true;
				buttonClone.GetComponent<StageButton> ().paintText ();
				buttonClone.GetComponent<Text> ().text = "Reto " + (num + 1);
			} else {
				buttonClone.GetComponent<StageButton> ().stagePass = false;
				buttonClone.GetComponent<StageButton> ().paintText ();
				buttonClone.GetComponent<Text> ().text = "Reto " + (num + 1);
			}
			buttonClone.transform.parent = this.transform;
			buttonClone.GetComponent<RectTransform> ().position = new Vector2 (Screen.width / 2, Screen.height - (heigthUnit * 5) - (space * num));
			buttonClone.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);

			
			buttonClone.GetComponent<StageButton> ().stageNum = num;
			buttonList.Add (buttonClone);
		}
	}

	public void repaintButtons ()
	{
		for (int num=0; num<buttonList.Count; num++) {
			if (buttonList [num].GetComponent<StageButton> ().stageNum <= GameData.Instance.higestStage) {
				buttonList [num].GetComponent<StageButton> ().stagePass = true;
				buttonList [num].GetComponent<Text> ().text = "Reto " + (buttonList [num].GetComponent<StageButton> ().stageNum + 1);
			}
			buttonList [num].GetComponent<StageButton> ().paintText ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
