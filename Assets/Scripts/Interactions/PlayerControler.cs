using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool Speed_Check;
    public GameObject R_Check;
    public GameObject L_Check;
    public GameObject D_Check;
    public GameObject U_Check;
    public GameObject Swipe;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        Speed_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Speed_Check == true)
        {
            Swipe.SetActive(false);
        }
        else
        {
            Swipe.SetActive(true);
        }
    }

    public void RightMovement()
    {   
        if (R_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
            speed = maxSpeed;
        }
        Speed_Check = true;
    }

    public void LeftMovement()
    {
        if (L_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90f);
            speed = maxSpeed;
        }
        Speed_Check = true;
    }
    public void DownMovement()
    {
        if (D_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
            speed = maxSpeed;
        }
        Speed_Check = true;
    }
    public void UpMovement()
    {
        if (U_Check.GetComponent<DirectionDetection>().canDoInput == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0f);
            speed = maxSpeed;
        }
        Speed_Check = true;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            speed = 0;
            Speed_Check = false;
        }
    }
}
