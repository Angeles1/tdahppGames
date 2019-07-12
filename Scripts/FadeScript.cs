using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour {

    public GameObject fadeRend;

	// Use this for initialization


    public void StartFading()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;

        }
        canvasGroup.interactable = false;
        yield return null;
    }



   
}
