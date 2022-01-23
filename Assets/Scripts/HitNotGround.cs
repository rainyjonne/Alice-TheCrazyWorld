using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotGround : MonoBehaviour
{
    public AudioClip meowSE;
    public GameObject win_canvas;
    public AudioSource MainCameraSource;
    public AudioClip rickroll_success;
    bool isPlaying = false;
    AudioSource audioPlayer;
    List<GameObject> stay_hats = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print(stay_hats.Count);
        if(stay_hats.Count == 3){
            print("Wins!");
            win_canvas.SetActive(true);
            MainCameraSource.mute = true;
            audioPlayer.clip = rickroll_success;
            if (!isPlaying) {
                audioPlayer.Play();
                isPlaying = true;
            }
        }

    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "hat") {
            PlaySE(meowSE);
        }
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "hat") {
            if (!stay_hats.Contains(other.gameObject)) {
                stay_hats.Add(other.gameObject);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "hat") {
            if (stay_hats.Count != 3){
                if (stay_hats.Contains(other.gameObject)) {
                    stay_hats.Remove(other.gameObject);
                }
            }
        }

    }

    void PlaySE(AudioClip SE) {
        audioPlayer.PlayOneShot(SE);
    }
}
