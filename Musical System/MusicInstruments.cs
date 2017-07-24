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
	//在乐符飞出之前给乐符的tybes and tones赋值
	public void InitializationNote(GameObject Note, Transform po) {
		Note.GetComponent<MusicNote> ().n_Type = m_Type;
		Note.GetComponent<MusicNote> ().n_Tone = m_Tone;
		Note.GetComponent<MusicNote> ().Hurts = m_basicHurt;
		if (!PoolManager.Pools.ContainsKey("MusicNotePool"))
		{
			Instantiate (Note);
		}
			
		PoolManager.Pools ["MusicNotePool"].Spawn (Note, po.position, Quaternion.identity);
	}

}
	
public interface IToolDerived{
	void OtherPower ();
		//乐器其他的能力，比如“起飞”，在没有怪物时可能会调用这个方法
}