using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

	public static KeyCode move_forward;
	public static KeyCode move_back;
	public static KeyCode move_left;
	public static KeyCode move_right;
	public static KeyCode move_jump;

	public static KeyCode _callInstrument;


	public static KeyCode Key_note_1;
	public static KeyCode Key_note_2;
	public static KeyCode Key_note_3;
	public static KeyCode Key_note_4;
	public static KeyCode Key_note_5;
	public static KeyCode Key_note_6;

	public static void Input_initialize()
	{
		move_forward = KeyCode.W;
		move_back = KeyCode.S;
		move_left = KeyCode.A;
		move_right = KeyCode.D;
		move_jump = KeyCode.Space;

		_callInstrument = KeyCode.C;

		Key_note_1 = KeyCode.T;
		Key_note_2 = KeyCode.Y;
		Key_note_3 = KeyCode.U;
		Key_note_4 = KeyCode.I;
		Key_note_5 = KeyCode.O;
		Key_note_6 = KeyCode.P;
	}

	public static void ChangeKeycode_forward()
	{
		GameObject buttonSelf = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		Event a = Event.current;
		if (a.isKey)
		{
			move_forward = a.keyCode;

		}

	}
	public static void ChangeKeycode_back()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			move_back = a.keyCode;

		}

	}
	public static void ChangeKeycode_left()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			move_left = a.keyCode;

		}

	}
	public static void ChangeKeycode_right()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			move_right = a.keyCode;

		}

	}
	public static void ChangeKeycode_jump()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			move_jump = a.keyCode;

		}
	}
	public static void ChangeKeycode_callInstrument()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			_callInstrument = a.keyCode;

		}

	}
	public static void ChangeKeycode_note_1()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			Key_note_1 = a.keyCode;

		}

	}
	public static void ChangeKeycode_note_2()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			Key_note_2 = a.keyCode;

		}
	}
	public static void ChangeKeycode_note_3()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			Key_note_3 = a.keyCode;

		}

	}
	public static void ChangeKeycode_note_4()
	{
		Event a = Event.current;
		if (a.isKey)
		{
			Key_note_4 = a.keyCode;

		}

	}

}
