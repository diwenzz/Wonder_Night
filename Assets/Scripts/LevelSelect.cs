using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
	private AssetBundle myBundle;
	private string[] scenePaths;

	public void StartGame()
	{
		//switching to game scene
		SceneManager.LoadScene("LoadingScene");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
