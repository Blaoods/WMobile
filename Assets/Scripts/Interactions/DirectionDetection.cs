using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
    public bool canDoInput;

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
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().Swipe.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            canDoInput = true;
        }
    }
}
