using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QualityDropdown : MonoBehaviour {

    [SerializeField]
    public Dropdown dropdown;
    protected int optionCount = 0;
    private void Start()
    {
        PopulateList();
        dropdown.value = optionCount;
        QualitySettings.SetQualityLevel(optionCount, true);

    }
     public void Dropdown_IndexChanged(int index)
    {

        QualitySettings.SetQualityLevel(index, true);

    }
    void OnGUI()
    {
        
    }

    private void PopulateList()
    {
        List<string> names = new List<string>(QualitySettings.names);
        optionCount = names.Count;
        dropdown.AddOptions(names);
    }
}
