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
        filePath = Path.Combine(Application.persistentDataPath, "UserData.txt");
        saveButton.onClick.AddListener(SaveData);
    }

    private void SaveData()
    {
        string dataToSave = inputField.text;

        try
        {
            File.WriteAllText(filePath, dataToSave);
            Debug.Log("Data saved successfully to: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data: " + e.Message);
        }
    }
 
}
