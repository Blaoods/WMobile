using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    
    public float shakeDuration = 0.5f; 
    public float shakeStrength = 0.2f; 
    public int shakeVibrato = 10; 
    public float shakeRandomness = 90f; 

    private Vector3 originalPosition; 

    public bool isInMenu = false;
   

    void Start()
    { 
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (isInMenu)
        {     
            ResetCameraPosition();
        }
    }

    
    public void TriggerShake(float duration, float intensity)
    {
        
        if (!isInMenu)
        {
            transform.DOShakePosition(duration, intensity, shakeVibrato, shakeRandomness, false, true);
        }
    }

    
    public void ResetCameraPosition()
    {
        transform.localPosition = originalPosition;
    }

    public void SetMenuState(bool state)
    {
        isInMenu = state;
    }
}
