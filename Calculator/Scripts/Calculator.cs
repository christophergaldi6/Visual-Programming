/*
    Christopher Galdi
    2299616
    galdi@chapman.edu
    CPSC 236-02
    Assignment Calculator
This assignment is a build of a calculator that can compute addition, multiplication, subtraction, division, and displays the answer. 

*/
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour //Establishes variables
{
    public string operation; 
    public string num1;
    public string num2;
    public string answer;
    public double tempsave;
    public double dec = 1;

    public Text textDisplay;

    public void Reset()
    {
        textDisplay.text = 0.ToString(); // 0 out display to user
        textDisplay.fontStyle = FontStyle.Normal; //Font style and size
        textDisplay.fontSize = 14;
        operation = null;
        num1 = null;//Sets variables 
        num2 = null;
        dec = 1;
        answer = 0.ToString();
    }
    void Start()
    {

        Reset();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCalculatorDisplay() //Updates Calculator Display
    {
        textDisplay.text = " " + answer;

        //textDisplay.text = num1 + " "+ operation + " " + num2;

    }

    public void AddNumber(int thisNum) // This determines 
    {
        textDisplay.color = Color.black;
        if (dec == 1){
            answer = (float.Parse(answer) * 10).ToString();
            answer = (float.Parse(answer) + thisNum).ToString();

        }
        else{
            answer = (float.Parse(answer) + (float)(thisNum * dec)).ToString();
            dec /= 10;
        }
       

        /*
        if (num1 == null)
        {
            num1 = thisNum.ToString();

        }
        else
        {
            num2 = thisNum.ToString();

        }
        */

       UpdateCalculatorDisplay();
    }

    public void setOperation(string thisOp) //Gives functionality to the symbols and enable them to be used in the calculator
    {
        operation = thisOp;
        tempsave = double.Parse(answer);
        answer = 0.ToString();
        dec = 1;
        UpdateCalculatorDisplay();
        textDisplay.text = operation;
    }

    public void DisplayAnswer() //Answer display 
    {

        textDisplay.fontStyle = FontStyle.Bold;

        textDisplay.fontSize = 24;

        textDisplay.text = num1 + " " + operation + " " + num2 + "=" + answer;


    }

    public void Calculate() //how we calculate the values
    {

        if (num1 == null && operation == null && num2 == null)
        {
            textDisplay.text = "Error";
            textDisplay.fontStyle = FontStyle.Normal;
            textDisplay.color = Color.red;
            textDisplay.fontSize = 14;

        }

        else if (operation == "/")
        {
            //answer = float.Parse(num1) / float.Parse(num2);
            answer = (tempsave / float.Parse(answer)).ToString("0.00");
        }
        else if (operation == "*")
        {
            //answer = float.Parse(num1) * float.Parse(num2);
            answer = (tempsave * float.Parse(answer)).ToString("0.00");
        }
        else if (operation == "-")
        {
            //answer = float.Parse(num1) - float.Parse(num2);
            answer = (tempsave - float.Parse(answer)).ToString("0.00");
        }
        else if (operation == "+")
        {
            //answer = float.Parse(num1) + float.Parse(num2);
            answer = (tempsave + float.Parse(answer)).ToString("0.00");
        }
        //DisplayAnswer();
        operation = "";
        dec = 1.0;

        UpdateCalculatorDisplay();
        tempsave = 0;
        answer = 0.ToString();
    }

    public void setDecimal(){ //Establishes the ability to utilize decimal points in the calculator
        dec = 0.1;
    }

    public void ClearButton() //Text display for the exit button
    {

        textDisplay.text = "0";
        textDisplay.fontStyle = FontStyle.Normal;
        textDisplay.fontSize = 14;
    }

    public void closeApplication() //Closes application on click of the exit button
    {
        Debug.Log("Application Closed");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
