using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo01SingleUIManager : MonoBehaviour
{

	public static GameObject menu;

	public Button toolsswitch;

	void Awake()
	{
		menu = GameObject.Find("pause menu");

	}
	void Start()
	{
		toolsswitch.onClick.AddListener(_toolSwitch);
		menu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (menu.activeInHierarchy == false)
			{
				menu.SetActive(true);
				Time.timeScale = 0;
			}
			else if (menu.activeInHierarchy == true)
			{
				menu.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}

	public void _toolSwitch()
	{

	}
}
