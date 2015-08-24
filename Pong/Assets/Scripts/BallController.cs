using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	//speed of the ball
	public float speed = 3.5F;

	//the initial direction of the ball
	private Vector2 spawnDir;

	//ball's components
	Rigidbody2D rig2D;
	// Use this for initialization
	void Start () {
		//setting balls Rigidbody 2D
		rig2D = this.gameObject.GetComponent<Rigidbody2D>();

		//generating random number based on possible initial directions
		int rand = Random.Range(1,4);

		//setting initial direction
		if(rand == 1){
			spawnDir = new Vector2(1,1);
		} else if(rand == 2){
			spawnDir = new Vector2(1,-1);
		} else if(rand == 3){
			spawnDir = new Vector2(-1,-1);
		} else if(rand == 4){
			spawnDir = new Vector2(-1,1);
		}

		//moving ball in initial direction and adding speed
		rig2D.velocity = (spawnDir*speed);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {

		//checks to make sure it hit a paddle
		if (col.gameObject.tag == "Paddle") {

			//calculate the y direction of the ball based on where it hit paddle
			float y = (transform.position.y - col.transform.position.y)/1;
			Debug.Log (y);

			//direction variable
			Vector2 d = Vector2.zero;

			//check for player paddle 
			if(col.gameObject.name == "Player"){
				d = new Vector2(-1, y).normalized;

			//checks for enemy paddle
			}else if (col.gameObject.name == "Enemy"){

				//sets new direction based on calculation
				d = new Vector2(1, y).normalized;
			}
			//change direction of ball
			rig2D.velocity = d*speed;

		}
	}
}
