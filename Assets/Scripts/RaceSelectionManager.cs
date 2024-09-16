using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.RestService;
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
    }


    public void SelectRace(string race)
    {
        Debug.Log("Race button clicked: " + race);
        selectedRace = race;
        //raceDesc.text = GetRaceDescription(race);

        PlayerData.selectedRace = selectedRace;
        advanceButton.interactable = true;
    }

    private string GetRaceDescription(string race)
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
