using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Tap : MonoBehaviour
{
    public UnityEvent OnMouseEnterEvent;
    public UnityEvent OnMouseExitEvent;

    public UnityEvent OnMouseDownEvent;

    public bool doubleTap = false;

    private float timeOfLastTap = 0;
    public float doubleTapTime = 0.2f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // Fonction appelée pour changer de scène
    public void ChangeScene(string sceneName)
    {
        // Charge la scène en utilisant son nom
        SceneManager.LoadScene(sceneName);
    }


public void OnMouseDown()
	{
        if(doubleTap == true)
		{
            if(Time.time - timeOfLastTap < doubleTapTime)
			{
                OnMouseDownEvent.Invoke();
            }

            timeOfLastTap = Time.time;
        }
        else
		{
            OnMouseDownEvent.Invoke();
        }
    }

    public void OnMouseEnter()
	{
        OnMouseEnterEvent.Invoke();
	}

    public void OnMouseExit()
    {
        OnMouseExitEvent.Invoke();
    }
}
