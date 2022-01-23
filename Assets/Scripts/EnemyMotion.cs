using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    public float windForce = 200.0f;
    AudioSource audioPlayer;
    public AudioClip ouchSound;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        InvokeRepeating ("MovedByWind", 0.0f, 0.5f);
    }

    void MovedByWind()
	{
		float random_num = Random.Range (0.0f, 1.0f);
		if (random_num > 0.5f)  {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * windForce);
		}
		else {
			GetComponent<Rigidbody2D> ().AddForce (-1 * Vector2.right * windForce);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "hedge_dog") {
            print("Enemy hit by hedge dog!! You defeat your enemy!");
            audioPlayer.PlayOneShot(ouchSound);
            Destroy(other.gameObject, 0.5f);
            Destroy(gameObject, 0.5f);
        }
    }
}
