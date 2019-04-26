using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMove : MonoBehaviour {
	public Transform loseText, buttonRestart;
	public float duration = 3f;
	public bool UIOnScreen;
	private GameData gameData = GameData.getInstance();

	// Use this for initialization
	void Start () 
	{
		UIOnScreen = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		endOfGame ();
	}

    /// <summary>
    /// Responsible for the appearance of the end game menu
    /// </summary>
    void endOfGame()
	{
		if (gameData.gameOverState == true&&UIOnScreen == false) 
		{
			loseText.transform.DOMoveY (2f, duration, false);
			buttonRestart.transform.DOMoveX (0f, duration, false);
			UIOnScreen = true;
		}
	}
    /// <summary>
    /// Restarts the game
    /// </summary>
    public void RestartGame()
	{	gameData.hearts = 3;
		loseText.transform.DOMoveY (7f, duration, false);
		buttonRestart.transform.DOMoveX (-5f, duration, false);
		UIOnScreen = false;
		gameData.gameOverState = false;
	}
}
