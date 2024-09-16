using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceSelectionManager : MonoBehaviour
{

    public TextMeshProUGUI raceDesc;
    private string selectedRace;

    public Button advanceButton;
    public GameObject humanPanel;
    public GameObject aldrPanel;
    public GameObject veldPanel;

    void Start()
    {
        advanceButton.interactable = false;
        ResetRaceSelection();
    }

    public void SelectRace(string buttonName)
    {
        ResetRaceSelection();

        switch (buttonName)
        {
            case "Human-Button":
                selectedRace = "Human";
                humanPanel.SetActive(true);
                break;
            case "Aldr-Button":
                selectedRace = "Aldr";
                aldrPanel.SetActive(true);
                break;
            case "Veld-Button":
                selectedRace = "Veld";
                veldPanel.SetActive(true);
                break;
        
        }

        Debug.Log("Player selected race: " + selectedRace);
        PlayerData.selectedRace = selectedRace;
        advanceButton.interactable = true;
    }


    public string GetRaceDescription(string race)
    {
        switch (race)
        {
            case "Human": return "Humans, typically well known for their versatility and excellent communication.";
            case "Aldr": return "The Aldr are a highly respected race possessing ancient wisdom.";
            case "Veld": return "Veld skirmishers have access to the tech of tomorrow and prefer to work in solitude.";
            default: return "";
        }
    }

    public void OnAdvanceButton()
    {
        SceneManager.LoadScene("AttributeDistribution");
    }

    private void ResetRaceSelection()
    { 
        humanPanel.SetActive(false);
        aldrPanel.SetActive(false);
        veldPanel.SetActive(false);
    }
}
