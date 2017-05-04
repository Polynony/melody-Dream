using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个乐器的基类
public class MusicInstruments : MonoBehaviour {

	public string Name;
	public int m_Type;             //乐器类型
	public int m_Tone;             //音色
	public char m_needClef;           //所需谱号
	public double m_basicHurt;        //基础伤害值

	public MusicInstruments(string name,int type,int tone,double basichurt){
		Name = name;
		m_Type = type;   
		m_Tone = tone;
		m_basicHurt = basichurt;
	}

	public void InstantiationNote(GameObject Note){
		//这是一个实例化乐符的方法，并在乐符飞出之前给乐符的tybes and tones赋值
	}

	public void OnCollisionEnter(Collision collision){
		//这是一个判断乐器是否被摧毁的方法，当与怪物碰撞时以极小概率销毁该乐器，并在销毁之前对玩家进行提示
	}
}
	
public interface IToolDerived{
	void OtherPower ();
		//乐器其他的能力，比如“起飞”，在没有怪物时可能会调用这个方法
}