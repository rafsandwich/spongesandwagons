using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceSelectionManager : MonoBehaviour
{

    public TextMeshProUGUI raceDesc;
    private string selectedRace;

    public void SelectRace(string race)
    {
        selectedRace = race;
        raceDesc.text = GetRaceDescription(race);
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
        PlayerData.selectedRace = selectedRace;
        SceneManager.LoadScene("AttributeDistribution");
    }
}
