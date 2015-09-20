using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public int higestStage=0;

	public static GameData Instance;

	void Awake(){
		if(Instance==null){
			Instance=this;
		}
		if(PlayerPrefs.GetInt("level")!=null){
			higestStage=PlayerPrefs.GetInt("level");
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public void setHigestStage(int stage){
		PlayerPrefs.SetInt("level",stage);
		higestStage=stage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
