using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
///这是一个挂在主角上的脚本，主要处理主角的行为
public class PlayerAction : MonoBehaviour{

	public static float P_Health;
	public float P_Speed;

	public GameObject Hero;
	public float roteate;
	public static GameObject currentTool;
	public static Animator player_animator;

	private AnimatorStateInfo anim;

	void Start()
	{
		player_animator = gameObject.GetComponent<Animator>();
		currentTool = GameObject.FindWithTag("Tool");
		List<GameObject> tools = new List<GameObject>(PlayerCollection.PlayerInstrumentsCollection.Values);
		P_Health = 100;

	}

	void Update()
	{

		anim = player_animator.GetCurrentAnimatorStateInfo(0);

		if (!anim.IsName("player_attack") && !anim.IsName("player_die"))
		{
			MoveKeyboard();
			Toolactive();
			//playMusicAction (Hero);
		}

		if (anim.normalizedTime > 1.0f)
		{
			string Aname = player_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
			player_animator.SetBool(Aname, false);
		}

	}

	/* void FixedUpdate () {
		MoveMouse ();
	} */

	/*public void playMusicAction(GameObject hero){
		byte type = currentTool.GetComponent<MusicInstruments> ().MI_Type;
		if(Input.GetKey(KeyCode.T)||Input.GetKey(KeyCode.Y)||Input.GetKey(KeyCode.U)||Input.GetKey(KeyCode.I)||Input.GetKey(KeyCode.O)||Input.GetKey(KeyCode.P)){
		switch(type){
		case 0:
			PlayWindMusic musicnote0 = new PlayWindMusic ();
			//musicnote0.AttackAction (Hero);
			break;
		case 1:
			PlayStringMusic musicnote1 = new PlayStringMusic ();
			//musicnote1.AttackAction (Hero);
			break;
			//这是发出乐符的动作,
		    }
		}
	}*/

	public void MoveKeyboard()
	{

		if (Input.GetKey(InputManager.move_forward))
		{
			transform.Translate(Vector3.forward * P_Speed * Time.deltaTime, Space.Self);
			player_animator.SetBool("player_run", true);
		}

		if (Input.GetKey(InputManager.move_back))
		{
			transform.Translate(Vector3.forward * (-P_Speed * 0.3f) * Time.deltaTime, Space.Self);
			player_animator.SetBool("player_back", true);
		}

		if (Input.GetKey(InputManager.move_left))
		{
			if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("player_run"))
			{
				transform.Rotate(Vector3.up * -roteate * Time.deltaTime, Space.Self);
				player_animator.SetBool("player_run", true);
			}
			else if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("player_idle"))
			{
				transform.Rotate(Vector3.up * -roteate * Time.deltaTime, Space.Self);
				player_animator.SetFloat("RL_turn", 2);
			}
		}

		if (Input.GetKey(InputManager.move_right))
		{
			if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("player_run"))
			{
				transform.Rotate(Vector3.up * roteate * Time.deltaTime, Space.Self);
				player_animator.SetBool("player_run", true);
			}
			else if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("player_idle"))
			{
				transform.Rotate(Vector3.up * roteate * Time.deltaTime, Space.Self);
				player_animator.SetFloat("RL_turn", 3);
			}
		}

		if (Input.GetKeyDown(InputManager.move_jump))
		{
			player_animator.SetBool("player_jump", true);
		}

	}

	public void MoveMouse()
	{
		Vector3 target;
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();
			if (Physics.Raycast(ray, out hitInfo))
			{
				if (hitInfo.collider.name == "Plane")
				{
					target = hitInfo.point;
					Vector3 offSet = target - transform.position;
					transform.Translate(target * P_Speed, Space.Self);
				}
			}
		}
	}

	public static void Player_Hurt(float hurt, Animator p)
	{
		Debug.Log("player:" + P_Health);
		if (hurt >= P_Health)
		{
			player_animator.SetBool("player_die", true);
			P_Health = 0;
			GameManager.GameEnd();
		}
		else
		{
			P_Health -= hurt;
			player_animator.SetBool("player_hit1", true);
		}
	}

	public void Toolactive()
	{
		if (Input.GetKeyDown(InputManager._callInstrument))
		{
			player_animator.SetBool("player_take", true);
			currentTool = GameObject.FindWithTag("Tool");
			//currentTool = PlayerCollection.PlayerInstrumentsCollection.TryGetValue(,)
			if (currentTool.GetComponent<MeshRenderer>().enabled)
			{
				_toolactive(false, currentTool);
			}
			else
			{
				_toolactive(true, currentTool);
			}
		}
	}
	public void _toolactive(bool a, GameObject b)
	{
		b.GetComponent<MeshRenderer>().enabled = a;
		b.GetComponent<BoxCollider>().enabled = a;
		b.GetComponent<MusicInstruments>().enabled = a;
	}
	public void Hit1_EndEvent()
	{
		player_animator.SetBool("player_hit1", false);
	}

	public void RightEndEvent()
	{
		player_animator.SetFloat("RL_turn", 0);
	}

	public void leftEndEvent()
	{
		player_animator.SetFloat("RL_turn", 0);
	}

}
