using UnityEngine;
using System.Collections;

/**
 * Adds obstacles in the way of the player character.
 */
public class LevelGenerator
{
	private int elapsed = 0;
	private ObstacleFactory factory;
	private GameObject treadmill;
	private System.Random rnd;
	private Queue	pendingObstacles;

	public LevelGenerator (GameObject treadmill)
	{
		this.factory = new ObstacleFactory ();
		this.treadmill = treadmill;
		this.pendingObstacles = new Queue ();

		this.rnd = new System.Random ();
	}
	
	public void Update ()
	{
		string obstacle_type = "";

		if (this.elapsed % 106 == 0) {
			pendingObstacles.Enqueue ("brickwall");

			if (this.rnd.Next (0, 20) < 1) {
				pendingObstacles.Enqueue ("floorgap01");

				if (this.rnd.Next (0, 3) < 1) {
					pendingObstacles.Enqueue ("coin");
				}

			} else {
				pendingObstacles.Enqueue ("floortype01");

				// more stuff here

				if (this.rnd.Next (0, 3) < 1) {
					if (this.rnd.Next (0, 2) < 1) {
						pendingObstacles.Enqueue ("crate");
					} else {
						pendingObstacles.Enqueue ("wallsign");
					}
				} else {
					pendingObstacles.Enqueue ("coin");
				}

			}
		}

		while (pendingObstacles.Count>0) {
			obstacle_type = (string)pendingObstacles.Dequeue ();
			GameObject new_obstacle = this.factory.CreateObstacle (obstacle_type);
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.transform;
		}

		/*
		if(obstacle_type!="")
		{
			GameObject new_obstacle = this.factory.CreateObstacle( obstacle_type );
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.transform;
		}*/

		this.elapsed++;
	}
	
}