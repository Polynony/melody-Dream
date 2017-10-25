using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class SaveManager {
	protected static string filePath =Application.dataPath + @"/Resources/SaveData.json";

	public static void DoSave(){
		//新实例
		PlayerData hea = new PlayerData ();
		PlayerCollection dic = new PlayerCollection ();

		FileInfo file = new FileInfo (filePath);
		StreamWriter SW = file.CreateText ();
		//数据初始化
		hea._Position = GameObject.FindWithTag ("Player").transform.position;
		hea.Health = 100;
		//string[] keysArray = dic.KeysArray (PlayerCollection.noteCollection);
		//GameObject[] valuesArray = dic.ValuesArray (PlayerCollection.noteCollection);
		//json 序列化
		string dics = JsonConvert.SerializeObject(dic);
		//string dics = JsonUtility.ToJson (keysArray);
		//string dicss = JsonUtility.ToJson (valuesArray);
		string heas = JsonUtility.ToJson (hea);
		//流写进文件
		Debug.Log (heas);
		//Debug.Log (dicss);
		SW.WriteLine (heas);
		SW.WriteLine (dics);
		SW.Close ();
		SW.Dispose ();
	}

	public static void DoLoad(){
		TextAsset s = Resources.Load("Settings/JsonBuilding") as TextAsset;  
		if (!s)  
			return;  

		string strData = s.text;  
	}

}
