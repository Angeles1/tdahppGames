using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFromRN : MonoBehaviour {
    public Text text;
    public GameObject Canvas;
    void Awake()
    {
        UnityMessageManager.Instance.OnMessage += ToggleRotate;
    }

    void OnDestroy()
    {
        UnityMessageManager.Instance.OnMessage -= ToggleRotate;
    }

     void ToggleRotate(string message)
    {
        
        Debug.Log("onMessage:" + message);
        text.text = message;
        if (Canvas != null)
        {
            Canvas.GetComponent<LevelCondition>().ReciveMessage(message);
        }
        
    }

    public void Testing()
    {
        ToggleRotate("usuario con ID:1, JUEGOS: D2 STROOP");
    }
}
