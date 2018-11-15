using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFileContext : BaseContext {
	public GameFileContext() : base(UIType.MainMenu){
		
	}
}


public class GameFileView : AnimateView{
	[SerializeField]
	private Button _buttonLoadGmaeFile;
	[SerializeField]
	private Button _buttonDeleteGmaeFile;
}
