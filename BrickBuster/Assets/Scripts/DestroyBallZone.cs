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
/*calls the game manager*/
public class DestroyBallZone : MonoBehaviour {
	private GameManager gm;
	void Awake(){
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	void OnTriggerEnter(Collider col){
		gm.LoseLife ();
		Destroy (col.gameObject);
	}
}