using UnityEngine;
using System.Collections;

/**
 * Adds obstacles in the way of the player character.
 */
public class LevelGenerator
{
	private int elapsed = 0;
	private ObstacleFactory factory;
	private TreadmillBehaviour treadmill;
	private System.Random rnd;
	private Queue	pendingObstacles;

	public LevelGenerator (TreadmillBehaviour treadmill)
	{
		this.factory = new ObstacleFactory ();
		this.treadmill = treadmill;

		this.pendingObstacles = new Queue ();

		this.rnd = new System.Random ();
	}
	
	public void Update ()
	{
		if (true) {
			uint interval = (uint)(-16.0f / this.treadmill.speed);

			if (this.elapsed % interval == 0) {
				pendingObstacles.Enqueue (new ObstacleRequest ("brickwall", 0, 0));

				if (this.rnd.Next (0, 5) < 1) {
					pendingObstacles.Enqueue (new ObstacleRequest ("floorgap01", 0, 0));

					//if (this.rnd.Next (0, 3) < 1) {
					pendingObstacles.Enqueue (new ObstacleRequest ("coin", 8, 0));
					//}

				} else {
					pendingObstacles.Enqueue (new ObstacleRequest ("floortype01", 0, 0));

					// more stuff here

					if (this.rnd.Next (0, 3) < 1) {
						if (this.rnd.Next (0, 2) < 1) {
							pendingObstacles.Enqueue (new ObstacleRequest ("crate", 0, 0));
							if (this.rnd.Next (0, 2) < 1) {
								pendingObstacles.Enqueue (new ObstacleRequest ("crate", 8, 0));
							}
						} else {
							pendingObstacles.Enqueue (new ObstacleRequest ("wallsign", 0, 0));
							if (this.rnd.Next (0, 2) < 1) {
								pendingObstacles.Enqueue (new ObstacleRequest ("wallsign", 8, 0));
							}
						}
					} else {
						pendingObstacles.Enqueue (new ObstacleRequest ("coin", 0, 0));
						if (this.rnd.Next (0, 2) < 1) {
							pendingObstacles.Enqueue (new ObstacleRequest ("coin", 8, 0));
						}
					}

				}
			}
		}

		while (pendingObstacles.Count>0) {
			ObstacleRequest req = (ObstacleRequest)pendingObstacles.Dequeue ();
			GameObject new_obstacle = this.factory.CreateObstacle (req.type);
			new_obstacle.transform.Translate (req.xOffset, req.yOffset, 0);
			// adding "new" obstacle to treadmill
			new_obstacle.transform.parent = this.treadmill.gameObject.transform;
		}

		this.elapsed++;
	}
	
}

class ObstacleRequest
{
	public string type;
	public float xOffset;
	public float yOffset;

	public ObstacleRequest (string type, float xOffset, float yOffset)
	{
		this.type = type;
		this.xOffset = xOffset;
		this.yOffset = yOffset;
	}
}