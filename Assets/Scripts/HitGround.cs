using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    public AudioClip fallSE;
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "hat") {
            PlaySE(fallSE);
            other.transform.position = new Vector2(Random.Range(6, 38), -2.5f);
            Destroy(other.gameObject.GetComponent<Rigidbody2D>());
            new WaitForSeconds(2.0f);
            other.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }


    }

    
    void PlaySE(AudioClip SE) {
        audioPlayer.PlayOneShot(SE);
    }
}
