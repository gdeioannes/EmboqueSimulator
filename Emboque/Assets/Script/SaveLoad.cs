using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {

	public static GameData savedGame;
	public static SaveLoad Instance;

	void Awake(){
		if(Instance==null){
			Instance=this;
		}
	}

	//it's static so we can call it from anywhere
	public static void Save() {
		SaveLoad.savedGame=GameData.Instance;
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedGame);
		file.Close();

	}   
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.savedGame = (GameData)bf.Deserialize(file);
			file.Close();
		}
	}
}
