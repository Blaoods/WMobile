using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    // Paramètres du tremblement
    public float shakeDuration = 0.5f; // Durée du tremblement
    public float shakeStrength = 0.2f; // Intensité du tremblement
    public int shakeVibrato = 10; // Nombre d'oscillations (vibrations)
    public float shakeRandomness = 90f; // Variabilité de la direction du tremblement

    private Vector3 originalPosition; // La position originale de la caméra

    void Start()
    {
        // Sauvegarde de la position originale de la caméra
        originalPosition = transform.localPosition;
    }

    // Méthode pour démarrer le tremblement avec des paramètres personnalisés
    public void TriggerShake(float duration, float intensity)
    {
        // Appliquer le tremblement avec DOTween
        transform.DOShakePosition(duration, intensity, shakeVibrato, shakeRandomness, false, true);
    }

    // Méthode pour réinitialiser la position de la caméra (si nécessaire)
    public void ResetCameraPosition()
    {
        transform.localPosition = originalPosition;
    }
}
