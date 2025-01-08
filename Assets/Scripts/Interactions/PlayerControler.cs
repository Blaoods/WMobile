using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public GameObject R_Check;
    public GameObject L_Check;
    public GameObject D_Check;
    public GameObject U_Check;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void RightMovement()
    {   
        if (R_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
            speed = maxSpeed;
            canMove = false;
            R_Check.GetComponent<BoxCollider>().enabled = true;
            L_Check.GetComponent<BoxCollider>().enabled = false;
            D_Check.GetComponent<BoxCollider>().enabled = false;
            U_Check.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void LeftMovement()
    {
        if (L_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90f);
            speed = maxSpeed;
            canMove = false;

            R_Check.GetComponent<BoxCollider>().enabled = false;
            L_Check.GetComponent<BoxCollider>().enabled = true;
            D_Check.GetComponent<BoxCollider>().enabled = false;
            U_Check.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DownMovement()
    {
        if (D_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
            speed = maxSpeed;
            canMove = false;


            R_Check.GetComponent<BoxCollider>().enabled = false;
            L_Check.GetComponent<BoxCollider>().enabled = false;
            D_Check.GetComponent<BoxCollider>().enabled = true;
            U_Check.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void UpMovement()
    {
        if (U_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0f);
            speed = maxSpeed;
            canMove = false;


            R_Check.GetComponent<BoxCollider>().enabled = false;
            L_Check.GetComponent<BoxCollider>().enabled = false;
            D_Check.GetComponent<BoxCollider>().enabled = false;
            U_Check.GetComponent<BoxCollider>().enabled = true;

        }
    }
    /*public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            speed = 0;
        }
    }*/
}
