using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainManager : MonoBehaviour 
{
    public string skin = "Prototype";
    public Sprite[] symbols;
    public int iDiscSymbolAmount = 3;
    public int iDiscSymbolMax = 5;

    // Use this for initialization
	void Start() 
    {
        symbols = Resources.LoadAll<Sprite>("Skin/" + skin + "/Symbols");//Load symbols from resources skins folder
        Statics.patternManager.SetPattern(iDiscSymbolAmount);
	}

    public void ResetGame()
    {
        Application.LoadLevel(0); // for testing purposes only
    }

    public void ResetPattern()
    {
        Statics.patternManager.SetPattern(iDiscSymbolAmount);
    }

    public bool IncreaseSymbolUsedOnDisc()
    {
        Debug.Log("Increasing symbols used on disc");
        if (iDiscSymbolAmount + 1 <= iDiscSymbolMax)
        {
            iDiscSymbolAmount++;
            return true;
        }
        Debug.Log("Failed to increasing symbols used on disc");
        return false;
    }
}
