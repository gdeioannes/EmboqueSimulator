using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Cloud.Analytics;

public class GameData : MonoBehaviour {

	public int higestStage=0;
	private string playerID; 

	public static GameData Instance;

	void Awake(){

		if(PlayerPrefs.GetString("Player_ID")==null){
			playerID=SystemInfo.deviceUniqueIdentifier;

			PlayerPrefs.SetString("Player_ID",playerID);
		}else{
			print ("deviceIdent:"+playerID);
			playerID=PlayerPrefs.GetString("Player_ID");
		}

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

		UnityAnalytics.CustomEvent("Challenge Data", new Dictionary<string, object>
		                           {
			{ "Player_ID ", playerID },
			{ "Challenge_Number ", stage }
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
