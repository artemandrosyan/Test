using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDiagonal : Enemy {
	private GameData gameData = GameData.getInstance();
    /// <summary>
    /// Move object
    /// </summary>
	public override void move()
	{
		Vector2 velocity = enemyRB.velocity;
		velocity.x = xVel;
		velocity.y = yVel;
		enemyRB.velocity = velocity;

	}
    /// <summary>
    /// Reaction to the touch of the object
    /// </summary>
	public override void enemyOnClick()
	{
		afterDeath ();
		pool.Despawn (this.gameObject);
	}
    /// <summary>
    /// Places an object in the pool when it reaches the bottom
    /// </summary>
    public override void rangeReached()
	{	
		gameData.hearts--;
		pool.Despawn (this.gameObject);
	}
    /// <summary>
    /// Realizes motion diagonally
    /// </summary>
    void diagonalMoveStarter()
	{
		if (update > 2f) 
		{	update = 0f;
			if (xVel == 0f) {
				xVel = predicate ();
			} else
				xVel = 0f;
		}
	}
    /// <summary>
    /// Realizes motion diagonally
    /// </summary>
    float predicate()
	{
		return this.transform.position.x > 0 ? -1f : 1f;
	}

	void Update()
	{	
		diagonalMoveStarter ();
	}
}

