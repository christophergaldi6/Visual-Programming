using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Need Access to write text file
using System.IO;
//access to Unity edit(Database)
using UnityEditor;
//This calls to start the file, print out the time, date, start, and stop times, and then shutsdown.
public class Datalogger : MonoBehaviour
{
    private string fileName = "testLog"; 
    private string path = "Assets/Logs/";
    private string filePath;

    // Use this for initialization
    void Start() 
    {
        WriteString("Startup");

    }

    // Update is called once per frame
    public void WriteString(string message)
    {
        //Creates the path, names it, and creates a text file
        filePath = path + fileName + ".txt";

        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(message); 
        writer.WriteLine(System.DateTime.Now); //
        writer.WriteLine("///////////////////////"); //Seperates the time and data output

        writer.Close();

        AssetDatabase.ImportAsset(filePath);
        Resources.Load(filePath);
    }

   void OnApplicationQuit(){ //Says shutdown when it is exited. 
        WriteString("Shutdown");
    }
}