using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterViolin : Monster {
	public static Animator v_animator;

	void OnEnble(){
		m_damages += PlayerAction.Player_Hurt;
	}

	void Start () {
		_IsAwake = true;
		M_hurt = 10f;
		MonsterWeak.Add (1, 3);
		v_animator = this.GetComponent<Animator> ();
		M_Health = 50;


	}
	void Update(){
		if(v_animator.GetCurrentAnimatorStateInfo(0).IsName("v_die")){
			this.GetComponent<BehaviorDesigner.Runtime.BehaviorTree> ().enabled = false;
			M_hurt = 0;
		}
	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Debug.Log("monster:" + M_Health);
			Del_action();
		}
	}

	public void v_endEvent(){
		v_animator.SetBool ("v_hit", false);

	}

	void OnDisable(){
		m_damages -= PlayerAction.Player_Hurt;
	}

}
