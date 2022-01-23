using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomArrayExtensions;

public class HatControl : MonoBehaviour
{
    GameObject[] hats;
    GameObject hat1;
    GameObject hat2;
    GameObject hat3;
    GameObject hat4;
    GameObject hat5;

    // Start is called before the first frame update
    void Start()
    {
        hats = GameObject.FindGameObjectsWithTag("hat");
        do
        {
            //Random Sprite Value
            hat1 = hats.GetRandom();
            hat2 = hats.GetRandom();
            hat3 = hats.GetRandom();
            hat4 = hats.GetRandom();
            hat5 = hats.GetRandom();

            //At the end, check condition in while.
        }while(hat1 == hat2 || hat1 == hat3 || hat2 == hat3 || hat1 == hat4 || hat2 == hat4 || hat3 == hat4 || hat1 == hat5 || hat2 == hat5 || hat3 == hat5 || hat4 == hat5);

        hat1.GetComponent<SpriteRenderer>().enabled = true;
        hat2.GetComponent<SpriteRenderer>().enabled = true;
        hat3.GetComponent<SpriteRenderer>().enabled = true;
        hat4.GetComponent<SpriteRenderer>().enabled = true;
        hat5.GetComponent<SpriteRenderer>().enabled = true;

        hat1.transform.position = new Vector2(Random.Range(6, 38), -2.5f);
        hat2.transform.position = new Vector2(Random.Range(6, 38), -2.5f);
        hat3.transform.position = new Vector2(Random.Range(6, 38), -2.5f);
        hat4.transform.position = new Vector2(Random.Range(6, 38), -2.5f);
        hat5.transform.position = new Vector2(Random.Range(6, 38), -2.5f);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

 namespace CustomArrayExtensions 
 {
     public static class ArrayExtensions {
         public static T GetRandom<T>(this T[] array) {
             return array[Random.Range(0, array.Length)];
         }
     }
 }
