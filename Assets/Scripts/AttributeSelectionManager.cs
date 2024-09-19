using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSelectionManager : MonoBehaviour
{
    //public int[] attributes = new int[7] { 5, 5, 5, 5, 5, 5, 5 }; //0 str, 1 dex, 2 fai, 3 end, 4 chr, 5 int, 6 lck


    public TextMeshProUGUI remainingPointsText;
    private int remainingPoints = 20;

    public TextMeshProUGUI strValueTxt, dexValueTxt, faiValueTxt, endValueTxt, chrValueTxt, intValueTxt, lckValueTxt;
    public TextMeshProUGUI strBonusTxt, dexBonusTxt, faiBonusTxt, endBonusTxt, chrBonusTxt, intBonusTxt, lckBonusTxt;

    public Button strAdd, strDec, dexAdd, dexDec, faiAdd, faiDec, endAdd, endDec, chrAdd, chrDec, intAdd, intDec, lckAdd, lckDec;

    private int strValue = 5, dexValue = 5, faiValue = 5, endValue = 5, chrValue = 5, intValue = 5, lckValue = 5; // the actual stat points allocated to the player
    private int strBonus, dexBonus, faiBonus, endBonus, chrBonus, intBonus, lckBonus; // the bonus points (+ / -) from race selection

    public GameObject raceSelectPanel;
    public GameObject attributeSelectPanel;
    public GameObject confirmationPanel;


    void Start()
    {
        //if (PlayerData.selectedRace == "Human")
        //{
        //    attributes[4] = 6;
        //    attributes[6] = 6;
        //    attributes[2] = 4;
        //}

        InitialiseRaceBonus();
        UpdateAttributeSelectUI();

    }

    public void InitialiseRaceBonus()
    { 
        switch (PlayerData.selectedRace)
        {
            case "Human":
                strBonus = 0;
                dexBonus = 0;
                faiBonus = -1; // - fai
                endBonus = 0;
                chrBonus = 1; // + chr
                intBonus = 0;
                lckBonus = 1; // + lck
                break;
            case "Aldr":
                strBonus = 1; // + str
                dexBonus = -1; // - dex
                faiBonus = 0;
                endBonus = 0;
                chrBonus = 0;
                intBonus = 1; // + int
                lckBonus = 0;
                break;
            case "Veld":
                strBonus = 0;
                dexBonus = 1; // + dex
                faiBonus = 1; // + fai
                endBonus = 0;
                chrBonus = -1; // - chr
                intBonus = 0;
                lckBonus = 0;
                break;
        }
    }
    public void UpdateStatValue()
    {
        // set the stat value (number) on screen initially
        strValueTxt.text = (strValue + strBonus).ToString();
        dexValueTxt.text = (dexValue + dexBonus).ToString();
        faiValueTxt.text = (faiValue + faiBonus).ToString();
        endValueTxt.text = (endValue + endBonus).ToString();
        chrValueTxt.text = (chrValue + chrBonus).ToString();
        intValueTxt.text = (intValue + intBonus).ToString();
        lckValueTxt.text = (lckValue + lckBonus).ToString();
    }
    public void UpdateAttributeSelectUI()
    {
        UpdateStatValue();

        // define colours for positive and negative bonus text
        // to use hex, convert to rgb e.g. (45, 200, 110) -> new Color (45f/255f, 200f/255f, 110/255f, 1f)
        Color positiveColour = new Color(0.18f, 0.8f, 0.44f, 1f);
        Color negativeColour = new Color(0.8f, 0.18f, 0.18f, 1f);

        // display bonus text and set colour of text based on the value of the bonus
        SetBonusTextAndColour(strBonusTxt, strBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(dexBonusTxt, dexBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(faiBonusTxt, faiBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(endBonusTxt, endBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(chrBonusTxt, chrBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(intBonusTxt, intBonus, positiveColour, negativeColour);
        SetBonusTextAndColour(lckBonusTxt, lckBonus, positiveColour, negativeColour);

        remainingPointsText.text = "Total Stat Points remaining: " + remainingPoints.ToString();
    }

    private void SetBonusTextAndColour(TextMeshProUGUI bonusText, int bonusValue, Color positiveColour, Color negativeColour)
    {
        if (bonusValue > 0)
        {
            bonusText.text = "(+" + bonusValue.ToString() + " from " + PlayerData.selectedRace + ")";
            bonusText.color = positiveColour;
        }
        else if (bonusValue < 0)
        {
            bonusText.text = "(" + bonusValue.ToString() + " from " + PlayerData.selectedRace + ")";
            bonusText.color = negativeColour;
        }
        else
        {
            bonusText.text = "";
        }
    }

    // increase stats based on button press
    public void OnIncreaseStat(string stat)
    {
        if (remainingPoints > 0)
        {
            switch (stat)
            {
                case "STR":
                    if (strValue < 15)
                    {
                        strValue++;
                        remainingPoints--;
                    }
                    break;
                case "DEX":
                    if (dexValue < 15)
                    {
                        dexValue++;
                        remainingPoints--;
                    }
                    break;
                case "FAI":
                    if (faiValue < 15)
                    {
                        faiValue++;
                        remainingPoints--;
                    }
                    break;
                case "END":
                    if (endValue < 15)
                    {
                        endValue++;
                        remainingPoints--;
                    }
                    break;
                case "CHR":
                    if (chrValue < 15)
                    {
                        chrValue++;
                        remainingPoints--;
                    }
                    break;
                case "INT":
                    if (intValue < 15)
                    {
                        intValue++;
                        remainingPoints--;
                    }
                    break;
                case "LCK":
                    if (lckValue < 15)
                    {
                        lckValue++;
                        remainingPoints--;
                    }
                    break;
            }

            UpdateAttributeSelectUI();

            // STR
            strAdd.interactable = (strValue < 15 && remainingPoints > 0); // max base limit is 15 and remaining points must be greater than 0
            strDec.interactable = (strValue > 5); // min base limit is 5
        }
    }

    // decrease stats based on button press
    public void OnDecreaseStat(string stat)
    {
        switch (stat)
        {
            case "STR":
                if (strValue > 5) 
                {
                    strValue--;
                    remainingPoints++;
                }
                break;
            case "DEX":
                if (dexValue > 5)
                {
                    dexValue--;
                    remainingPoints++;
                }
                break;
            case "FAI":
                if (faiValue > 5)
                {
                    faiValue--;
                    remainingPoints++;
                }
                break;
            case "END":
                if (endValue > 5)
                {
                    endValue--;
                    remainingPoints++;
                }
                break;
            case "CHR":
                if (chrValue > 5)
                {
                    chrValue--;
                    remainingPoints++;
                }
                break;
            case "INT":
                if (intValue > 5)
                {
                    intValue--;
                    remainingPoints++;
                }
                break;
            case "LCK":
                if (lckValue > 5)
                {
                    lckValue--;
                    remainingPoints++;
                }
                break;
        }

        UpdateAttributeSelectUI();

        // STR
        strAdd.interactable = (strValue < 15 && remainingPoints > 0); // max base limit is 15 and remaining points must be greater than 0
        strDec.interactable = (strValue > 5); // min base limit is 5
    }

    public void UpdateStatButtonInteractatability()
    { 
        // to do
    }

    // reset stats to default
    public void OnResetToDefault()
    { 
        remainingPoints = 20;

        strValue = 5;
        dexValue = 5;
        faiValue = 5;
        endValue = 5;
        chrValue = 5;
        intValue = 5;
        lckValue = 5;

        //strDec.interactable = false;
        //dexDec.interactable = false;
        //faiDec.interactable = false;
        //endDec.interactable = false;
        //chrDec.interactable = false;
        //intDec.interactable = false;
        //lckDec.interactable = false;

        InitialiseRaceBonus();

        UpdateStatValue();

        // STR
        strAdd.interactable = (strValue < 15 && remainingPoints > 0); // max base limit is 15 and remaining points must be greater than 0
        strDec.interactable = (strValue > 5); // min base limit is 5

        remainingPointsText.text = "Total Stat Points remaining: " + remainingPoints.ToString(); // repeated code, but necessary atm
    }

    public void onRaceSelectButton()
    {
        raceSelectPanel.SetActive(true);
        attributeSelectPanel.SetActive(false);

    }

}
