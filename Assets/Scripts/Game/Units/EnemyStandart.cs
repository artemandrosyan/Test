using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandart : Enemy {
	private GameData gameData = GameData.getInstance();
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
    /// Move object
    /// </summary>
	public override void move()
	{
		Vector2 velocity = enemyRB.velocity;
		velocity.x = xVel;
		velocity.y = yVel;

		enemyRB.velocity = velocity;
	}




}
