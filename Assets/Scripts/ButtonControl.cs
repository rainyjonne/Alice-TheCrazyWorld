using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip clickSound;
    public GameObject win_canvas;
    public GameObject rule_canvas;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();

    }


    public void reloadScene1() {
        new WaitForSeconds(2.0f);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("PlayScene");
        win_canvas.SetActive(false);
    }

    public void reloadScene2() {
        new WaitForSeconds(2.0f);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Play2Scene");
        win_canvas.SetActive(false);
    }

    public void gotoMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MenuScene");
    }


    public void buttonSound() {
        audioPlayer.PlayOneShot(clickSound);
    }

    public void gotoNextScene() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Play2Scene");
    }

    public void showRules(){
        rule_canvas.SetActive(true);
    }
    
    public void showMenu() {
        rule_canvas.SetActive(false);
    }

    public void exitGame(){
        Application.Quit();
    }


}
