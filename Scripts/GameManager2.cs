using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{

    enum State
    {
        START,
        PLAY,
        GAMEOVER,
    }

    public static float time;
    public float timeLimit = 30;
    const float waitTime = 5;

    Animator anim;
    public MolesManager moleManager;
    Text remainingTIme;
    AudioSource audioGame;

    State state;
    float timer;

  
    void Start()
    {
        Application.targetFrameRate = 60;

        this.state = State.START;
        this.timer = 0;
        //this.moleManager = GetComponent<MolesManager>();
        this.audioGame = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (this.state == State.START)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.state = State.PLAY;

                // start to generate moles
                this.moleManager.GetComponent<MolesManager>().StartGenerate();

                this.audioGame.Play();
            }
        }
        else if (this.state == State.PLAY)
        {
            this.timer += Time.deltaTime;
            time = this.timer / timeLimit;

            if (this.timer > timeLimit)
            {
                this.state = State.GAMEOVER;

    
                // stop to generate moles
                this.moleManager.GetComponent<MolesManager>().StopGenerate();

                this.timer = 0;

                // stop audio
                this.audioGame.loop = false;
            }

        }
        else if (this.state == State.GAMEOVER)
        {
            this.timer += Time.deltaTime;

            if (this.timer > waitTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }
}
