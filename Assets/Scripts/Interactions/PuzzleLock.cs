using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleLock : MonoBehaviour
{
    public UnityEvent eventOnUnlocked;
	public UnityEvent eventOnLocked;

    public void Unlock(string objectName)
	{
        if(Inventaire.objectList.Contains(objectName))
		{
			eventOnUnlocked.Invoke();
		}
		else
		{
			eventOnLocked.Invoke();
		}
	}
}
