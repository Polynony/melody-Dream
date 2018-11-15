using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
using DG.Tweening;
///这是乐符的基类
public class MusicNote : MonoBehaviour {

	public string ID;
	public float MN_Hurts;//伤害值，实例化时乐器的m_basicHurt会赋给它，在接触怪物时判断并进行修正
	protected byte Accidental;//变音记号
	protected byte pf;//轻重音符号
	public byte MN_Type;   //实例化时，乐器的MI_type会赋给这个值
	public byte MN_Tone;   //实例化时，乐器的MI_Tyon会赋给这个值

	protected float n_speed;
	protected float n_gravity;
	protected float n_UP;
	protected Vector3 n_angle;

	protected Vector3 b;
	private Vector3 a1;
	private Vector3 b1;
	private float passTime = 0.00f;
	protected float useTime = .00f;

	protected delegate void P_Damage(float hurt, Animator o);
	protected event P_Damage p_damages;

	public void AddAccidental(){
		//当玩家给乐符添加变音记号时调用此方法
	}

	public void UndoAccidental(){
		//当玩家给乐符撤销变音记号时调用此方法
	}

	public void AddPf(){
		//当玩家点击轻音／重音符号时调用此方法，当玩家松开按键后自动撤销
	}

	public void FlyOut(float UP, float speed, float g, Vector3 forwards){
		n_UP = UP;
		n_angle = speed * forwards;
		n_gravity = g;
		//Monster Targetposs;
		//Targetposs = GameManager.monsterArray.Find((Monster obj) => obj._IsAwake == true);
		Vector3 n_vector = transform.up * (n_UP - n_gravity * Time.deltaTime);
		transform.Translate(n_angle, Space.Self);
		transform.Translate(n_vector, Space.Self);
	}

	public void AutomaticFlyToTarget(Monster target, Vector3 b, float _speed){
		useTime = _speed;
		if (Vector3.Distance(transform.position, target.transform.position) < 80)
		{
			passTime += Time.deltaTime;
			float baifenbi = passTime / useTime;
			a1 = Vector3.Lerp(transform.position, b, baifenbi);
			b1 = Vector3.Lerp(b, target.transform.position, baifenbi);
			Vector3 dis = a1 - b1;
			Vector3 point = new Vector3(dis.x * (1.0f - baifenbi), dis.y * (1.0f - baifenbi), dis.z * (1.0f - baifenbi));
			Vector3 newPoint = point + b1;

			transform.position = newPoint;
			if (Vector3.Distance(transform.position, target.transform.position) < 55)
			{
				useTime = _speed / 3;
			}
		}
		else if (target == null || Vector3.Distance(transform.position, target.transform.position) > 80)
		{
			transform.position += Vector3.up * 0.3f;
			PoolManager.Pools["MusicNote"].Despawn(gameObject.transform, 2f);
		}
	}

	public void Del_action(float hurts){
		p_damages += Monster.Monster_Hurt;
		//P_Damage p_damages = new P_Damage(Monster.Monster_Hurt);
		p_damages(hurts, null);
	}

	//这是一个添加音符的方法，当玩家获得音符时调用这个方法
	public void MN_Add(GameObject Notes){
		if(!PlayerCollection.PlayerNoteCollection.ContainsKey(Notes.GetComponent<MusicNote>().ID)){
			PlayerCollection.PlayerNoteCollection.Add (Notes.GetComponent<MusicNote>().ID, Notes);
		}
	}


}

