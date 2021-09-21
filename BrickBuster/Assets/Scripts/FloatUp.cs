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

public class FloatUp : MonoBehaviour {
	public float speed = 10;

	void Update () {
		gameObject.transform.Translate (0, speed, 0);
	}
		
	void Start () {
		
	}
	
	// Update is called once per frame
}
