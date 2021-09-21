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
/*used to show lives, score, game over, institute a level manager, create lives, allow a reset function to be called,
create and destroy a paddle*/
public class GameManager : MonoBehaviour {
	public Text livesText;
	public Text scoreText;
	public Text gameOverTxt;
	public LevelManager lm;
	public int lives = 3;
	public int bricks = 0;
	public int score = 0;
	public float resetDelay = 1f;
	public GameObject paddle;
	public GameObject deathParticles;
	private GameObject clonePaddle;
	// Use this for initialization
	/*sets up the game when called*/
	void Awake(){
		Setup ();
	
	}
	/*creates a score multiplier and illustrates that by changing the color of score*/
	public void MultiplierActivate(float multiplierDuration){
		score++;
		scoreText.fontStyle = FontStyle.Bold;
		scoreText.fontSize = 10;
        scoreText.color = Color.yellow;
		Invoke ("MultiplierDeactivate", multiplierDuration);
	}
	/*lets the game know what to do when the multiplier deactivates*/
	void MultiplierDeactivate(){
		scoreText.fontStyle = FontStyle.Normal;
		scoreText.fontSize = 10;
		scoreText.color = Color.black;
			
	}
	/*creates a paddle, projects the lives remaining, the score and loads a level*/
	void Setup(){
		SetupPaddle ();
		livesText.text = "Balls Remaining : " + lives;
		scoreText.text = "Score : " + score;
		lm.LoadNextLevel();
		bricks = 0;
		bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
	}
	/*is used when a life is lost, lifes remaining are also reduced.
	life count is less than 0, then game over.*/
	public void LoseLife(){
		lives--;
		livesText.text = "Balls Remaining : " + lives;
		Destroy (clonePaddle);
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		if (lives > -1) {
			Invoke ("SetupPaddle", resetDelay);
		}
		CheckGameOver ();
	}
	/*creates a paddle*/
	void SetupPaddle(){
		clonePaddle = Instantiate (paddle, paddle.transform.position, paddle.transform.rotation) as GameObject;
	}
	/*destroys bricks*/
	public void DestroyBrick(){
		bricks--;
		score++;
		scoreText.text = "Score : " + score;
		CheckGameOver ();
	}
	/*checks to see if there are any bricks left. no more bricks, then next level is loaded. */
	void CheckGameOver(){
		if (bricks < 1) {
			gameOverTxt.gameObject.SetActive(true);
			gameOverTxt.text = "Great job!";
			Time.timeScale = .25f;
			Destroy(GameObject.FindGameObjectWithTag("Ball"));
			Invoke ("LevelComplete", resetDelay);
		} else if (lives < 0) {
			gameOverTxt.gameObject.SetActive (true);
			gameOverTxt.text = "Try Again";
			livesText.text = "GAME OVER";
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
	}
	/*level is complete and if true, then next level is loaded*/
	void LevelComplete(){
		gameOverTxt.gameObject.SetActive (false);
		Time.timeScale = 1f;
		Destroy (clonePaddle);
		Setup ();
	}
	/*If the player life total is less than 0, then the game is reset*/
	void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Game");
	}
}