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
        
        inputField.onEndEdit.AddListener(OnInputEndEdit);
        LoadData();
        PopulateDropdownOptions();
    }

    private void LoadData()
    {
        int itemCount = PlayerPrefs.GetInt("ItemCount", 0);

        for (int i = 0; i < itemCount; i++)
        {
            string item = PlayerPrefs.GetString("Item_" + i);
            items.Add(item);
        }
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("ItemCount", items.Count);

        for (int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" + i, items[i]);
        }

        PlayerPrefs.Save();
    }

    private void PopulateDropdownOptions()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(items);
        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }

    private void OnInputEndEdit(string input)
    {
        if (!string.IsNullOrEmpty(input) && !items.Contains(input))
        {
            items.Add(input);
            SaveData();
            PopulateDropdownOptions();
        }
        inputField.text = "";
    }
}
