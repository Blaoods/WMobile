using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject Swipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Player1.GetComponent<PlayerControler>().canMove == true)&& (Player2.GetComponent<PlayerControler>().canMove == true))
        {
            Swipe.SetActive(true);
        }
        else
        {
            Swipe.SetActive(false);
        }
    }
}
