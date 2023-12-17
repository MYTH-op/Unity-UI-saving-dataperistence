using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DynamicDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public InputField inputField;

    private List<string> items = new List<string>();

    private void Start()
    {
        // Attach the input field on end edit event to add new items
        inputField.onEndEdit.AddListener(OnInputEndEdit);

        // Load data from PlayerPrefs and populate the dropdown
        LoadData();
        PopulateDropdownOptions();
    }

    private void LoadData()
    {
        // Load items from PlayerPrefs
        int itemCount = PlayerPrefs.GetInt("ItemCount", 0);

        for (int i = 0; i < itemCount; i++)
        {
            string item = PlayerPrefs.GetString("Item_" + i);
            items.Add(item);
        }
    }

    private void SaveData()
    {
        // Save items to PlayerPrefs
        PlayerPrefs.SetInt("ItemCount", items.Count);

        for (int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" + i, items[i]);
        }

        PlayerPrefs.Save();
    }

    private void PopulateDropdownOptions()
    {
        // Clear existing options
        dropdown.ClearOptions();

        // Add items to the dropdown
        dropdown.AddOptions(items);

        // Set the default value if needed
        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }

    private void OnInputEndEdit(string input)
    {
        // Add the new item and update the dropdown
        if (!string.IsNullOrEmpty(input) && !items.Contains(input))
        {
            items.Add(input);
            SaveData();
            PopulateDropdownOptions();
        }

        // Clear the input field
        inputField.text = "";
    }
}
