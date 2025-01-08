using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAnimation : MonoBehaviour
{
    // Référence publique à l'objet qui contient l'Animator
    public GameObject animationObject;  // L'objet qui a l'Animator
    private Animator animator;

    void Start()
    {
        // Vérifier si l'objet d'animation est assigné
        if (animationObject != null)
        {
            animator = animationObject.GetComponent<Animator>();  // Récupérer l'Animator de l'objet assigné

            if (animator != null)
            {
                // Lancer l'animation au démarrage
                StartGameAnimation();
            }
            else
            {
                Debug.LogError("L'objet ne contient pas d'Animator !");
            }
        }
        else
        {
            Debug.LogError("Aucun objet d'animation assigné !");
        }
    }

    // Fonction pour démarrer l'animation
    void StartGameAnimation()
    {
        // Lancer l'animation via un trigger
        animator.SetTrigger("StartGame");  // Assurez-vous d'avoir un trigger 'StartGame' dans l'Animator
    }
}


