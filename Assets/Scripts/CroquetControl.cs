using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroquetControl : MonoBehaviour
{
    public GameObject hedge_dog_prefab;
    public Animator anim;
    GameObject croquet;
    GameObject[] hedgedogs;
    // Start is called before the first frame update
    void Start()
    {
        croquet = GameObject.Find("croquet");
        croquet.SetActive(false);
        anim.SetBool("Kick", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K)) {
            croquet.SetActive(true);
            anim.SetBool("Kick", true);
        }
        if (Input.GetKey(KeyCode.S)) {
            anim.SetBool("Kick", false);
        }
        if (Input.GetKey(KeyCode.D)) {
            croquet.SetActive(false);
        }

        hedgedogs = GameObject.FindGameObjectsWithTag("hedge_dog");
        if (Input.GetKey(KeyCode.G)) {
            if (hedgedogs.Length <= 10) {
                Instantiate(hedge_dog_prefab, new Vector2(Random.Range(1, 50), -3.3f), Quaternion.identity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "hedge_dog") {
            print("I hit hedge dog!");
        }
    }
}
