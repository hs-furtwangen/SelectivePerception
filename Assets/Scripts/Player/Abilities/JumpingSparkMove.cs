﻿using UnityEngine;
using System.Collections;

public class JumpingSparkMove : MonoBehaviour {
	static float jumpSparkGravity = 0.006f;
	static public bool continueJumpSpark = false;
	static float jumpSparkSpeed = 0.50f;
	public static float jumpSparkHeight = jumpSparkSpeed;
	static public bool abilityButtonPressed;
	float startPosY;
	void start()
	{
		startPosY = this.transform.position.y;
	}
	void update()
	{
		abilityButtonPressed = GUIScene.toggleState;
		if(abilityButtonPressed == true)
		{
			JumpingSparkMove.jumpHighSpark(startPosY, this.gameObject.transform);
		}
	}

public static void jumpHighSpark(float startPosY, Transform tempChar)
	{
		continueJumpSpark = true;
		jumpSparkHeight = jumpSparkHeight-jumpSparkGravity;
		tempChar.Translate(Vector3.up*jumpSparkHeight);
		if(tempChar.position.y <= startPosY && jumpSparkHeight<=0)
		{
			continueJumpSpark = false;
			jumpSparkHeight = jumpSparkSpeed;
			//Debug.Log(isjumping);
		}
	}

}
