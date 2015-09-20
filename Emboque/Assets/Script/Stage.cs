using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public int intentos;
	public int emboques;
	public int giros;

	public Stage(int intentos,int emboques,int giros){
		this.intentos=intentos;
		this.emboques=emboques;
		this.giros=giros;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
