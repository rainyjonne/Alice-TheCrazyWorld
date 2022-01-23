using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowHat : MonoBehaviour
{
    public float throw_force;
    public AudioClip throwSE;
    public Text throw_text;
    int throw_times = 0;

    AudioSource audioPlayer;
    GameObject hat;
    //float movingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //movingSpeed = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() 
    {
        if (transform.childCount != 0) {
            hat = transform.GetChild(0).gameObject;

            if(Input.GetMouseButtonDown(0)) {    
                print("comeon");
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0.0f;
                hat.GetComponent<Collider2D>().isTrigger = false;
                hat.transform.parent = null;
                hat.transform.SetParent(null, false);
                Rigidbody2D rb1 = hat.AddComponent<Rigidbody2D>();
                rb1.AddForce((mousePos - hat.transform.position)*throw_force);
                throw_times = throw_times + 1; 
                throw_text.text = throw_times.ToString();
                PlaySE(throwSE);
                //rb1.AddForce((Camera.main.ScreenToWorldPoint(mousePos) - hat.transform.position).normalized * throw_force, ForceMode2D.Impulse);

            }
        }

    }

    void PlaySE(AudioClip SE) {
        audioPlayer.PlayOneShot(SE);
    }
}
