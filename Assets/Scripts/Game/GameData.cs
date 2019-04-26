public class GameData {
    /// <summary>
    ///Number of lives of the character
    /// </summary>
    public int hearts;
    /// <summary>
    ///loss status
    /// </summary>
    public bool gameOverState;

	private static GameData instance;

	private GameData()
	{
		hearts = 3;
		gameOverState = false;
	}

	public static GameData getInstance(){
		if(instance == null){
			instance = new GameData();
		}
		return instance;
	}
}
