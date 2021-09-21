using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Need access to write to txt file
using System.IO;
//For accessing Database/Resources
using UnityEditor;

public class DataLogger : MonoBehaviour
{
    private string fileName = "testLog";
    private string path = "Assets/Logs/";
    private string filePath;

    // Use this for initialization
    void Start()
    {
        WriteString("Startup");
    }

    public void WriteString(string message)
    {
        filePath = path + fileName + ".txt";

        StreamWriter writer = new StreamWriter(filePath, true);

        writer.WriteLine(message);
        writer.WriteLine("TIMESTAMP: " + System.DateTime.Now);
        writer.WriteLine("////////////////////////////////");

        writer.Close();

        AssetDatabase.ImportAsset(filePath);
        Resources.Load(filePath);
    }

    void OnApplicationQuit() {
        WriteString("Shutdown");
    }
}
