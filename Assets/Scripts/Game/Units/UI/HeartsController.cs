using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour {

	private GameData gameData = GameData.getInstance();
	public Text heartsCount;

	
	// Update is called once per frame
	void Update () {
		heartsCount.text = gameData.hearts.ToString();
		heartsRunOut ();
	}

    /// <summary>
    /// handles the case when lives are over
    /// </summary>
    void heartsRunOut()
	{
		if (gameData.hearts == 0) 
		{	
			gameData.gameOverState = true;
		}
	}


}
