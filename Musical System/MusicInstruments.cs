using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
//这是一个乐器的基类
public class MusicInstruments : MonoBehaviour {

	public string Name;
	public byte m_Type;    //乐器类型       
	public byte m_Tone;     //音色  
	public char m_needClef;           //所需谱号
	public float m_basicHurt;        //基础伤害值

	public MusicInstruments(){
	}

	public MusicInstruments(string name, byte type, byte tone, float basichurt){
		Name = name;
		m_Type = type;   
		m_Tone = tone;
		m_basicHurt = basichurt;
	}
	//音符实例化方法
	public void InitializationNote(GameObject Note, Transform po) {
		if (!PoolManager.Pools.ContainsKey("MusicNotePool"))
		{
			PoolManager.Pools.Create ("MusicNotePool");
		}
			
		PoolManager.Pools ["MusicNotePool"].Spawn (Note, po.position, Quaternion.identity);
	}
	//这是更换乐器的方法
	public void SwitchTool(string number){
		if(PlayerCollection.InstrumentsCollection.ContainsKey(number)){
			GameObject player = GameObject.FindWithTag ("Player");
			PlayerAction.currentTool =  GameObject.FindWithTag ("Tool");
			Destroy (GameObject.FindWithTag ("Tool"));

			GameObject nextTool = Instantiate (PlayerCollection.InstrumentsCollection [number], PlayerAction.currentTool.transform.position, Quaternion.identity);
			nextTool.transform.SetParent (player.transform);
			List<string> test = new List<string>(PlayerCollection.noteCollection.Keys);
			for (int i = 0; i < test.Count; i++)
			{
				PlayerCollection.noteCollection [test [i]].GetComponent<MusicNote> ().n_Tone = nextTool.GetComponent<MusicInstruments> ().m_Tone;
				PlayerCollection.noteCollection [test [i]].GetComponent<MusicNote> ().n_Type = nextTool.GetComponent<MusicInstruments> ().m_Type;
				PlayerCollection.noteCollection [test [i]].GetComponent<MusicNote> ().Hurts = nextTool.GetComponent<MusicInstruments> ().m_basicHurt;
			}
		}
	}
	//这是一个添加乐器的方法，当玩家获得乐器时调用这个方法
	public void T_Add(GameObject tools){
		if(!PlayerCollection.InstrumentsCollection.ContainsKey(tools.GetComponent<MusicInstruments>().Name)){
			PlayerCollection.InstrumentsCollection.Add (tools.GetComponent<MusicInstruments>().Name, tools);
		}
	}

}
	
public interface IToolDerived{
	void OtherPower ();
		//乐器其他的能力，比如“起飞”，在没有怪物时可能会调用这个方法
}