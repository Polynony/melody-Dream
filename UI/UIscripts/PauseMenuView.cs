using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuContext : BaseContext{
	public PauseMenuContext() : base(UIType.MainMenu){

	}
}

public class PauseMenuView : AnimateView{

	[SerializeField]
	private Button _buttonBackGame;
	[SerializeField]
	private Button _buttonBacMainkMenu;
	[SerializeField]
	private Button _buttonSaveGame;
	[SerializeField]
	private Button _buttonLoadGame;

	void Awake()
	{
		_buttonBackGame.onClick.AddListener(BackcallBack);
		_buttonBacMainkMenu.onClick.AddListener(MainMenuCallBack);
	}


	public override void OnEnter(BaseContext context)
	{
		base.OnEnter(context);
	}

	public override void OnExit(BaseContext context)
	{
		base.OnExit(context);
	}

	public override void OnPause(BaseContext context)
	{
		_animator.SetTrigger("OnExit");
	}

	public override void OnResume(BaseContext context)
	{
		//_animator.SetTrigger("OnEnter");
	}

	public void SaveCallBack()
	{
		
	}

	public void LoadCallBack()
	{
		//Singleton<ContextManager>.Instance.Push(new HighScoreContext());
	}

	public void BackcallBack()
	{
		Demo01SingleUIManager.menu.SetActive(false);
		Time.timeScale = 1;
	}

	public void MainMenuCallBack()
	{
		SceneManager.LoadScene("Start The Game");
	}

}
