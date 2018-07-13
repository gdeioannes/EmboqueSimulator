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
		/*stageList.Add(new Stage(20,1,0));
		stageList.Add(new Stage(15,2,0));
		stageList.Add(new Stage(14,3,0));
		stageList.Add(new Stage(12,2,1));
		stageList.Add(new Stage(10,3,1));
		stageList.Add(new Stage(8,2,2));
		stageList.Add(new Stage(8,3,2));
		stageList.Add(new Stage(8,2,3));
		stageList.Add(new Stage(7,3,3));
		stageList.Add(new Stage(7,4,2));*/

		stageList.Add(new Stage(30,1,0));	
		stageList.Add(new Stage(10,1,0));	
		stageList.Add(new Stage(5,1,0));	
		stageList.Add(new Stage(30,0,1));	
		stageList.Add(new Stage(10,0,1));	
		stageList.Add(new Stage(5,0,1));	
		stageList.Add(new Stage(30,1,1));	
		stageList.Add(new Stage(25,2,1));	
		stageList.Add(new Stage(20,3,1));	
		stageList.Add(new Stage(18,3,2));	
		stageList.Add(new Stage(16,3,3));	
		stageList.Add(new Stage(14,4,3));	
		stageList.Add(new Stage(12,3,4));	
		stageList.Add(new Stage(12,3,4));	
		stageList.Add(new Stage(10,3,3));	
		stageList.Add(new Stage(10,4,3));	
		stageList.Add(new Stage(8,2,4));	
		stageList.Add(new Stage(8,3,3));	
		stageList.Add(new Stage(6,2,3));	
		stageList.Add(new Stage(5,2,3));	

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
