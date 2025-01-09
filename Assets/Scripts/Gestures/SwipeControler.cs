using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeControler : MonoBehaviour
{
    public Vector3 TouchPosition;
    public Vector3 TouchUpPosition;

    public float DiffX;
    public bool RightMove;
    public float DiffY;
    public bool UpMove;

    public UnityEvent RightEvent;
    public UnityEvent LeftEvent;
    public UnityEvent UpEvent;
    public UnityEvent DownEvent;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DiffX = 0;
            DiffY = 0;
            UpMove = false;
            RightMove = false;

            Vector3 mousePosition = Input.mousePosition;

            // Conversion de la position de la souris en coordonnées du monde
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            TouchPosition = worldPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            // Conversion de la position de la souris en coordonnées du monde
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            TouchUpPosition = worldPosition;

            DiffX = TouchPosition.x - TouchUpPosition.x;
            if (DiffX > 0)
            {
                RightMove = true;
            }
            else
            {
                RightMove = false;
            }

            DiffY = TouchPosition.y - TouchUpPosition.y;
            if (DiffY > 0)
            {
                UpMove = true;
            }
            else
            {
                UpMove = false;
            }

            if (DiffX < 0)
            {
                DiffX = DiffX * -1;
            }

            
            if (DiffY < 0)
            {
                DiffY = DiffY * -1;
            }

            if (DiffX > DiffY)
            {
                if (RightMove == true)
                {
                    Debug.Log("LeftInput");
                    LeftEvent.Invoke();
                }
                else
                {
                    Debug.Log("RightInput");
                    RightEvent.Invoke();
                }
            }
            else
            {
                if (UpMove == true)
                {
                    Debug.Log("DownInput");
                    DownEvent.Invoke();
                }
                else
                {
                    Debug.Log("UpInput");
                    UpEvent.Invoke();
                }
            }

        }
    }
}