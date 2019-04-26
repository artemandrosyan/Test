using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public abstract class Enemy: MonoBehaviour, ISpawnEvent {
    /// <summary>
    ///Sprite of death of the enemy
    /// </summary>
     [SerializeField]
	protected GameObject death;

    /// <summary>
    ///RigidBody for the movement of the object
    /// </summary>
    protected Rigidbody2D enemyRB;
    protected ObjectPool pool;
    /// <summary>
    /// х axis speed
    /// </summary>
    [SerializeField]
	protected float xVel;
    /// <summary>
    /// y axis speed
    /// </summary>
    [SerializeField]
	protected float yVel;
    /// <summary>
    /// Move object
    /// </summary>
    public abstract void move();
    /// <summary>
    /// Reaction to the touch of the object
    /// </summary>
    public abstract void enemyOnClick();
    /// <summary>
    /// Places an object in the pool when it reaches the bottom
    /// </summary>
     public abstract void rangeReached();
    /// <summary>
    /// Lower bound of the playing field
    /// </summary>
    private const float DOWNRANGE = -3.5f;
    /// <summary>
    /// Duration for moving object
    /// </summary>
	protected const float DURATION = 1f;
    /// <summary>
    /// Time to destroy death sprite
    /// </summary>
	protected const float TIME_TO_DESTROY = 0.2f;
    protected float update;
	private GameData gameData = GameData.getInstance();

	void OnMouseDown() 
	{
		enemyOnClick ();
	}

	void FixedUpdate()
	{	rangeChecker ();
		move ();
		gameOverRespawn ();
		update += Time.deltaTime;
	}
    /// <summary>
    /// Posting death sprite
    /// </summary>
	protected void afterDeath()
	{
		GameObject temp = (GameObject)Instantiate(death, this.transform.position, this.transform.rotation);
		Destroy (temp, TIME_TO_DESTROY);
	}
    /// <summary>
    /// Checks for reaching the border
    /// </summary>
    void rangeChecker()
	{
		if (this.transform.position.y < DOWNRANGE) {
			rangeReached ();
		}
	}

	public void OnSpawned(GameObject targetGameObject, ObjectPool sender)
	{ 
		 pool = sender;
	}

	public virtual void Start()
	{	
		enemyRB = GetComponent<Rigidbody2D> ();
		update = 0;
	}
    /// <summary>
    /// Removes all objects from the playing field
    /// </summary>
    void gameOverRespawn()
	{
		if (gameData.gameOverState == true) 
		{
			pool.DespawnAllActiveObjects ();
			update = 0;
		}
	}
}
