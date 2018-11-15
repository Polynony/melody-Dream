using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PathologicalGames;

public class BeamsNote : MusicNote
{
	private Vector3 forwardsse;
	private Monster Targetpos;
	void Start()
	{
		Targetpos = GameManager.monsterArray.Find((Monster obj) => obj._IsAwake == true);
		MN_Hurts = 10;

		n_UP = 0.4f;
		n_speed = 0.2f;
		n_gravity = 4;

		forwardsse = GameManager._player.transform.forward;

		b = Vector3.Lerp(transform.position, Targetpos.transform.position, 0.5f);
		b.y += 15f;
	}

	void Update()
	{
		if (Targetpos != null && Vector3.Distance(transform.position, Targetpos.transform.position) <= 25)
		{
			transform.DOMove(Targetpos.transform.position, 2);
		}
		else if (Targetpos != null)
		{
			AutomaticFlyToTarget(Targetpos, b, 10f);
		}

       // FlyOut(n_UP, n_speed, n_gravity, forwardsse);
		PoolManager.Pools["MusicNote"].Despawn(gameObject.transform, 13f);
	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Monster"){
			//Del_action(MN_Hurts);
			Debug.Log("111");
			MonsterViolin.v_animator.SetBool("v_hit", true);
			PoolManager.Pools["MusicNote"].Despawn(gameObject.transform);
		}
	}

}
