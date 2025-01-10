using UnityEngine;
using DG.Tweening;

public class PlayerControler : MonoBehaviour
{
    public float rayDistance = 10f; // Distance maximale du raycast
    public string stopTag = "wall"; // Tag des objets qui arrêtent le raycast
    public float offsetDistance = 1f; // Distance avant le point d'impact

    public Vector3 DestinationPosition;

    public float speed;

    public CameraShake Camera;

    public bool GoTimerDash;
    public float TimerDash;
    public float MaxTimerDash;

    public void TurnRight()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, -90);
        GoTimerDash = true;
    }

    public void TurnLeft()
    {
        gameObject.transform.rotation = Quaternion.Euler(-180, 90, -90);
        GoTimerDash = true;
    }

    public void TurnDown()
    {
        gameObject.transform.rotation = Quaternion.Euler(90, 90, -90);
        GoTimerDash = true;
    }

    public void TurnUp()
    {
        gameObject.transform.rotation = Quaternion.Euler(-90, 90, -90);
        GoTimerDash = true;
    }


    void Update()
    {
        if (GoTimerDash == true)
        {
            TimerDash += Time.deltaTime;
        }

        if (TimerDash >= MaxTimerDash)
        {
            gameObject.transform.DOMove(DestinationPosition, speed).SetEase(Ease.OutExpo);
            GoTimerDash = false;
            TimerDash = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //gameObject.transform.position = DestinationPosition;
            /*gameObject.transform.DOMove(DestinationPosition, speed).SetEase(Ease.OutExpo).OnComplete(() =>
            {*/
                Camera.TriggerShake(0.5f, 0.2f);
            //});
        }

        Vector3 rayStart = transform.position;
        Vector3 forwardDirection = transform.forward;

        // Debug Raycast
        Debug.DrawRay(rayStart, forwardDirection * rayDistance, Color.red);

        // Lancer le raycast
        if (Physics.Raycast(rayStart, forwardDirection, out RaycastHit hit, rayDistance))
        {

            if (hit.collider.CompareTag(stopTag))
            {
                Vector3 adjustedPosition = hit.point - forwardDirection * offsetDistance;

                // Exécuter une action pour arrêter le traitement
                HandleCollision(adjustedPosition);
                return;
            }
        }
    }


    // Gérer ce qui se passe quand le raycast s'arrête
    private void HandleCollision(Vector3 impactPoint)
    {
        DestinationPosition = impactPoint;
    }
}