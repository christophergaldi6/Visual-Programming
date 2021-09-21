using UnityEngine;

public class test : MonoBehaviour {
    //Create a variable to link our existing DataLogger.cs in the scene 
    private DataLogger dataLoggerReference;

    void Start()
    {
        //have unity find your gameobject with this taf and assign this component as the "dataLoggerReference" variable 
        dataLoggerReference = GameObject.FindGameObjectWithTag("DataLogger").GetComponent<DataLogger>();
    }
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dataLoggerReference.WriteString("spacebar was pressed");
        }
	}
    public void ButtonPress(string buttonMessage){
        dataLoggerReference.WriteString(buttonMessage+ " button was pressed");
    }

}
