using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCondition : MonoBehaviour {
    public GameObject checkD2;
    public GameObject checkStroop;
    public GameObject checkSombras;
    public GameObject checkMole;


    // Use this for initialization
    void Start () {

        ///checkD2.SetActive(false);
        //checkStroop.SetActive(false);
        //button.GetComponent<Button>().enabled = false;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ReciveMessage(string message)
    {
        if (message.Contains("d2"))
        {
            checkD2.SetActive(true);


        }
        if (message.Contains("stroop"))
        {
            checkStroop.SetActive(true);

        }

        if(message.Contains("sombras") )
        {
            checkSombras.SetActive(true);
        }
        if (message.Contains("mole"))
        {
            checkMole.SetActive(true);
        }
    }
}
