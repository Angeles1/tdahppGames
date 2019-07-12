using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public string game;
    public List<STROOPData> levelsStroop = new List<STROOPData>();
    public List<D2Data> levels = new List<D2Data>();
    public bool isPlaying;
    public int currentLvl;
    public int maxLevels;
    public int secondsPerLvl = 20;
    public GameObject WaitingCanvas;
    public bool continueGame;
    public Text InfoText;
    public GameObject ReturnToMainMenu;
    public delegate void SaveResults();
    public static event SaveResults OnSaveResults;
    public AudioSource canvasAudio;
    bool isSaved;

    public GameObject trofeo;


    enum States
    { 
        Playing,
        NextLevel,
        EndingGame,
        SavingResults
    }

    States currentState;

    // Use this for initialization
    void Start ()
    {
        currentLvl = 0;
        LoadGameData(game);
        StartCoroutine(FSM());
        if (WaitingCanvas != null)
        {
            WaitingCanvas.SetActive(false);

        }

    }

    public void StartGame()
    {
        isPlaying = true;
    }

    void ChangeState(States nextState)
    {
        //Debug.Log(currentState + " ----> " + nextState);
        currentState = nextState;
    }

    IEnumerator FSM()
    {

        while (true)
        {
            //Debug.Log("Empezando juego" + " ----> " + currentState.ToString());

            yield return StartCoroutine(currentState.ToString());
        }
    }


    IEnumerator Playing()
    {
        while (currentState == States.Playing && isPlaying)
        {
            yield return new WaitForSeconds(secondsPerLvl);
            if (SceneManager.GetActiveScene().name != "d2")
            {
                Handheld.Vibrate();

            }

            ChangeState(States.SavingResults);
        }

    }

    IEnumerator SavingResults()
    {
        continueGame = false;

        if (currentLvl < maxLevels)
        {
            if (WaitingCanvas != null)
            {
                if (canvasAudio != null)
                {
                    canvasAudio.Play();

                }
                if (game == "STROOPConfig")
                {
                    WaitingCanvas.SetActive(true);

                    InfoText.text = "Pulsa el cubo pintado con la tinta que tiene la palabra";
                   
                }
                WaitingCanvas.SetActive(true);

            }

        }
        else
        {
            ChangeState(States.EndingGame);

        }

        while (currentState == States.SavingResults)
        {
       

            if (OnSaveResults != null && !isSaved)
            {
                isSaved = true;
                OnSaveResults();
          
            }
            
            yield return new WaitForSeconds(1);

            if (WaitingCanvas != null)
            {
                if (game != "STROOPConfig" || continueGame)
                {
                    continueGame = false;
                    WaitingCanvas.SetActive(false);
                    ChangeState(States.NextLevel);

                }
                

            }
           

        }

    }


    IEnumerator NextLevel()
    {
        isSaved = false;

        while (currentState == States.NextLevel)
        {

            if (currentLvl < maxLevels)
            {
                currentLvl++;

                if (game == "STROOPConfig")
                {
                    this.gameObject.GetComponentInChildren<STROOP_GenerateLvl>().LevelToGenerate(currentLvl);

                }
                if  (game == "D2Config")
                {
                    this.gameObject.GetComponentInChildren<D2_GenerateLevel>().LevelToGenerate(currentLvl);

                }

                ChangeState(States.Playing);


            }
            else
            {
                //print("FIN JUEGO");

                ChangeState(States.EndingGame);
            }
            yield return 0;

        }

    }



    IEnumerator EndingGame()
    {

        if (OnSaveResults != null && !isSaved)
        {
            isSaved = true;

            OnSaveResults();
        }
        while (currentState == States.EndingGame)
        {

            if (WaitingCanvas != null)
            {
                WaitingCanvas.GetComponentInChildren<Text>().text = "¡Enhorabuena!";
                WaitingCanvas.SetActive(true);
                Image image = WaitingCanvas.GetComponentInChildren<Image>();
                var tempColor = image.color;
                tempColor.a = 1f;
                image.color = tempColor;
                ReturnToMainMenu.SetActive(true);
                trofeo.SetActive(true);
            }
            

            // PANTALLA DE FIN DE JUEGO Y SALIR AL MENU
            //SALIR AL MENU ENVIA MENSAJE CON LOS DATOS DEL JSON A LA APLIACION MAESTRA


            yield return 0;
            StopAllCoroutines();
        
        }

    }

    public void LoadGameData(string dataFile)
    {
        //------------------------------ PROVISIONAL--------------------//
        //dataFile = "D2Config";

        //-------------------------------------------------------------//

        TextAsset lvlData = Resources.Load<TextAsset>(dataFile);
        string[] data = lvlData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            if (dataFile == "STROOPConfig")
            {
                STROOPData game = new STROOPData();
                if (row[1] != "")
                {
                    int.TryParse(row[0], out game.lvl);
                    for (int x = 1; x < row.Length; x++)
                    {
                        game.dataValues[x-1] = row[x];
                    }

                }

                levelsStroop.Add(game);
            }
            else
            {
                if (dataFile == "D2Config")
                {
                    D2Data gameD2 = new D2Data();
                    if (row[1] != "")
                    {
                        int.TryParse(row[0], out gameD2.lvl);
                        for (int x = 1; x < row.Length; x++)
                        {
                            gameD2.dataValues[x - 1] = row[x];
                           // print(row[x]);
                        }
                    }
                    levels.Add(gameD2);
                }
                if (dataFile == "SombrasConfig")
                {
                    //////SEGUIR AQUI
                    //print("Cargar fichero configuracion figuras");
                }

            }
        }
        if (dataFile == "STROOPConfig")
        {
            this.gameObject.GetComponentInChildren<STROOP_GenerateLvl>().LevelToGenerate(0);

        }


    }


    public void ContinueGame()
    {
        continueGame = true;
    }

}
