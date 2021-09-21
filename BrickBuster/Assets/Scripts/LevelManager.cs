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
using UnityEngine.UI;
using UnityEngine.SceneManagement;
	/*The code below allows the game to see what level the player is at, all of the available levels to be loaded, loading the levels and loading the level text*/
public class LevelManager : MonoBehaviour {
	public int curLevel = 0;
	public GameObject[] levels;
	private GameObject curLevelGO;
	public Text levelUITxt;

	/*The code below loads the next level if the current level is done. This also calls the reset level and set level UI functions*/
	public void LoadNextLevel(){
		if (curLevelGO != null) {
			Destroy (curLevelGO);
		}
		if (curLevel < levels.Length) {
			curLevelGO = Instantiate (levels [curLevel], levels [curLevel].transform.position, levels [curLevel].transform.rotation) as GameObject;
			curLevel++;
		} else {
			ResetLevels ();
		}
		SetLevelUI ();
	}
	/*The code below is used to reset the level and load the next one*/
	void ResetLevels(){
		curLevel = 0;
		LoadNextLevel ();
	}
	/*The code below is used to update the level UI to show what level the player is on*/
	public void SetLevelUI(){
		levelUITxt.text = "Level" + (curLevel);
	
	}
}