using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnPickup : MonoBehaviour
{
	public string objectName;
	public UnityEvent myEvent;

	void Update()
	{
		if (Inventaire.objectList.Contains(objectName))
		{
			myEvent.Invoke();
			enabled = false;
		}
	}
}
