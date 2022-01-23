using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceControl : MonoBehaviour
{
 	private Alice2D character;
	private float movingSpeed;
	public float jumpForce;
	bool IsGrounded;

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<Alice2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
        // if (Input.GetKey(KeyCode.J) && IsGrounded) {
        //     GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
        // }

	}

	void FixedUpdate()
	{
		//get input by Axis set in input setting
		movingSpeed = Input.GetAxis("Horizontal");

		//pass parameters to character script, and then it can move
		character.Move(movingSpeed);

	}

	// void OnCollisionEnter2D(Collision2D other) {
	// 	if(other.gameObject.tag == "floor") {
	// 		IsGrounded = true;
	// 	}
	// }

	// void OnCollisionExit2D(Collision2D other) {
	// 	if(other.gameObject.tag == "floor") {
	// 		IsGrounded = false;
	// 	}
	// }


}