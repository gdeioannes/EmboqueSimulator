using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	void Awake(){
		if(Instance==null){
			Instance=this;
		}
	}

	// Use this for initialization
	void Start () {
	}

	public void playWoodSound(){
		this.GetComponents<AudioSource>()[0].Play();
	}

	public void playEmboqueSound(){
		this.GetComponents<AudioSource>()[1].Play();
	}

	public void playGiroSound(){
		this.GetComponents<AudioSource>()[2].Play();
	}

	public void playNextStageSound(){
		this.GetComponents<AudioSource>()[3].Play();
	}

	public void playLooseSound(){
		this.GetComponents<AudioSource>()[4].Play();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
