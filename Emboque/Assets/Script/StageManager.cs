using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

	public List<Stage> stageList=new List<Stage>();
	public static StageManager Instance {get; private set;}


	void Awake(){
		if(Instance==null){
			Instance=this;
		}
		stageList.Add(new Stage(20,1,0));
		stageList.Add(new Stage(15,2,0));
		stageList.Add(new Stage(12,3,0));
		stageList.Add(new Stage(10,2,1));
		stageList.Add(new Stage(8,3,1));
		stageList.Add(new Stage(8,2,2));
		stageList.Add(new Stage(6,1,1));
		stageList.Add(new Stage(6,2,1));
		stageList.Add(new Stage(5,1,2));
		stageList.Add(new Stage(5,2,2));
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
