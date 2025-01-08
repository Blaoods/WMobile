using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // N�cessaire pour la gestion des sc�nes

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad = "GameScene";  // Nom de la sc�ne � charger

    public bool GoTimer;
    float Timer;
    public float MaxTimer;


    public void Update()
    {
        if (GoTimer == true)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= MaxTimer)
        {
            StartSceneChange();
        }
    }

    public void LetzGo()
    {
        GoTimer = true;
    }

    public void StartSceneChange()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
