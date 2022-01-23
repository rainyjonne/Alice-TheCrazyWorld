using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCount : MonoBehaviour
{
    public Text throw_times;
    public Text score;
    int throws;
    int deduct_scores;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throws = Int32.Parse(throw_times.text);
        if (throws <= 3) {
            score.text = (100).ToString();
        } else {
            deduct_scores = throws - 3;
            score.text = (100 - (deduct_scores * 5)).ToString();
        }
        
    }
}
