/*Name: Kiara Cardona and Chris Galdi
Student ID#: 2293780 and 229616
Chapman email: cardona @chapman.edu and galdi@chapman.edu
Course Number and Section: 236-02
Beach Send
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam: MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, gamemaster.vertVel, 4);
    }
}
