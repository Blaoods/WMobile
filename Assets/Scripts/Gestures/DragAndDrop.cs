using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    public UnityEvent OnMouseEnterEvent;
    public UnityEvent OnMouseExitEvent;

    public bool isDraging = false;
    public LayerMask RaycastMask;
    private RaycastHit hit;

    public Collider zoneDeDrag;

    private Vector2 customMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

#if ENABLE_INPUT_SYSTEM
        // New input system backends are enabled.
        customMousePosition = InputListener.instance.touch_1_position;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
    // Old input backends are enabled.
    customMousePosition = Input.mousePosition;
#endif


        if (isDraging == true)
		{
            //Debug.Log("Mouse pos : "+ Input.mousePosition);
            if(Physics.Raycast(Camera.main.ScreenPointToRay(customMousePosition), out hit, RaycastMask))
			{
                //Debug.Log("Hit : " + hit.collider.name + " : "+ hit.point);
                transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                transform.position = zoneDeDrag.ClosestPointOnBounds(transform.position);
            }
		}

        
    }

    public void OnMouseDown()
	{
        isDraging = true;
	}

    public void OnMouseUp()
    {
        isDraging = false;
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
