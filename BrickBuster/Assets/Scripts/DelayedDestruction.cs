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
/*sets a delay on the destruction of whatever we link it to*/
public class DelayedDestruction: MonoBehaviour {
	public float delay = 1f;

	void Start () {
		Destroy (gameObject, delay);
	}
}