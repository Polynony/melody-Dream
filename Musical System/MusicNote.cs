using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
using DG.Tweening;
//这是乐符的基类
public class MusicNote : MonoBehaviour {

	public string ID;
	public float Hurts;//伤害值，实例化时乐器的m_basicHurt会赋给它，然后会在接触怪物的时候判断增加多少伤害值
	protected byte Accidental;//变音记号
	protected byte pf;//轻重音符号
	public byte n_Type;   //实例化时，乐器的m_type会赋给这个值
	public byte n_Tone;   //实例化时，乐器的m_Tyon会赋给这个值

	public MusicNote(){
	}

	public void AddAccidental(){
		//当玩家给乐符添加变音记号时调用此方法
	}

	public void UndoAccidental(){
		//当玩家给乐符撤销变音记号时调用此方法
	}

	public void AddPf(){
		//当玩家点击轻音／重音符号时调用此方法，当玩家松开按键后自动撤销
	}
		
	public void flyToTarget(int s){
		Monster Targetpos;
		int speed = s;
		Vector3 b;
		Vector3 a1;
		Vector3 b1; 
		Vector3 c1 = Vector3.zero;
		float passTime = 0.00f;
		float useTime = 3.00f;
		Targetpos = GameManager.monsterArray.Find ((Monster obj) => obj._IsAwake == true);
		if (Targetpos != null && Vector3.Distance(transform.position, Targetpos.transform.position) < 100) {
			
			b = Vector3.Lerp (transform.position, Targetpos.transform.position, 0.5f);
			b.y += 40f;
			passTime += Time.deltaTime;
			float baifenbi = passTime / useTime;
			a1 = Vector3.Lerp (transform.position, b, baifenbi);
			b1 = Vector3.Lerp (b, Targetpos.transform.position, baifenbi);
			Vector3 dis = a1 - b1;
			Vector3 point = new Vector3 (dis.x * (1.0f - baifenbi), dis.y * (1.0f - baifenbi), dis.z * (1.0f - baifenbi));
			Vector3 newPoint = point + b1;

			c1 = newPoint;
			//transform.DOMove (c1, 1);
			transform.position = c1;
		} else {
			transform.position += Vector3.up * 0.3f;
			PoolManager.Pools ["MusicNotePool"].Despawn (gameObject.transform, 2f);
		}
	}

	//这是一个添加音符的方法，当玩家获得音符时调用这个方法
	public void N_Add(GameObject Notes){
		if(!PlayerCollection.noteCollection.ContainsKey(Notes.GetComponent<MusicNote>().ID)){
			PlayerCollection.noteCollection.Add (Notes.GetComponent<MusicNote>().ID, Notes);
		}
	}


}

