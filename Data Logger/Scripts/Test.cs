using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour 
{
    // Create a variable to link our existing DataLogger.cs in the scene
    private Datalogger dataLoggerReference;
    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        dataLoggerReference = GameObject.FindGameObjectWithTag("DataLogger").GetComponent<Datalogger>();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dataLoggerReference.WriteString("spacebar was pressed");
        }
	}

public void ButtonPress(string buttonMessage)
{
    dataLoggerReference.WriteString(buttonMessage + " button was pressed");
}

}
