using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanelManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI raceConfirmText;
    public Image raceImage;
    public TextMeshProUGUI raceDescText;

    public RaceSelectionManager raceSelectionManager;

    public Sprite humanSprite, aldrSprite, veldSprite;

    public TextMeshProUGUI strFinalValue, dexFinalValue, faiFinalValue, endFinalValue, chrFinalValue, intFinalValue, lckFinalValue;

    public TMP_InputField nameInputField;
    public Button confirmButton;
    public TextMeshProUGUI validationMessage;

    private void Start()
    {
        confirmButton.interactable = false;

        // check name input field everytime it's edited
        nameInputField.onValueChanged.AddListener(delegate { ValidateNameInput(); });
    }

    public void InitialiseConfirmationPanel()
    {
        // set player race
        raceConfirmText.text = "Chosen Race: " + PlayerData.selectedRace;

        // set correct race image
        switch (PlayerData.selectedRace)
        {
            case "Human":
                raceImage.sprite = humanSprite;
                raceDescText.text = raceSelectionManager.GetRaceDescription(PlayerData.selectedRace);
                break;
            case "Aldr":
                raceImage.sprite = aldrSprite;
                raceDescText.text = raceSelectionManager.GetRaceDescription(PlayerData.selectedRace);
                break;
            case "Veld":
                raceImage.sprite = veldSprite;
                raceDescText.text = raceSelectionManager.GetRaceDescription(PlayerData.selectedRace);
                break;
        }

        // set selected attributes on screen
        strFinalValue.text = PlayerData.strStat.ToString();
        dexFinalValue.text = PlayerData.dexStat.ToString();
        faiFinalValue.text = PlayerData.faiStat.ToString();
        endFinalValue.text = PlayerData.endStat.ToString();
        chrFinalValue.text = PlayerData.chrStat.ToString();
        intFinalValue.text = PlayerData.intStat.ToString();
        lckFinalValue.text = PlayerData.lckStat.ToString();
    }

    // validate the name input field
    private void ValidateNameInput()
    {
        string enteredName = nameInputField.text;

        // regular expression to allow only letters, numbers, - and _
        string validNamePattern = @"^[a-zA-Z0-9_-]+$";

        // check if the name meets the length and pattern requirements
        if (enteredName.Length >= 3 && enteredName.Length <= 16 && Regex.IsMatch(enteredName, validNamePattern))
        {
            validationMessage.text = "Valid name!";  // clear any previous error message
            validationMessage.color = Color.green;
            confirmButton.interactable = true; // enable the confirm button
        }
        else
        {
            validationMessage.text = "This name is not valid!";
            validationMessage.color = Color.red;
            confirmButton.interactable = false; // disable the confirm button
        }
    }

    public void OnConfirm()
    {
        Debug.Log("Player race, stats and name confirmed, loading adventure ...");
        PlayerData.playerName = nameInputField.text;

        Debug.Log(PlayerData.playerName);
    }
}
