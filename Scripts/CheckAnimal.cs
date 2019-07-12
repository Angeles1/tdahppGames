using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnimal : MonoBehaviour {
    public string name;
    public GameObject animal;
    public GameObject results;
    public bool isChecked;

    public GameObject Canvas;
	// Use this for initialization
	void Start () {
        this.isChecked = false;
	}
	
	// Update is called once per frame
	void Update () {
        this.name = this.GetComponent<Image>().sprite.name;

    }

    public void CheckMyName()
    {

        if( this.name == animal.GetComponent<Sombras_GenerateLvl>().animal && !isChecked)
        {
            results.GetComponent<ResultsSombras>().quantity--;
            if (results.GetComponent<ResultsSombras>().quantity < 1)
            {
                results.GetComponent<ResultsSombras>().SaveResults();

                animal.GetComponent<Sombras_GenerateLvl>().NextLevel();
                Canvas.SetActive(true);
                print("FIN");
            }
            this.isChecked = true;
           // Destroy(this);
        }
        if (this.name != animal.GetComponent<Sombras_GenerateLvl>().animal)
        {
            results.GetComponent<ResultsSombras>().totalFails++;

        }
    }
}
