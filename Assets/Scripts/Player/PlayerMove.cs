﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	static public int speed = 5;
	public float rotSpeed = 100f;
	static public bool continueJump = false;
	public float speedJumpStart = 0.05f;
	public float jumpHeight;
	public float gravity = 0.001f;
	public float startPosYAxis;

	// Use this for initialization
	void Start () {
		jumpHeight = speedJumpStart;
		startPosYAxis = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move()
	{
		if (Input.GetAxis ("Vertical") != 0) {
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Time.deltaTime * speed, Space.Self);
		} if (Input.GetAxis ("Horizontal") != 0) {
			transform.Rotate(Vector3.up * Input.GetAxis ("Horizontal")* rotSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetAxis ("Jump") != 0 || continueJump == true) {
			continueJump = true;
			if(this.gameObject.name == "JumpingSpark")
			{
				JumpingSparkMove.jumpHighSpark(startPosYAxis, this.gameObject.transform);
			}else{
				jump(startPosYAxis);
			}
		}
	}
	void jump(float startPosY)
	{
		continueJump = true;
		jumpHeight = jumpHeight-gravity;
		transform.Translate(Vector3.up*jumpHeight);
		if(transform.position.y <= startPosY && jumpHeight<=0)
		{
			continueJump = false;
			jumpHeight = speedJumpStart;
			//Debug.Log(isjumping);
		}
	}

}
