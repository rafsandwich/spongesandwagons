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
    private int remainingStatPoints = 20;

    public TextMeshProUGUI strValueTxt, dexValueTxt, faiValueTxt, endValueTxt, chrValueTxt, intValueTxt, lckValueTxt;
    public TextMeshProUGUI strBonusTxt, dexBonusTxt, faiBonusTxt, endBonusTxt, chrBonusTxt, intBonusTxt, lckBonusTxt;

    public Button strAdd, strDec, dexAdd, dexDec, faiAdd, faiDec, endAdd, endDec, chrAdd, chrDec, intAdd, intDec, lckAdd, lckDec;

    private int strValue = 5, dexValue = 5, faiValue = 5, endValue = 5, chrValue = 5, intValue = 5, lckValue = 5; // the actual stat points allocated to the player
    private int strBonus, dexBonus, faiBonus, endBonus, chrBonus, intBonus, lckBonus; // the bonus points (+ / -) from race selection

    public GameObject raceSelectPanel;
    public GameObject attributeSelectPanel;
    public GameObject confirmationPanel;

    void Update()
    {
        //if (PlayerData.selectedRace == "Human")
        //{
        //    attributes[4] = 6;
        //    attributes[6] = 6;
        //    attributes[2] = 4;
        //}

        InitialiseRaceBonus();
        UpdateUI();

        Debug.Log(lckBonus);
        Debug.Log(strBonus);
    }

    private void InitialiseRaceBonus()
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

    private void UpdateUI()
    { 
        strValueTxt.text = (strValue + strBonus).ToString();
        dexValueTxt.text = (dexValue + dexBonus).ToString();
        faiValueTxt.text = (faiValue + faiBonus).ToString();
        endValueTxt.text = (endValue + endBonus).ToString();
        chrValueTxt.text = (chrValue + chrBonus).ToString();
        intValueTxt.text = (intValue + intBonus).ToString();
        lckValueTxt.text = (lckValue + lckBonus).ToString();
    }

    public void onRaceSelectButton()
    {
        raceSelectPanel.SetActive(true);
        attributeSelectPanel.SetActive(false);
    }

}
