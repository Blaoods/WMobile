using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f; // Durée du tremblement
    public float shakeIntensity = 0.1f; // Intensité du tremblement
    public float shakeFrequency = 0.1f; // Fréquence du tremblement

    private Vector3 originalPosition; // Position originale de la caméra
    private bool isShaking = false;

    void Start()
    {
        // Stocker la position initiale de la caméra
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Si la caméra doit trembler
        if (shakeDuration > 0)
        {
            if (!isShaking)
            {
                // Commencer à trembler
                isShaking = true;
                InvokeRepeating("ShakeCamera", 0f, shakeFrequency); // Déclenche le tremblement à un intervalle défini
            }

            // Réduire la durée du tremblement
            shakeDuration -= Time.deltaTime;

            if (shakeDuration <= 0)
            {
                // Arrêter le tremblement
                CancelInvoke("ShakeCamera");
                transform.localPosition = originalPosition;
                isShaking = false;
            }
        }
    }

    void ShakeCamera()
    {
        // Calculer une position aléatoire pour simuler le tremblement
        float shakeOffsetX = Random.Range(-1f, 1f) * shakeIntensity;
        float shakeOffsetY = Random.Range(-1f, 1f) * shakeIntensity;

        // Appliquer l'offset à la position locale de la caméra
        transform.localPosition = new Vector3(originalPosition.x + shakeOffsetX, originalPosition.y + shakeOffsetY, originalPosition.z);
    }

    // Fonction pour démarrer le tremblement depuis un autre script
    public void TriggerShake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
