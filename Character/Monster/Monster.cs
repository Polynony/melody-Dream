using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//这是怪物AI的基类
public class Monster : MonoBehaviour {

	public static float M_Health;
	public float M_Speed;

	public string MonsterType;//怪物类型
	public float M_hurt;
	public bool IsWeak = false;//判断是否触发了弱点
	protected  Dictionary<byte, byte> MonsterWeak = new Dictionary<byte, byte>();//当前怪物的弱点，在继承类中赋值
	public bool _IsAwake;

	protected delegate void M_Damage(float hurt, Animator o);
	protected event M_Damage m_damages;

	public Monster() {
	}

	public Monster(int monsterhealth, string monstertype){
		M_Health = monsterhealth;
		MonsterType = monstertype;
	}

	public static void Monster_Hurt(float hurt, Animator p)
	{
		if (hurt >= M_Health)
		{
			p.SetBool("_die", true);
			M_Health = 0;
			//Destroy (gameObject);
		}
		else
		{
			M_Health -= hurt;
			p.SetBool("_hit1", true);
		}
	}

	protected void Del_action()
	{
		//M_Damage m_damages = new M_Damage(PlayerAction.Player_Hurt);
		m_damages(M_hurt, null);

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
