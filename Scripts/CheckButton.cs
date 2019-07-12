using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour {

    private Text value;
    string source;
    int count;
    public Sprite spriteCheckOut;
    public bool isChecked;

    public int countTouched = 1;

    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Image>().sprite = spriteCheckOut;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckValue()
    {
            value = this.gameObject.GetComponentInChildren<Text>();

            if (value.text.Contains("p"))
            {
                print("mala");
            }
            else
            {

                source = value.text;
                count = 0;
                foreach (char c in source)
                {
                    if (c == ',') count++;
                    if (c == '\'') count++;

                }
                if (count == 2)
                {
                    print("buena");

                }
                else
                {
                    print("mala");

                }
            }
        
        
    }

    public void ChangeColor()
    {
        if (countTouched < 2)
        {
            isChecked = !isChecked;

            countTouched += 1;
            if (countTouched == 1)
            {
                Color touchOnce = new Color();
                ColorUtility.TryParseHtmlString("#4FB3DE", out touchOnce);
                this.gameObject.GetComponent<Image>().color = touchOnce;

            }
            else
            {
                this.gameObject.GetComponent<Image>().color = Color.black;

            }
        }

    }
}
