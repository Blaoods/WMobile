using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public string[] tagsAndNamesToCheck;
	public Transform targetTeleport;

	private int i;

	private void OnTriggerEnter(Collider other)
	{
		if (CheckTagAndName(other.gameObject))
		{
			other.transform.position = targetTeleport.position;
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
