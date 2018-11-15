using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
///这是一个乐器的基类
public class MusicInstruments : MonoBehaviour {

	public string Name;
	protected byte MI_Type;    //乐器类型       
	protected byte MI_Tone;     //音色  
	public char m_needClef;           //所需谱号
	public float MI_basicHurt;        //基础伤害值
	public bool _IsAwake;

	protected float LastTime = 0;
	//protected float nextTime = 0;
	protected int BeamsNumber;
	protected Transform lastNote;
	protected KeyCode lastKey;

	public MusicInstruments(){
	}

	public MusicInstruments(string name, byte type, byte tone, float basichurt){
		Name = name;
		MI_Type = type;
		MI_Tone = tone;
		MI_basicHurt = basichurt;
	}

	//音符实例化方法
	public Transform InitializationNote(GameObject Note, Transform po) {
		if (!PoolManager.Pools.ContainsKey("MusicNote"))
		{
			PoolManager.Pools.Create ("MusicNote");
		}

		lastNote = PoolManager.Pools ["MusicNote"].Spawn (Note, po.position, Quaternion.identity);
		return lastNote;
	}
	//这是更换乐器的方法
	public void SwitchTool(string number){
		if (PlayerCollection.PlayerInstrumentsCollection.ContainsKey(number))
		{
			PlayerAction.currentTool = GameObject.FindWithTag("Tool");
			Destroy(GameObject.FindWithTag("Tool"));

			GameObject nextTool = Instantiate(PlayerCollection.PlayerInstrumentsCollection[number], PlayerAction.currentTool.transform.position, Quaternion.identity);
			nextTool.transform.SetParent(GameManager._player.transform);
			List<string> test = new List<string>(PlayerCollection.PlayerNoteCollection.Keys);
			for (int i = 0; i < test.Count; i++)
			{
				PlayerCollection.PlayerNoteCollection[test[i]].GetComponent<MusicNote>().MN_Tone = nextTool.GetComponent<MusicInstruments>().MI_Tone;
				PlayerCollection.PlayerNoteCollection[test[i]].GetComponent<MusicNote>().MN_Type = nextTool.GetComponent<MusicInstruments>().MI_Type;
				PlayerCollection.PlayerNoteCollection[test[i]].GetComponent<MusicNote>().MN_Hurts = nextTool.GetComponent<MusicInstruments>().MI_basicHurt;
			}
		}
		else
		{
			Debug.Log("没有该乐器");
		}
	}
	//这是一个添加乐器的方法，当玩家获得乐器时调用这个方法
	public void MI_Add(GameObject tools){
		if(!PlayerCollection.PlayerInstrumentsCollection.ContainsKey(tools.GetComponent<MusicInstruments>().Name)){
			PlayerCollection.PlayerInstrumentsCollection.Add(tools.GetComponent<MusicInstruments>().Name, tools);
		}
	}

	protected bool IsBeamsNotes(KeyCode l)
	{
		if (Time.time - LastTime < 0.5f && lastKey == l)
		{
			BeamsNumber += 1;
			LastTime = Time.time;
			return true;
		}
		lastKey = l;
		LastTime = Time.time;
		BeamsNumber = 1;
		//Debug.Log(BeamsNumber);
		return false;
	}

	protected byte _switchKeycode()
	{
		byte i = 99;
		if (Input.GetKeyDown(InputManager.Key_note_1))
		{
			if (IsBeamsNotes(InputManager.Key_note_1))
			{
				i = 12;
			}
			else
			{
				i = 1;
			}
			Debug.Log(i);

		}
		if (Input.GetKeyDown(InputManager.Key_note_2))
		{
			if (IsBeamsNotes(InputManager.Key_note_2))
			{
				i = 22;
			}
			else
			{
				i = 2;
			}
			Debug.Log(i);
		}
		if (Input.GetKeyDown(InputManager.Key_note_3))
		{
			if (IsBeamsNotes(InputManager.Key_note_3))
			{
				i = 32;
			}
			else
			{
				i = 3;
			}
		}
		if (Input.GetKeyDown(InputManager.Key_note_4))
		{
			if (IsBeamsNotes(InputManager.Key_note_4))
			{
				i = 42;
			}
			else
			{
				i = 4;
			}
		}
		return i;
	}
}
	
public interface IToolDerived{
	void OtherPower ();
		//乐器其他的能力，比如“飞”。
}