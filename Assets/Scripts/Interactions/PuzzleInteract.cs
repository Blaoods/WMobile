using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleInteract : MonoBehaviour
{
    public string interactButton;

    public string[] tagsAndNamesToCheck;

    public UnityEvent eventOnInteract;
    public UnityEvent eventOnEnter;
    public UnityEvent eventOnExit;

    public int numberInTrigger = 0;
    private int i;

    // Update is called once per frame
    void Update()
    {
        if(numberInTrigger > 0 && Input.GetButtonDown(interactButton))
		{
            eventOnInteract.Invoke();
        }        
    }

	private void OnDisable()
	{
        numberInTrigger = 0;
        eventOnExit.Invoke();
    }

	private void OnTriggerEnter(Collider other)
    {
        if (CheckTagAndName(other.gameObject))
        {
            numberInTrigger += 1;

            if (numberInTrigger == 1)
            {
                eventOnEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckTagAndName(other.gameObject))
        {
            numberInTrigger -= 1;
			
			if(numberInTrigger < 0)
			{
				numberInTrigger = 0;
			}
			
			if (numberInTrigger == 0)
			{
				eventOnExit.Invoke();
			}
        }

        
    }

    bool CheckTagAndName(GameObject toBeChecked)
    {
        if (tagsAndNamesToCheck.Length == 0)
        {
            return true;
        }

        for (i = 0; i < tagsAndNamesToCheck.Length; i++)
        {
            if (toBeChecked.name == tagsAndNamesToCheck[i] || toBeChecked.tag == tagsAndNamesToCheck[i])
            {
                return true;
            }
        }

        return false;
    }
}
