using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f; // Dur�e du tremblement
    public float shakeIntensity = 0.1f; // Intensit� du tremblement
    public float shakeFrequency = 0.1f; // Fr�quence du tremblement

    private Vector3 originalPosition; // Position originale de la cam�ra
    private bool isShaking = false;

    void Start()
    {
        // Stocker la position initiale de la cam�ra
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Si la cam�ra doit trembler
        if (shakeDuration > 0)
        {
            if (!isShaking)
            {
                // Commencer � trembler
                isShaking = true;
                InvokeRepeating("ShakeCamera", 0f, shakeFrequency); // D�clenche le tremblement � un intervalle d�fini
            }

            // R�duire la dur�e du tremblement
            shakeDuration -= Time.deltaTime;

            if (shakeDuration <= 0)
            {
                // Arr�ter le tremblement
                CancelInvoke("ShakeCamera");
                transform.localPosition = originalPosition;
                isShaking = false;
            }
        }
    }

    void ShakeCamera()
    {
        // Calculer une position al�atoire pour simuler le tremblement
        float shakeOffsetX = Random.Range(-1f, 1f) * shakeIntensity;
        float shakeOffsetY = Random.Range(-1f, 1f) * shakeIntensity;

        // Appliquer l'offset � la position locale de la cam�ra
        transform.localPosition = new Vector3(originalPosition.x + shakeOffsetX, originalPosition.y + shakeOffsetY, originalPosition.z);
    }

    // Fonction pour d�marrer le tremblement depuis un autre script
    public void TriggerShake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
