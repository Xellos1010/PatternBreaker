using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscSymbolManager : MonoBehaviour 
{
    public DiscSymbol[] discSymbols;
    public DiscSymbol discSymbolSelected; // the current disc symbol to match 

    public void InitializeDiscSymbols(int iRangeMax)
    {
        TurnOffAllSymbols();
        // TODO Check discSymbols has all objects and generate if not. then setup position in circle
        List<int> iSymbolsToNotUse = new List<int>(); // Holds symbols already generated so you don't generate the same symbol
        for (int i = 0; i < discSymbols.Length; i++)
        {
            int index = ((int)discSymbols.Length/2 + ((i % 2 == 0) ? i / 2 : (int)discSymbols.Length - (i + 1) / 2)) % (int)discSymbols.Length;
            Debug.Log("index being set for InitializeDiscSymbols is " + index.ToString());
            //Activate all symbols until reach iNumberSymbolsDisc
            if (i < iRangeMax)
            {
                Debug.Log(index + " should be set to Active");
                //Generate new Disc Symbol
                int iSymbolToUse = UnityEngine.Random.Range(0, iRangeMax - 1);
                while (iSymbolsToNotUse.Contains(iSymbolToUse))
                    if (iSymbolToUse < iRangeMax / 2)
                        iSymbolToUse = UnityEngine.Random.Range(iSymbolToUse, iRangeMax - 1);
                    else
                        iSymbolToUse = UnityEngine.Random.Range(0, iSymbolToUse);
                discSymbols[index].ToggleNewSymbol(iSymbolToUse, true);
                iSymbolsToNotUse.Add(iSymbolToUse);
            }
            else
            {
                discSymbols[index].ToggleNewSymbol(iRangeMax - 1, false);
            }
        }
    }

    //Returns the current symbol dependent on the angle of disc
    public DiscSymbol ReturnCurrentSymbol()
    {
        return discSymbolSelected;
    }

    public DiscSymbol[] ReturnActiveSymbolSlots()
    {
        List<DiscSymbol> symbolsToNotUse = new List<DiscSymbol>();
        foreach (DiscSymbol disc in discSymbols)
            if (disc.isEnabled)
                symbolsToNotUse.Add(disc);
        return symbolsToNotUse.ToArray();
    }   

    public void RotateToNextSymbol()
    {
        DiscSymbol[] discSymbols = ReturnActiveSymbolSlots();
        DiscSymbol discSymbol = discSymbols[UnityEngine.Random.Range(0, discSymbols.Length)];
        GetComponent<DiscRotationManager>().RotateToAngle(discSymbol.rotationAngle, 1.5f);
        discSymbolSelected = discSymbol;
    }

    public void TurnOffMatchedSymbol(DiscSymbol symbolUsed)
    {
        for (int i = 0; i < discSymbols.Length; i++)
        {
            if (discSymbols[i] == symbolUsed)
            {
                discSymbols[i].ToggleObjectVisibility(false);
            }
        }
    }

    public void TurnOnSymbols(DiscSymbol[] symbolsToUse)
    {
        for (int i = 0; i < symbolsToUse.Length; i++)
        {
            symbolsToUse[i].ToggleObjectVisibility(true);
        }
    }

    public void TurnOffAllSymbols()
    {
        for (int i = 0; i < discSymbols.Length; i++)
        {
            discSymbols[i].ToggleObjectVisibility(true);
        }
    }

    void ReactivateSymbols()
    {
        foreach (DiscSymbol pattern in Statics.patternManager.pattern)
            pattern.ToggleObjectVisibility(true);
    }

    public void ResetDisc(bool newDiscSymbols)
    {
        if (newDiscSymbols)
            TurnOffAllSymbols();
        else
            ReactivateSymbols();
        GetComponent<DiscRotationManager>().RotateToAngle(360,1.5f);
    }

    //Resets SymbolManager to original Settings
    public void ResetGame()
    {
        InitializeDiscSymbols(Statics.mainManager.iDiscSymbolAmount);
    }
}
