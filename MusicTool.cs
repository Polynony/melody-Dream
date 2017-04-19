﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个乐器的基类
public class MusicTool : MonoBehaviour {

	public string name;
	public int Type;             //乐器类型
	public int Tone;             //音色
	public char needClef;           //所需谱号
	public double basicHurt;        //基础伤害值

	public void InstantiationNote(){
		//这是一个实例化乐符的方法，并给乐符的tybes and tones赋值
	}

	public void OtherPower(){
		//乐器其他的能力，比如“起飞”，在没有怪物时可能会调用这个方法
	
	}

	public void OnCollisionEnter(Collision collision){
		//这是一个判断乐器是否被摧毁的方法，当与怪物碰撞时以极小概率销毁该乐器，并在销毁之前对玩家进行提示
	}


}
