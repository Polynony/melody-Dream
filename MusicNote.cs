using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是乐符的基类
public class MusicNote : MonoBehaviour {

	public int ID;
	public enum Accidental{sharp, X, b, bb};//变音记号
	public enum pf{p, f};//轻重音符号
	public int Types;   
	public int Tones;             

	public void AddAccidental(){
		//当玩家给乐符添加变音记号时调用此方法
	}

	public void UndoAccidental(){
		//当玩家给乐符撤销变音记号时调用此方法
	}

	public void AddPf(){
		//当玩家点击轻音／重音符号时调用此方法，当玩家松开按键后自动撤销
	}

	public void AttackHurt(){
		//当乐符碰到怪物时进行碰撞判断并执行减血等功能
	
	}
	public void fly(){
		//这是乐符实例化之后自动飞向目标的方法,有待改进，需要加上贝塞尔曲线
		Transform Targetpos;
		float speed = 5f;
		float rotatespeed = 10f;//这两个数值只是暂时的
		Targetpos = GameObject.Find ("目标").GetComponent<Transform> ();

		Vector3 targetpos = Targetpos.position;
		this.transform.position = Vector3.Lerp (this.transform.position,targetpos,speed * Time.deltaTime);

		Quaternion targetRot = Quaternion.LookRotation (Targetpos.position - this.transform.position);

		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, targetRot, rotatespeed * Time.deltaTime);

	}

}
