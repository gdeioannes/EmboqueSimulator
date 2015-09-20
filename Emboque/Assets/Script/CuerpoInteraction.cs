using UnityEngine;
using System.Collections;

public class CuerpoInteraction : MonoBehaviour {

	private float savePos=0;
	private bool soundFlag=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Mathf.Abs(Mathf.Abs(gameObject.transform.position.y)-savePos)>1){
			soundFlag=false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(!soundFlag){
			print("Wood");
			SoundManager.Instance.playWoodSound();
			savePos=Mathf.Abs(gameObject.transform.position.y);
			soundFlag=true;
		}

	}
}
