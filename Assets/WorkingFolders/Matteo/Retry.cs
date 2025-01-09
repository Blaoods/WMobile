using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    public string SampleScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SampleScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
