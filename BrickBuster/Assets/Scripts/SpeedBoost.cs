/* 
Chris Galdi
2299616
galdi@chapman.edu
CPSC 236-02
Brick Breaker Game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*The code below allows us to create a boost function if one is not in use, boosts the paddle, displays a notification, and institutes a multiplier*/
public class SpeedBoost: MonoBehaviour {
	bool boost = false;
	public float paddleBoost = 1f;
	private Renderer rend;
	public GameObject boostNotification;
	private GameManager gm;
	public float multiplierDuration = 5f;


	/*The code below is used to set the color of the text to cyan and allows us to call the game manager*/
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.material.color = Color.cyan;
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	/*The code below is used to boost the ball when boost is not activated, using the spacebar, and changing the color to green*/
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !boost) {
			boost = true;
			Invoke ("ResetBoost", 1f);
			rend.material.color = Color.green;
		}
	}
	/*The code below is used to boost the ball, when the ball comes into contact with the boosted paddle. It must be activated when the ball touches the paddle or nothing will happen*/
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball") {
			if (boost) {
				col.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (paddleBoost, paddleBoost, 0));
				Instantiate (boostNotification, this.gameObject.transform.position, Quaternion.identity);
				gm.MultiplierActivate (multiplierDuration);
			}
		}
	}
	/*THe code below resets the boost and resets the color of the text*/
	void ResetBoost(){
		boost = false;
		rend.material.color = Color.cyan;
	}
}