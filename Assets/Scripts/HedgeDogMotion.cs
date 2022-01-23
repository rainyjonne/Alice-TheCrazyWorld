using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HedgeDogMotion : MonoBehaviour 
{
	public float windForce = 200.0f;
	public float croquetForce = 200.0f;
    Animator anim;
	AudioSource audioPlayer;
    public AudioClip ouchSound;

	// Use this for initialization
	void Start () 
	{
		audioPlayer = gameObject.GetComponent<AudioSource>();
        anim = GetComponent<Animator> ();
		InvokeRepeating ("MovedByWind", 0.0f, 0.5f);
	}

	void MovedByWind()
	{
		float random_num = UnityEngine.Random.Range (0.0f, 1.0f);
		if (random_num > 0.5f)  {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * windForce);
			anim.SetBool("RightWalk", true);
			anim.SetBool("LeftWalk", false);
		}
		else if (random_num == 0.0f) {
			anim.SetBool("RightWalk", false);
			anim.SetBool("LeftWalk", false);
		}
		else {
			GetComponent<Rigidbody2D> ().AddForce (-1 * Vector2.right * windForce);
			anim.SetBool("RightWalk", false);
			anim.SetBool("LeftWalk", true);
		}
	}

	// Update is called once per frame

	
	void Update () 
	{
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name == "alice" || other.gameObject.name == "croquet") {
			audioPlayer.PlayOneShot(ouchSound);
			anim.SetBool("Fly", true);
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * croquetForce);
		} 
		
		if (other.gameObject.name == "CroquetGround") {
			anim.SetBool("Fly", false);
		}

	}
}


