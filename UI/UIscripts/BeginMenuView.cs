using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginMenuContext : BaseContext
{
	public BeginMenuContext() : base(UIType.MainMenu)
	{

	}
}

public class BeginMenuView : AnimateView
{

	[SerializeField]
	private Button _buttonPlay;
	[SerializeField]
	private Button _buttonExit;

	void Awake()
	{
		_buttonPlay.onClick.AddListener(PlayCallBack);
		_buttonExit.onClick.AddListener(ExitkcallBack);
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

	public void ExitkcallBack()
	{
		Application.Quit();
	}

	public void PlayCallBack()
	{
		SceneManager.LoadScene("Level Select Scene");
	}

}
