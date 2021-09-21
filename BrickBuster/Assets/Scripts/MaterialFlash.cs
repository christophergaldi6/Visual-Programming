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

public class MaterialFlash : MonoBehaviour {
	public float resetDelay = 1f;
	private Renderer rend;
	private Color originalColor;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		originalColor = rend.material.color;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball") {
			rend.material.color = Color.red;
			Invoke ("ResetMaterial", resetDelay);
		}
	
	}

	void ResetMaterial(){
		rend.material.color = originalColor;
	
	}
}
