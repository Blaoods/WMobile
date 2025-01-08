using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
    public bool canDoInput;

    public GameObject Player;

    public GameObject R_Check;
    public GameObject L_Check;
    public GameObject D_Check;
    public GameObject U_Check;

    public GameObject OppositeDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            canDoInput = false;

            R_Check.GetComponent<Collider>().enabled = true;
            L_Check.GetComponent<Collider>().enabled = true;
            D_Check.GetComponent<Collider>().enabled = true;
            U_Check.GetComponent<Collider>().enabled = true;

            OppositeDirection.GetComponent<DirectionDetection>().canDoInput = true;
            Player.GetComponent<PlayerControler>().canMove = true;
            Player.GetComponent<PlayerControler>().speed = 0;
        }
    }

    /*public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            canDoInput = true;
        }
    }*/
}