using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAnimation : MonoBehaviour
{
    // R�f�rence publique � l'objet qui contient l'Animator
    public GameObject animationObject;  // L'objet qui a l'Animator
    private Animator animator;

    void Start()
    {
        // V�rifier si l'objet d'animation est assign�
        if (animationObject != null)
        {
            animator = animationObject.GetComponent<Animator>();  // R�cup�rer l'Animator de l'objet assign�

            if (animator != null)
            {
                // Lancer l'animation au d�marrage
                StartGameAnimation();
            }
            else
            {
                Debug.LogError("L'objet ne contient pas d'Animator !");
            }
        }
        else
        {
            Debug.LogError("Aucun objet d'animation assign� !");
        }
    }

    // Fonction pour d�marrer l'animation
    void StartGameAnimation()
    {
        // Lancer l'animation via un trigger
        animator.SetTrigger("StartGame");  // Assurez-vous d'avoir un trigger 'StartGame' dans l'Animator
    }
}


