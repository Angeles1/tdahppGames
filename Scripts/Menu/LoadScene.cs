using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public GameObject loadingSceneObject;
    public Slider slider;
    AsyncOperation async;
    public float timeToCharge;

    public void LoadSceneMain(string scene)
    {
        slider.value = 0;
        StartCoroutine(LoadingScene(scene));
    }

    IEnumerator LoadingScene(string scene)
    {
        loadingSceneObject.SetActive(true);
        async = SceneManager.LoadSceneAsync(scene);
        async.allowSceneActivation = false;

        while (slider.value != 1)
        {
            StartCoroutine(CargarBarra());
            if(slider.value == 1)
            {
                async.allowSceneActivation = true;
            }
            yield return 0;
        }
    }

    IEnumerator CargarBarra()
    {
        float elapsedTime = 0;
        float animationTime = 0.1f;

        slider.value += timeToCharge;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            yield return 0;
        }
    }


}
