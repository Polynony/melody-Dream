using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class SaveManager {
	protected static string filePath =Application.dataPath + @"/Resources/SaveData.json";

	public static void DoSave(){

	}

	public static void DoLoad(){
		TextAsset s = Resources.Load("Settings/JsonBuilding") as TextAsset;  
		if (!s)  
			return;  

		string strData = s.text;  
	}

}
