using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {
    public List<Word> wordList;
    public List<string> usedLetterList;
    public string wordToGuess;
    public string guess;
    public string displayWord;
    public int guessesRemaining = 5;
    public double time = 0;

    public InputField mainInputField;
    public Text wordGuessGO;
    public Text categoryGO;
    public Text guessRemainingGO;
    public Text usedLettersGO;
    public Text endText;
    public Text timer;
    public Text hintText;
    public GameObject playAgainBtn;

    private int randomNumber;

    //Add a bool to track when game is over
    private bool gameOver = false;

    // Use this for initialization
    void Start()
    {
        //Set the word to guess
        SetWordToGuess();
        //Update the word display
        UpdateWordDisplay();
        //Authomatically select the input for the user. 
        //This is so the user doesn't need to "click" on the input field every time they want to type a character.
        SelectInput();

        endText.enabled = false;
        playAgainBtn.SetActive(false);

        hintText.enabled = false;

    }

    //updates each frame
    void Update()
    {
        //if game is not over, run timer
       if(gameOver != true)
        {
            time += Time.deltaTime;
    
            timer.text = "30 Second Mode! Time Elapsed: " + System.Math.Round(time).ToString() + " seconds";
        }
        CheckGameOver();

    }

    //display the word hint to the user when they click the hint button
    public void SetWordHint() {

        hintText.text = wordList[randomNumber].wordHint;
        hintText.enabled = true;

    }

    void SetWordToGuess() {
        //Pick a random number between zero and the amount of words in "wordList"
        randomNumber = Random.Range(0, wordList.Count);
        //
        wordToGuess = wordList[randomNumber].word;
        //
        displayWord = wordToGuess;
        //Clear out the word to guess and make it only asterisks
        ReplaceAllLetters(displayWord, '*');
        //
        categoryGO.text = wordList[randomNumber].category;
    }

    public void LetterCheck(string letterGuessed) {
        guess = letterGuessed;
       
        guess = guess.ToLower();
        //Use regex to replace any invalid entry with an empty string
        guess = Regex.Replace(guess, @"[^a-z]", string.Empty);

        if (!usedLetterList.Contains(guess) && !gameOver)
        {
            usedLetterList.Add(guess);

            //Check to see if our "word to guess" contrains the players guess
            if (wordToGuess.Contains(guess))
            {
                UpdateLetters();
            }
            else
            {
                //The letter is not part of the word, so remove a "guess from the counter
                guessesRemaining--;
                //Update the "guesses remaining" UI
                guessRemainingGO.text = "Guesses Remaining : " + guessesRemaining.ToString();
                //Check for game over

            }

            CheckGameOver();
            //usedLettersGO.text += guess;

            //Update the letter display to show the used letters
            ShowUsedLetters();

        }

        SelectInput();

    }

    private void ShowUsedLetters() { //shows used letters when the game is runnings

        usedLettersGO.text += guess;

    }

    void SelectInput()
    {
        if (!gameOver)
        {
            //Reset input to nothing
            mainInputField.text = ""; //"" are the same as string.Empty;
            //Activate the main input field
            mainInputField.ActivateInputField();
            //Hide the user's cursor
            //Cursor.visible = false;
        }
        /*else {
            PlayAgain();
        }*/
    }

    private void DeselectInput() { //deactivates text box so user cannot type anything

        mainInputField.text = "";
        mainInputField.DeactivateInputField();

    }

    public void ExitGame() //makes the game quit in unity editor
    {
        {

        #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

        #else

            Application.Quit();

        #endif

        }
    }

    void UpdateLetters() {
        int charIndex = 0;

        for (int i = 0; i < wordToGuess.Length; i++) {
            //Convert to a string to compare
            if (wordToGuess[i].ToString() == guess) {
                charIndex = i;
                //Remove character
                displayWord = displayWord.Remove(charIndex, 1);
                displayWord = displayWord.Insert(charIndex, guess); 
            }
        }
        UpdateWordDisplay();
    }

    void UpdateWordDisplay()
    {

        wordGuessGO.text = displayWord;
        //Check to see if player has guess all letters
        CheckGameOver();

    }

    void ReplaceAllLetters(string input, char target) {
        StringBuilder sb = new StringBuilder(input.Length);
        //Iterate through the characetrs in the string builder we created above
        //Using the length of the original word
        for(int i = 0; i < wordToGuess.Length; i++)
        {
            sb.Append(target);
        }
        //Update the display word to be the string we built above
        displayWord = sb.ToString();
    }

    public void PlayAgain() //initilizes the restart of the game, clears letters, sets guesses remaining, etc. Basically clears everything out so user can play again
    {
       // usedLettersGO.text = "Press any key to play again";
        System.Console.ReadLine();
        usedLettersGO.text = "Letters used:";
        guessesRemaining = 5;
        guessRemainingGO.text = "Guesses remaining: " + guessesRemaining.ToString();
        usedLetterList.Clear();
        SetWordToGuess();
        //Update the word display
        UpdateWordDisplay();
        gameOver = false;
        endText.enabled = false;
        playAgainBtn.SetActive(false);
        hintText.text = "";
        hintText.enabled = false;
        //reset timer
        time = 0;

        //Automatically select the input for the user. This is so the user doesn't need to click on the input
        //field every time they want to type in a character.
        SelectInput();

    }

    private void CheckGameOver() //checks if games over
    {
        Debug.Log(guessesRemaining); //puts guesses into the log
        if (displayWord == wordToGuess)
        {

            endText.text = "You Win!";
            gameOver = true;
            /*endText.enabled = true;
            playAgainBtn.SetActive(true);
            gameOver = true;*/

        }
        else if (guessesRemaining <= 0) //if out of guesses
        {
            endText.text = "Game Over. Out of guesses!"; //game over message
            gameOver = true;
            /*endText.enabled = true;
            playAgainBtn.SetActive(true);
            gameOver = true;*/

        }

        else if (time >= 30) //time runs out and prompts game over message, sets game over as true
        {
            endText.text = "Game Over. Out of Time!";
            gameOver = true;
        }

        if (gameOver) { //if the game is over,  offers option to restart it and turns off text box

            ShowUsedLetters();
            endText.enabled = true;
            playAgainBtn.SetActive(true);
            DeselectInput();

        }


    }



}
