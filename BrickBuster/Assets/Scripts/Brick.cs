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
/*allows us to create a brick*/
public class Brick : MonoBehaviour {
	public GameObject brickDestroyParticle;
	[HideInInspector]public GameManager gm;
	/*allows us to use the Awake function*/
	void Awake(){
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	/*calls the destroy brick code and destroys the brick game object*/
	public virtual void OnCollisionEnter(Collision other){
		Instantiate (brickDestroyParticle, transform.position, Quaternion.identity);
		gm.DestroyBrick ();
		Destroy (gameObject);
	}
}