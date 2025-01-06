using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float maxDistance = 100;

    private RaycastHit hit;
    private Raycastable previousRaycastable;
    private Raycastable raycastable;

    public static bool waitForNextFrame = false;

    public LayerMask ignorePlayerMask;

    private Camera refCamera;

    public bool CameraFixe = false;
    public bool stopWhenPaused = true;
    public bool freeMouseOnStart = false;

    private void Start()
	{
        refCamera = GetComponent<Camera>();

        if(freeMouseOnStart)
		{
            Cursor.lockState = CursorLockMode.None;
		}
    }

	// Update is called once per frame
	void Update()
    {
        if(waitForNextFrame || (Time.timeScale == 0 && stopWhenPaused))
		{
            return;
		}

        if(CameraFixe)
		{
            Physics.Raycast(refCamera.ScreenPointToRay(new Vector3(InputListener.instance.touch_1_position.x, InputListener.instance.touch_1_position.y, maxDistance)), out hit/*, ignorePlayerMask*/);
        }
        else
		{
            Physics.Raycast(refCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, maxDistance)), out hit/*, ignorePlayerMask*/);
        }

        if (hit.collider != null)
        {
            if(hit.collider.name != "Avatar")
			{
                raycastable = hit.collider.GetComponent<Raycastable>();

                if ((hit.point - transform.position).magnitude > maxDistance)
                {
                    raycastable = null;
                }
            }
        }
        else
        {
            raycastable = null;
        }
        
        if(previousRaycastable != raycastable)
		{
            if (previousRaycastable != null)
            {
                previousRaycastable.PerformOnOut();
            }

            previousRaycastable = raycastable;

            if (raycastable != null)
            {
                raycastable.PerformOnOver();
            }
        }

        if (raycastable != null)
        {
            if (InputListener.instance.touch_1_contactDown)
            {
                raycastable.PerformOnInteract();
            }

            if (InputListener.instance.touch_1_contactUp)
            {
                raycastable.PerformOnUp();
            }
        }

        
    }

	private void LateUpdate()
	{
		if(waitForNextFrame)
		{
            waitForNextFrame = false;
        }
	}
}
