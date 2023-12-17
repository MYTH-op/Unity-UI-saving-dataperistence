using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveToFile : MonoBehaviour
{
    public InputField inputField;
    public Button saveButton;

    private string filePath;

    private void Start()
    {
        // Set the file path where you want to save the data
        filePath = Path.Combine(Application.persistentDataPath, "UserData.txt");

        // Attach the button click event
        saveButton.onClick.AddListener(SaveData);
    }

    private void SaveData()
    {
        string dataToSave = inputField.text;

        try
        {
            // Write the data to the file
            File.WriteAllText(filePath, dataToSave);
            Debug.Log("Data saved successfully to: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data: " + e.Message);
        }
    }
 
}
