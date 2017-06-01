using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//这是乐符的基类
public class MusicNote : MonoBehaviour {

	public int ID;
	public double Hurts;//伤害值，实例化时乐器的m_basicHurt会赋给它，然后会在接触怪物的时候判断增加多少伤害值
	public enum Accidental{sharp, X, b, bb};//变音记号
	public enum pf{p, f};//轻重音符号
	public int n_Type;   //实例化时，乐器的m_type会赋给这个值
	public int n_Tone;   //实例化时，乐器的m_Tyon会赋给这个值

	public MusicNote(){
	}

	public MusicNote(int id,double hurts){
		ID = id;
		Hurts = hurts;
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
		Transform Targetpos;
		int speed = s;
		Vector3 b;
		Vector3 a1;
		Vector3 b1; 
		Vector3 c1 = Vector3.zero;
		float passTime = 0.00f;
		float useTime = 3.00f;
		Targetpos = GameObject.FindWithTag ("Target").GetComponent<Transform> ();

		b = Vector3.Lerp (transform.position, Targetpos.position, 0.5f);
			b.y += 40f;
			passTime += Time.deltaTime;
			float baifenbi = passTime / useTime;
		a1 = Vector3.Lerp(transform.position, b, baifenbi);
		b1 = Vector3.Lerp(b, Targetpos.position, baifenbi);
			Vector3 dis = a1 - b1;
			Vector3 point = new Vector3(dis.x * (1.0f - baifenbi), dis.y * (1.0f - baifenbi), dis.z * (1.0f - baifenbi));
			Vector3 newPoint = point + b1;

			c1 = newPoint;
		transform.position = Vector3.Lerp (transform.position, c1, speed * Time.deltaTime);
		}
		//this.transform.position = Vector3.Lerp (this.transform.position,targetpos,speed * Time.deltaTime);
		//Quaternion targetRot = Quaternion.LookRotation (Targetpos.position - this.transform.position);
		//this.transform.rotation = Quaternion.Slerp (this.transform.rotation, targetRot, rotatespeed * Time.deltaTime);
		/*
		Transform t1;    //开始位置
		Transform t2;     //结束位置   
		t1 = this.transform;
		t2 = GameObject.Find ("Target").GetComponent<Transform> ();
			//两者中心点  
		Vector3 center = (t1.position + t2.position) * 0.5f;  

			center -= new Vector3(0, 1, 0);  

			Vector3 start = t1.position - center;  
			Vector3 end = t2.position - center;  

			//弧形插值  
			transform.position = Vector3.Slerp(start,end,Time.time);  
			transform.position += center;  
*/
	}

public interface INoteDerived{
	void AttackHurt ();
		//当乐符碰到怪物时进行碰撞判断并执行减血等功能
}
