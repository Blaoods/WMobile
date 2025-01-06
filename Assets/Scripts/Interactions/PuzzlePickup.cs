using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePickup : MonoBehaviour
{
	public UnityEvent eventOnPickup;
    public void Pickup(string objectName)
	{
        Inventaire.objectList.Add(objectName);
		eventOnPickup.Invoke();
	}
}
