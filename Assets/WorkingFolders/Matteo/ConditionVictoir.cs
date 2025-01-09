using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject player1;  
    public GameObject player2;  
    public GameObject objectToAppear;
    public GameObject DeletSwipe;
    private float Timer;  
    public float MaxTimer = 3f;  
    public float threshold = 0.1f;

    void Update()
    {
        
        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);

        
        if (distance <= threshold)
        {
            DeletSwipe.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().isInMenu = true;


            Timer += Time.deltaTime;

            // Si le timer atteint le MaxTimer, activer l'objet
            if (Timer >= MaxTimer)
            {
                objectToAppear.SetActive(true);

            }
        }
        else
        {
            // Si les joueurs sont éloignés, réinitialiser le timer et désactiver l'objet
            Timer = 0f;
            objectToAppear.SetActive(false);
        }
    }
}