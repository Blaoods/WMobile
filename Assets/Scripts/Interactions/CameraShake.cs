using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    // Param�tres du tremblement
    public float shakeDuration = 0.5f; // Dur�e du tremblement
    public float shakeStrength = 0.2f; // Intensit� du tremblement
    public int shakeVibrato = 10; // Nombre d'oscillations (vibrations)
    public float shakeRandomness = 90f; // Variabilit� de la direction du tremblement

    private Vector3 originalPosition; // La position originale de la cam�ra

    void Start()
    {
        // Sauvegarde de la position originale de la cam�ra
        originalPosition = transform.localPosition;
    }

    // M�thode pour d�marrer le tremblement avec des param�tres personnalis�s
    public void TriggerShake(float duration, float intensity)
    {
        // Appliquer le tremblement avec DOTween
        transform.DOShakePosition(duration, intensity, shakeVibrato, shakeRandomness, false, true);
    }

    // M�thode pour r�initialiser la position de la cam�ra (si n�cessaire)
    public void ResetCameraPosition()
    {
        transform.localPosition = originalPosition;
    }
}
