using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class D2_GenerateLevel : MonoBehaviour {

    public GameObject[] buttons;
    public List<D2Data> levels = new List<D2Data>();
    public string[] values;


    public delegate void UpdateValues();
    public event UpdateValues OnUpdateValues;

    private void Start()
    {
        LevelToGenerate(0);
    }

    public void LevelToGenerate(int lvl)
    {
        levels = this.gameObject.GetComponentInParent<GameManager>().levels;
        values = levels[lvl].dataValues;
        if (OnUpdateValues != null)
        {
            OnUpdateValues();
        }

        try
        {
            for (int i = 0; i< values.Length; i++)
            {
                {
                    Color colorRestart;
                    ColorUtility.TryParseHtmlString("#C1F9FF", out colorRestart);
                    buttons[i].GetComponentInChildren<Text>().text = values[i].ToString();
                    buttons[i].GetComponent<Image>().color = colorRestart;
                    buttons[i].GetComponent<CheckButton>().countTouched = 0;
                    buttons[i].GetComponent<CheckButton>().isChecked = false;
                    
                }
            }

          
        }
        catch (NullReferenceException ex)
        {
            print("Error " + ex.Message);
        }

    }


    
}
