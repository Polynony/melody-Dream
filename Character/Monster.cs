using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是怪物AI的基类
public class Monster : Unit {

	public string MonsterType;//怪物类型
	public bool IsWeak = false;//判断是否触发了弱点
	protected int[] MonsterWeak;//存储怪物弱点，目前约有16种，受到攻击时遍历
	public Monster() {
	}

	public Monster(int monsterhealth, string monstertype){
		Health = monsterhealth;
		MonsterType = monstertype;
	}

	public void patrol(){
		//怪物日常状态，在固定区域随机移动
	}


}
