using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour {
    public bool state;
    public bool isClicked;
    public GameObject CountDownWhenClick;
    public AudioSource clickSuccess;
    public AudioSource clickFail;

    public int countOfWordsPicked;
    public int countOfWordsSuccessed;
    public int countOfWordsFailed;
    public float totalTime;

    public float time;

	// Use this for initialization
	void Start () {
        countOfWordsPicked = 0;
        countOfWordsSuccessed = 0;
        countOfWordsFailed = 0;
        totalTime = 0;
        state = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CorrectButton(bool isCorrect)
    {
        this.time = 0;

        state = isCorrect;
        isClicked = false;

        StartCoroutine("CountDown");
    }

    public void ButtonClicked()
    {
        //this.state 
        if (!isClicked)
        {
            countOfWordsPicked++;
            //si se pulsa el boton, paro el contador, 
            //print("tiempo de respuesta " +this.name+ " "+ time);
            totalTime += time;
            //guardo el tiempo que tardo en pulsar
            //guardo si el boton pulsado es correcto o incorrecto -> 
            if (state)
            {
                countOfWordsSuccessed++;
            }
            else
            {
                countOfWordsFailed++;
            }

            //envio datos a puntuacion.
            // si ya se habia pulsado el otro boton añado el valor de intento de correccion de la respuesta
        }
        this.time = 0;
        if (!state)
        {
            Handheld.Vibrate();
            clickFail.Play();
        }
     

        this.isClicked = true;
        CountDownWhenClick.GetComponent<ClickedCountDown>().StartCountDownBeforeChangeWord();
    }

    IEnumerator CountDown()
    {
        while (!isClicked)
        {
            this.time+=0.005f;
            yield return new WaitForSeconds(0.005f);
        }
        yield return 0;
    }
}
