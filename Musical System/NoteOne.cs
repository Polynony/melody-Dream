using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
public class NoteOne : MusicNote{

	void Start () {
		
	}

	void FixedUpdate() {
		flyToTarget (40);
	}
	void OnTriggerEnter(Collider coll) {
		if(coll.gameObject.tag == "Monster"){
			Unit a = coll.GetComponent<Unit> ();
			a.Damage (Hurts);
			PoolManager.Pools ["MusicNotePool"].Despawn (gameObject.transform);
		}
	}
}
