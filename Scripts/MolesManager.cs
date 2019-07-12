using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolesManager : MonoBehaviour {
    public GameObject LevelGenerador;
    public string[] values;
    string source;
    public bool d2;
    int count;
    List<MoleController> molesD2 = new List<MoleController>();
    List<MoleController> molesFail = new List<MoleController>();
    bool generate;
    public AnimationCurve maxMoles;
    int maxSize;
    int index;

    private void Start()
    {
        index = 0;
        LevelGenerador.GetComponent<D2_GenerateLevel>().OnUpdateValues += UpdateValues;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("MoleD2");
        foreach (GameObject go in gos)
        {
            molesD2.Add(go.GetComponent<MoleController>());
        }

        GameObject[] gosF = GameObject.FindGameObjectsWithTag("MoleFail");
        foreach (GameObject go in gosF)
        {
            molesFail.Add(go.GetComponent<MoleController>());
        }

        this.generate = false;

    }

    public void UpdateValues()
    {
        values = LevelGenerador.GetComponent<D2_GenerateLevel>().values;
        maxSize = values.Length;

    }





    public void StartGenerate()
    {
        //if (state)
        {
         //   for (int i = 0; i < values.Length; i++)
            {
                
           //     source = values[0].ToString();
                
            }

        }
        StartCoroutine(DoCheck());


    }


    IEnumerator DoCheck()
    {
        for (; ; )
        {
            Generation();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2);

    }


    public void StopGenerate()
    {
        this.generate = false;
    }


    private void Generation ()
    {


                StartCoroutine(CountDown());

                source = values[index].ToString();
                if (index < maxSize)
                {
                    index++;

                }
                if (source.Contains("p"))
                {
                    d2 = false;
                }
                else
                {
                    count = 0;
                    foreach (char c in source)
                    {
                        if (c == ',') count++;
                        if (c == '\'') count++;

                    }
                    if (count == 2)
                    {
                        d2 = true;
                    }
                    else
                    {
                        d2 = false;
                    }
                }



                if (source.Contains("d"))
                {

                    count = 0;
                    d2 = true;

                    foreach (char c in source)
                    {
                        if (c == ',') count++;
                        if (c == '\'') count++;

                    }
                    if (count >= 2)
                    {
                        d2 = false;
                    }

                }


                int n = 0;
                if (!d2)
                {
                    n = molesD2.Count;
                    //int maxNum = (int)this.maxMoles.Evaluate(GameManager2.time);

                    for (int x = 0; x < 1; x++)
                    {
                        // select mole to up
                        this.molesD2[Random.Range(0, n)].Up();
                    }
                }
                else
                {
                    n = molesFail.Count;
                    //int maxNum = (int)this.maxMoles.Evaluate(GameManager2.time);

                    for (int x = 0; x < 1; x++)
                    {

                        // select mole to up
                        this.molesFail[Random.Range(0, n)].Up();

                    }
                }

        

    }

  


    

}
