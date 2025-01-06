using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swipe : MonoBehaviour
{

    public UnityEvent OnMouseEnterEvent;
    public UnityEvent OnMouseExitEvent;

    public UnityEvent OnSwipeCompleted;

    public bool isSwiping;

    public float swipeTime = 0.2f;
    private float startTime;

    public Vector2 swipeDistance = new Vector2(200,0);
    private Vector2 startPos;

    private Vector2 customMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

#if ENABLE_INPUT_SYSTEM
        // New input system backends are enabled.
        customMousePosition = InputListener.instance.touch_1_position;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
    // Old input backends are enabled.
    customMousePosition = Input.mousePosition;
#endif

        if (isSwiping == true)
		{
            if (Time.time - startTime < swipeTime)
            {
                if (swipeDistance.x > 0 && (customMousePosition - startPos).x > swipeDistance.x)
                {
                    OnSwipeCompleted.Invoke();
                }
                else if (swipeDistance.x < 0 && (customMousePosition - startPos).x < swipeDistance.x)
                {
                    OnSwipeCompleted.Invoke();
                }
                else if (swipeDistance.y > 0 && (customMousePosition - startPos).y > swipeDistance.y)
                {
                    OnSwipeCompleted.Invoke();
                }
                else if (swipeDistance.y < 0 && (customMousePosition - startPos).y < swipeDistance.y)
                {
                    OnSwipeCompleted.Invoke();
                }
            }
        }
        
    }

    public void OnMouseDown()
	{
        isSwiping = true;
        startTime = Time.time;
        startPos = customMousePosition;

    }

    public void OnMouseUp()
    {
        isSwiping = false;
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
