using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonManager  {

    public List<LevelRecords> levelsPoints;

    public List<LevelRecordsStroop> levelsPointsStroop;


    public void Listar()
    {
        foreach (LevelRecords levelsPoint in levelsPoints)
        {
            Debug.Log(levelsPoint);
        }
    }

}

[Serializable]
public class LevelRecords
{

    public int lvlID;
    public int TA;
    public int C;
    public int O;

    public override string ToString()
    {
        return string.Format("{0}: TA {1} C {2} O {3}",lvlID, TA, C, O);
    }
}

[Serializable]
public class LevelRecordsStroop
{

    public int lvlID;
    public int PA; //total palabras leidas
    public int A; //total aciertos
    public int C; // total fallos
    public float TT; //total tiempo de respuesta
    public float TC; // total tiempo de correccion

    public override string ToString()
    {
        return string.Format("{0}: PA {1} A {2} C {3} TT {4} TC {5} ", lvlID, PA, A, C, TT, TC);
    }
}