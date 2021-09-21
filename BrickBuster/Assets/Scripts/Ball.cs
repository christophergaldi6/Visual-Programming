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

public class Ball : MonoBehaviour {
	public float ballStartVelocity = 300f;
	private Rigidbody rb;
	private bool ballInPlay;
	public float currentVelocity;
	public float speedUpInterval = 5f;
	private bool speedUpActivate;
	/*rigid component to the program*/
	void Awake (){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	/* allows a ball to be entered into play*/
	void Update () {
		if (Input.GetKeyDown ("up") && ballInPlay == false) {
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			ResetVelocity ();
		}
		if (ballInPlay) {
			currentVelocity = rb.velocity.sqrMagnitude;
			if (currentVelocity <= 1 && !speedUpActivate) {
				ResetVelocity ();
			}
		}
	}
	/*makes sure that the ball does not lose velocity*/
	public void ResetVelocity(){
		rb.AddForce(new Vector3(ballStartVelocity, ballStartVelocity, 0));
		speedUpActivate = true;
		Invoke("ResetSpeedUpDelay", speedUpInterval);
	}
	/* no delay on the speeding up of the ball*/
	public void ResetSpeedUpDelay(){
		speedUpActivate = false;
		currentVelocity = rb.velocity.sqrMagnitude;
	}
}