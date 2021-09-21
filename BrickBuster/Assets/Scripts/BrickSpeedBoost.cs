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

public class BrickSpeedBoost : Brick {
	public float speedBoost = 15;

	public override void OnCollisionEnter (Collision other)
	{
		Instantiate (brickDestroyParticle, transform.position, Quaternion.identity);
		gm.DestroyBrick ();
		Vector3 newSpeed;
		newSpeed = other.gameObject.GetComponent<Rigidbody> ().velocity;
		newSpeed.x = +speedBoost;
		newSpeed.y = +speedBoost;
		other.gameObject.GetComponent<Rigidbody> ().AddForce(newSpeed);
		Destroy(gameObject);
	}
}