﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody2D playerRigidBody2D;
	private float movePlayerVector;
	private bool facingRight;
	public float speed = 4.0f;

	void Awake()
	{
		playerRigidBody2D = (Rigidbody2D) GetComponent (typeof (Rigidbody2D));
	}

	void Update()
	{
		movePlayerVector = Input.GetAxis("Horizontal");

		playerRigidBody2D.velocity = new Vector2 (movePlayerVector * speed, playerRigidBody2D.velocity.y);

		if(movePlayerVector > 0 && !facingRight)
		{
			Flip();
		}
		else if (movePlayerVector <0 && facingRight)
		{
			Flip();
		}
	}

	void Flip(){
		//Switch the way the player is labeled as facing
		facingRight = !facingRight;

		//Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *=-1;
		transform.localScale = theScale;
	}
}
