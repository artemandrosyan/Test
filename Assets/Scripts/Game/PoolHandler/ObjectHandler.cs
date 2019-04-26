using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    DictionaryObjectPool _objectpool;
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    int numberstospawn = 10;
	private float updateUnit1;
	private float updateUnit2;
	private float updateUnit3;
	private float xforSpawnObj;
	public const float LEFTRANGE = -2.5f;
	public const float RIGHTRANGE = 2.5f;
	private GameData gameData = GameData.getInstance();

	// Use this for initialization
	void Start ()
    {
        _objectpool = new DictionaryObjectPool();
		_objectpool.AddObjectPool("Unit1", enemies[0], this.transform, 10);
		_objectpool.AddObjectPool("Unit2", enemies[1], this.transform, 10);
		_objectpool.AddObjectPool("Unit3", enemies[2], this.transform, 10);
    }

    // Update is called once per frame
    void Update ()
	{	
		spawnerUnits ();
    }

	void spawnerUnits()
	{
		if (gameData.gameOverState == false) 
		{
			xforSpawnObj = Random.Range (LEFTRANGE, RIGHTRANGE);
			updateUnit1 += Time.deltaTime;
			updateUnit2 += Time.deltaTime;
			updateUnit3 += Time.deltaTime;

			if (_objectpool["Unit1"].Count < numberstospawn&&updateUnit1>3f)
			{
				_objectpool["Unit1"].Spawn(this.transform.position+ new Vector3(xforSpawnObj,0f,1f));
				updateUnit1 = 0f;
			}

			if (_objectpool["Unit2"].Count < numberstospawn&&updateUnit2>5f)
			{
				_objectpool["Unit2"].Spawn(this.transform.position+ new Vector3(xforSpawnObj,0f,0f));
				updateUnit2 = 0f;
			}

			if (_objectpool["Unit3"].Count < numberstospawn&&updateUnit3>7f)
			{
				_objectpool["Unit3"].Spawn(this.transform.position+ new Vector3(xforSpawnObj,0f,-1f));
				updateUnit3 = 0f;
			}
		}
	}
}

