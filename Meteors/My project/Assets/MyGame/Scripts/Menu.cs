using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    public GameObject optionsPanel;
    public Dropdown MeteorsCountDropdown;
    public int countMeteors;
    public int MeteorsCounter;

    private int selectedMeteorCount;
    [SerializeField] private TMP_Text numberText;

    public void StartGame()
    {
        SceneManager.LoadScene("Meteors");
    }

    public void CancelOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void GameOptions()
    {
        int counter = PlayerPrefs.GetInt("MeteorsCounter");
        //Debug.Log("counter = " + counter);

        switch (counter)
        {
            case 1:
                numberText.text = "1 meteor(s) selected, click Save";
                MeteorsCounter = 1;
                MeteorsCountDropdown.value = 0;
                break;
            case 2:
                numberText.text = "2 meteor(s) selected, click Save";
                MeteorsCounter = 2;
                MeteorsCountDropdown.value = 1;
                break;
            case 3:
                numberText.text = "3 meteor(s) selected, click Save";
                MeteorsCounter = 3;
                MeteorsCountDropdown.value = 2;
                break;
            case 4:
                numberText.text = "4 meteor(s) selected, click Save";
                MeteorsCounter = 4;
                MeteorsCountDropdown.value = 3;
                break;

        }

        optionsPanel.SetActive(true);
        if (MeteorsCountDropdown != null)
        {
            // Add listener for when the value of the Dropdown changes
            MeteorsCountDropdown.onValueChanged.AddListener(delegate {
                DropdownValueChanged(MeteorsCountDropdown);
            });

            // Initialize the selected meteor count
            selectedMeteorCount = MeteorsCountDropdown.value;
            //UpdateMeteorCount(selectedMeteorCount);
        }
    }
    void DropdownValueChanged(Dropdown change)
    {
        selectedMeteorCount = change.value;
        //Debug.Log("Selected Meteor Count: " + selectedMeteorCount);

        switch (selectedMeteorCount)
        {
            case 0:
                numberText.text = "1 meteor(s) selected, click Save";
                MeteorsCounter = 1;
                break;
            case 1:
                numberText.text = "2 meteor(s) selected, click Save";
                MeteorsCounter = 2;
                break;
            case 2:
                numberText.text = "3 meteor(s) selected, click Save";
                MeteorsCounter = 3;
                break;
            case 3:
                numberText.text = "4 meteor(s) selected, click Save";
                MeteorsCounter = 4;
                break;

        }

        // Call method to handle the change in meteor count
        //UpdateMeteorCount(selectedMeteorCount);
    }

    public void OptionsInput()
    {
        //countMeteors = MeteorsCountDropdown.value;
        //MeteorsCounter = 0;

        //switch (countMeteors)
        //{
            //case 0: MeteorsCounter = 1; break;
            //case 1: MeteorsCounter = 2; break;
            //case 2: MeteorsCounter = 3; break;
            //case 3: MeteorsCounter = 4; break;
        //}

        //if (countMeteors.Equals("Level 1 - 1 meteor"))
        //{
        //    MeteorsCounter = 1;
        //}
        //else
        //{
        //    if (countMeteors.Equals("Level 2 - 2 meteors"))
        //    {
        //        MeteorsCounter = 2;
        //    }
        //    else
        //    {
        //        if (countMeteors.Equals("Level 3 - 3 meteors"))
        //        {
        //            MeteorsCounter = 3;
        //       }
        //        else
        //        {
        //            MeteorsCounter = 4;
        //        }
        //    }
        //}
        //Debug.Log("Line 71 - countMeteors = " + countMeteors);
        //Debug.Log("Line 72 - MeteorsCounter = " + MeteorsCounter);
        //PlayerPrefs.SetInt("MeteorsCount", MeteorsCounter);
        //PlayerPrefs.SetInt("dropDownOptions", MeteorsCountDropdown.value);
    }

    public void DropDownCode(int index)
    {
        /*
        switch (index) 
        {
            case 0: 
                numberText.text = "1 meteor(s) selected, click Save";
                MeteorsCounter = 1;
                break;
            case 1: 
                numberText.text = "2 meteor(s) selected, click Save";
                MeteorsCounter = 2;
                break;
            case 2: 
                numberText.text = "3 meteor(s) selected, click Save";
                MeteorsCounter = 3;
                break;
            case 3: 
                numberText.text = "4 meteor(s) selected, click Save";
                MeteorsCounter = 4;
                break;

        }
        */
    }

    public void OptionsSave()
    {
        //if (MeteorsCountDropdown != null)
        //{
            // Add listener for when the value of the Dropdown changes
            //MeteorsCountDropdown.onValueChanged.AddListener(delegate {
            //    DropdownValueChanged(MeteorsCountDropdown);
            //});

            // Initialize the selected meteor count
            //selectedMeteorCount = MeteorsCountDropdown.value;
            //UpdateMeteorCount(selectedMeteorCount);
        //}

        //selectedMeteorCount = MeteorsCountDropdown.value;
        //MeteorsCounter = 0;

        //switch (selectedMeteorCount)
        //{
        //    case 0: MeteorsCounter = 1; break;
        //    case 1: MeteorsCounter = 2; break;
        //    case 2: MeteorsCounter = 3; break;
        //    case 3: MeteorsCounter = 4; break;
        //}

        //Debug.Log("Line 91 - selectedMeteorCount = " + selectedMeteorCount);
        //Debug.Log("Line 160 MeteorsCounter = " + MeteorsCounter);
        //PlayerPrefs.SetInt("selectedMeteorCount", selectedMeteorCount);
        PlayerPrefs.SetInt("MeteorsCounter", MeteorsCounter);
        //PlayerPrefs.SetInt("dropDownOptions", MeteorsCountDropdown.value);
        optionsPanel.SetActive(false);
    }

    public void ExitMainGame() 
    { 
        Application.Quit();
    }
}
