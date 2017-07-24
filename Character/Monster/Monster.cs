using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//这是怪物AI的基类
public class Monster : Unit {

	public string MonsterType;//怪物类型
	public bool IsWeak = false;//判断是否触发了弱点
	protected  Dictionary<byte, byte> MonsterWeak = new Dictionary<byte, byte>();//当前怪物的弱点，在继承类中赋值
	public bool _IsAwake;

	public Monster() {
	}

	public Monster(int monsterhealth, string monstertype){
		Health = monsterhealth;
		MonsterType = monstertype;
	}

	public int CheckWeak(byte type, byte tone){
		int multiple = 1;
		if(MonsterWeak.ContainsKey (type)){
			multiple += 1;
		}
		if(MonsterWeak.ContainsValue (tone)){
			multiple += 1;
		}
		return multiple;
	}


}
