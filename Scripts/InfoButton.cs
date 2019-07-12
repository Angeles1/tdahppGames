using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {

    bool touching;
    public GameObject InfoPanel;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;

    private void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();

    }



    public void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
           

            if (Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                InfoPanel.SetActive(true); // esto no va a ir aqui
                touching = true; // esto tampoco va aqui
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                if (hitInfo.collider != null)
                {
                    //NUNCA ENTRA AQUI AIUDA!!!!!
                    //InfoPanel.SetActive(true);
                    //touching = true;

                    //Debug.Log(hitInfo.collider.name);
              

                    //print(hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.name.Contains("InfoPanel"))
                    {
                        //if (firstTouch == true)
                        {
                            // if (OnTargetedBall != null)
                            //   OnTargetedBall();
                            print("toco22222222222");

                            //OnTargetBall.Invoke();
                            //firstTouch = false;
                            InfoPanel.SetActive(true);

                        }
                    }
    
                     

                }
                
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {

                //FeedBackToUserWhenSelectAnItem(false);
                print("suelto");
                InfoPanel.SetActive(false);

            }

        }
    }
}
