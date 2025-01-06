using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleTeleport : MonoBehaviour
{
    public GameObject toBeTeleported;
    public Transform targetTeleport;

    public UnityEvent eventOnTeleport;

    public void PerformTeleport()
    {
        toBeTeleported.transform.position = targetTeleport.position;
        toBeTeleported.transform.rotation = targetTeleport.rotation;

        eventOnTeleport.Invoke();

    }
}