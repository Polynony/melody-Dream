using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectMenuContext : BaseContext
{
	public SelectMenuContext() : base(UIType.MainMenu)
	{

	}
}
public class SelectMenuView : AnimateView
{

	[SerializeField]
	private Button _buttonLoadGmae;
	[SerializeField]
	private Button _buttonFirst;
	[SerializeField]
	private Button _buttonSecond;

	void Awake()
	{
		_buttonFirst.onClick.AddListener(FirstcallBack);
		_buttonSecond.onClick.AddListener(SecondCallBack);
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

	public void FirstcallBack()
	{
		SceneManager.LoadScene("Demo_01");
	}

	public void SecondCallBack()
	{
		SceneManager.LoadScene("chapter 1 level 2");
	}
}
