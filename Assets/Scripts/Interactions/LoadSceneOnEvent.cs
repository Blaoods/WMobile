using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEvent : MonoBehaviour
{
	public Animator refAnime;
	private static string toBeLoaded;
	public static bool isLoading;

	public void StartLoadProcess(string sceneName)
	{
		if (isLoading == false)
		{
			isLoading = true;
			
			toBeLoaded = sceneName;

			refAnime.SetTrigger("Fondu");
		}
	}

    public void PerformLoad()
	{
		isLoading = false;

		SceneManager.LoadScene(toBeLoaded);		
	}

	public void PerformLoad(string sceneName)
	{
		isLoading = false;

		SceneManager.LoadScene(sceneName);
	}
}


