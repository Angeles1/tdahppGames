using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageToRN : MonoBehaviour {

    JsonManager levelsPoints;
    public string gameName;
    public GameObject result;

    string message;

    void Awake()
    {
        
        //DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        UnityMessageManager.Instance.OnRNMessage += OnMessage;
    }

    void OnDestroy()
    {
        UnityMessageManager.Instance.OnRNMessage -= OnMessage;
    }


    //llamada desde RN
    void OnMessage(MessageHandler message)
    {
        var data = message.getData<string>();
        //message.send(new { CallbackTest = "soy el mensaje de D2" });
        this.gameObject.GetComponentInChildren<Text>().text = data;

    }


    void HandleMessage(string message)
    {
        //Debug.Log("onMessage:" + message);
    }

    private void Start()
    {
        //UnityMessageManager.Instance.SendMessageToRN("hola caracola");
        //EndingGame("d2");
    }


    public void EndingGame(string gameName)
    {
        message = "";
        if(gameName == "d2")
        {

            message = result.GetComponent<Results>().dataAsJson;
        }
        if (gameName == "stroop")
        {

            message = result.GetComponent<ResultsStroop>().dataAsJson;
            
        }

        if (gameName == "mole")
        {

            message = result.GetComponent<ResultWhacaMole>().dataAsJson;

        }
        if (gameName == "sombras")
        {

            message = result.GetComponent<ResultsSombras>().dataAsJson;
        }

        SendMessageToRN(message);
    }

    //LLAMADA DESDE UNITY
    public void SendMessageToRN(string message)
    {
        ////////////// DESCOMENTAR PARA ENVIAR MENSAJES

        UnityMessageManager.Instance.SendMessageToRN(message);
        //print(message);
        //if (message == "Return")
        {
          //  Application.Quit();
        } 
   
    }
    
 

    

  


}
