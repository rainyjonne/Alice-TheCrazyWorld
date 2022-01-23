using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Alice2D : MonoBehaviour 
{
	public float maxSpeed = 10.0f;

	public GameObject hat_point;


	bool facingRight;


	Animator anim;
	AudioSource audioPlayer;
	public AudioClip pickSE;
	public AudioClip hitSE;
	public Text kick_times;

	void Awake()
	{
		//get references
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () 
	{
		audioPlayer = gameObject.GetComponent<AudioSource>();
		facingRight = true;
        anim.SetBool("Awaken", true);
	}

	void FixedUpdate () 
	{


	}

	public void Move(float movingSpeed)
	{
		//change the character animation by moving speed
		anim.SetFloat("Speed", Mathf.Abs(movingSpeed));

		//move the character
		//only change its velocity on x axis 
		GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

			//flip the character image if player input direction is different with character's facing direction
		if (movingSpeed > 0 && !facingRight || movingSpeed < 0 && facingRight) Flip ();

	}

	void Flip()
	{
		//reverse the direction
		facingRight = !facingRight;

		//flip the character by multiplying x local scale with -1
		Vector3 characterScale = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;

		//flip the hat point
		Vector3 hatpointScale = hat_point.transform.localScale;
		hatpointScale.x *= -1;
		hat_point.transform.localScale = hatpointScale;
	}

    
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "hedge_dog") {
			PlaySE(hitSE);
			kick_times.text = (Int32.Parse(kick_times.text) + 1).ToString();
		}
		// if (hit.gameObject.layer == 10) {
        //     Destroy (hit.gameObject);
        //     score = score + 1; 
        //     score_text.text = score.ToString();
        // }
		// if (other.gameObject.tag == "hat_test") {
		// 	// add hat to hat point's child object and set relative transformation
		// 	other.transform.SetParent(hat_point.transform);
		// 	other.transform.localPosition = Vector3.zero;
		// 	if (other.gameObject.GetComponent<Rigidbody2D>() == null){
		// 		Rigidbody2D rb = other.gameObject.AddComponent<Rigidbody2D>();
		// 		rb.velocity = Vector2.zero;
		// 		rb.gravityScale = 0;
		// 		rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		// 	}
		// }

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "hat") {
			if (hat_point.transform.childCount == 0) {
				// add hat to hat point's child object and set relative transformation
				other.transform.SetParent(hat_point.transform);
				other.transform.localPosition = Vector3.zero;
				PlaySE(pickSE);
			}


		}
	}

	void PlaySE(AudioClip SE) {
        audioPlayer.PlayOneShot(SE);
    }
}
