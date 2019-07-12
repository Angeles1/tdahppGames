using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWord : MonoBehaviour {

    Text value;
    public GameObject[] ColorBoxes;
    public GameObject generateLevel;
    public Color[] colors = new Color[5];
    public string[] wordsFails;


    int randomValue;
    int secondValue;
    int currentLevel;
    int index =0;
    string colorFail;

    public void CheckText()
    {
        value = this.GetComponent<Text>();
        randomValue = Random.Range(0, 2);
        if(randomValue == 0)
        {
            secondValue = 1;

        }
        else
        {
            secondValue = 0;
        }

        switch (value.text)
        {
            
            case "ROJO":
                ColorBoxes[randomValue].GetComponent<Image>().color =colors[0];

                ColorBoxes[secondValue].GetComponent<Image>().color = colors[Random.Range(1, 3)];
                ChangeTextColor(0);


                break;
            case "AZUL":
                ColorBoxes[randomValue].GetComponent<Image>().color =colors[1];

                ColorBoxes[secondValue].GetComponent<Image>().color = colors[Random.Range(2, 4)];
                ChangeTextColor(1);

                break;
            case "VERDE":
                ColorBoxes[randomValue].GetComponent<Image>().color = colors[2];

                ColorBoxes[secondValue].GetComponent<Image>().color = colors[Random.Range(3, 5)];
                ChangeTextColor(2);

                break;
            
        }
        ColorBoxes[randomValue].GetComponent<ButtonState>().CorrectButton(true);
        ColorBoxes[secondValue].GetComponent<ButtonState>().CorrectButton(false);


    }

    void ChangeTextColor(int indexColor)
    {
        currentLevel = generateLevel.GetComponent<STROOP_GenerateLvl>().currentLevel;
    
        if( currentLevel != 0)
        {
            ChangeText();

            this.GetComponent<Text>().color = colors[indexColor];

        }

    }

    void ChangeText()
    {
        colorFail = wordsFails[index];
        if (currentLevel == 2)
        {
            this.GetComponent<Text>().text = colorFail;

            switch (colorFail)
            {

                case "ROJO":
                    ColorBoxes[secondValue].GetComponent<Image>().color = colors[0];
                    break;

                case "AZUL":

                    ColorBoxes[secondValue].GetComponent<Image>().color = colors[1];
                    break;

                case "VERDE":

                    ColorBoxes[secondValue].GetComponent<Image>().color = colors[2];
                    break;
            }
            index++;

        }
        else
        {
            this.GetComponent<Text>().text = "XXX";

        }

    }

}
