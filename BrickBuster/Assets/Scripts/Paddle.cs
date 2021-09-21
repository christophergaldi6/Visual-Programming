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
/*The code below is used to set a paddle speed, limit where the paddle can go, set up where the paddle will start and repeat that effect*/
public class Paddle : MonoBehaviour {
	
	public float paddleSpeed = .005f;
	public float limitLeft = -10f;
	public float limitRight = 10f;
	public float paddleYPos  = -1.5f;
	private Vector3 playerPos = new Vector3(0, 0, 0);
	/* The code below is used to update the players paddle as they attempt to move it from left to right. We also set a maximum that the paddle
	can go to, otherwise there would be no barrier to stop it. Finally, the code also makes the paddle position equal to the Vector 3*/
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal")*(paddleSpeed));
		playerPos = new Vector3(Mathf.Clamp(xPos, limitLeft, limitRight), paddleYPos, 0f);
		transform.position = playerPos;
	}
}