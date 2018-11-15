using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using BayatGames.SaveGamePro;
using PathologicalGames;
///这是一个管理当前关卡游戏的脚本
public class GameManager : MonoBehaviour
{
	public static List<Monster> monsterArray = new List<Monster>();
	private List<GameObject> _monsterArray = new List<GameObject>();

	public static GameObject _player;
	[SerializeField]
	protected static GameObject over;

	private SpawnPool NotePool;
	private PrefabPool pool_singleNote;
	private PrefabPool beamsone_1;
	private PrefabPool beamstwo_1;

	public GameObject SD4;
	public GameObject SD5;


	void Awake()
	{
		assetload();
		Initialize();
		pool_Initialize();

		InputManager.Input_initialize();

	}
	void Start()
	{
		over.SetActive(false);
	}

	//游戏结束时调用此方法
	public static void GameEnd(){
		Time.timeScale = 0;
		over.SetActive(true);
	
	}

	private void assetload()
	{
		/*MusicInstruments tool = new MusicInstruments();
		tool.MI_Add(SD4);
		tool.MI_Add(SD5);*/

		AssetBundle _notetest = AssetBundle.LoadFromFile("AssetBundles/notetest");
		GameObject[] notearry = _notetest.LoadAllAssets<GameObject>();
		MusicNote _note = new MusicNote();
		foreach (GameObject c in notearry)
		{
			_note.MN_Add(c);
		}

		AssetBundle _tooltest = AssetBundle.LoadFromFile("AssetBundles/toolstest");
		GameObject[] toolarry = _tooltest.LoadAllAssets<GameObject>();
		MusicInstruments _tools = new MusicInstruments();
		foreach (GameObject c in toolarry)
		{
			_tools.MI_Add(c);
		}

	}

	//关卡初始化
	private void Initialize()
	{
		_monsterArray.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
		/*for (int i = 0; i < _monsterArray.Count; i++)
		{
			monsterArray.Add(_monsterArray[i].GetComponent<Monster>());
		}*/

		foreach (GameObject m in _monsterArray)
		{
			monsterArray.Add(m.GetComponent<Monster>());
		}

		_player = GameObject.FindWithTag("Player");
		over = GameObject.Find("game over");
	}


	private void pool_Initialize()
	{
		NotePool = PoolManager.Pools.Create("MusicNote", this.gameObject);
		NotePool.dontDestroyOnLoad = true;

		pool_singleNote = new PrefabPool(PlayerCollection.PlayerNoteCollection["singleOne"].transform);
		pool_singleNote.preloadAmount = 5;
		pool_singleNote.cullDespawned = true;
		pool_singleNote.cullAbove = 20;
		pool_singleNote.cullDelay = 10;
		NotePool.CreatePrefabPool(pool_singleNote);

		pool_singleNote = new PrefabPool(PlayerCollection.PlayerNoteCollection["singleTwo"].transform);
		pool_singleNote.preloadAmount = 5;
		pool_singleNote.cullDespawned = true;
		pool_singleNote.cullAbove = 20;
		pool_singleNote.cullDelay = 10;
		NotePool.CreatePrefabPool(pool_singleNote);

		beamsone_1 = new PrefabPool(PlayerCollection.PlayerNoteCollection["beamOne_1"].transform);
		beamsone_1.preloadAmount = 10;
		beamsone_1.cullDespawned = true;
		beamsone_1.cullAbove = 20;
		beamsone_1.cullDelay = 10;
		NotePool.CreatePrefabPool(beamsone_1);

		beamstwo_1 = new PrefabPool(PlayerCollection.PlayerNoteCollection["beamTwo_1"].transform);
		beamstwo_1.preloadAmount = 10;
		beamstwo_1.cullDespawned = true;
		beamstwo_1.cullAbove = 20;
		beamstwo_1.cullDelay = 10;
		NotePool.CreatePrefabPool(beamstwo_1);

	}

}
