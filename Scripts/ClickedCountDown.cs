using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedCountDown : MonoBehaviour {
    public bool isActive;

    public GameObject GenerateLevel;

    public void StartCountDownBeforeChangeWord()
    {

        if (!isActive)
        {
            isActive = true;
            StartCoroutine(CountDown());
        }
    }


    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0);
        GenerateLevel.GetComponent<STROOP_GenerateLvl>().SetNextWord();
        isActive = false;

    }

}
