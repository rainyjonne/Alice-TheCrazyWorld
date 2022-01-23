using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KickScoreCount : MonoBehaviour
{
    public Text kick_times;
    public Text score;
    int kicks;
    int deduct_scores;
    GameObject[] enemies;
    public GameObject win_canvas;
    public AudioSource audioPlayer;
    public AudioClip rickroll_success;
    bool isPlaying=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length == 0) {
            win_canvas.SetActive(true);
            audioPlayer.clip = rickroll_success;
            if (!isPlaying) {
                audioPlayer.Play();
                isPlaying = true;
            }
            
        }
        kicks = Int32.Parse(kick_times.text);
        if (kicks <= 70) {
            score.text = (100).ToString();
        } else {
            deduct_scores = kicks - 70;
            score.text = (100 - (deduct_scores * 3)).ToString();
        }
        
    }
}
