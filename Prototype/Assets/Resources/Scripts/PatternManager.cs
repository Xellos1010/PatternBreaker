using UnityEngine;
using System.Collections.Generic;
using System;

public class PatternManager : MonoBehaviour 
{
    public enum RulesToAdd {IncreaseSymbolDisc, None};
    public List<RulesToAdd> rulesInPlay;
    public RulesToAdd RuleToGenerate = RulesToAdd.None;
    public int iPatternMatchToRuleChange = 3;
    public int iPatternsMatched;
    int ruleCounter;
    public DiscSymbol[] pattern;
    int resetMatchAfter = 9;

    int GenerateNewSymbolToUse(List<int> symbolsUsed)
    {
        int iReturn = -1;
        if (symbolsUsed.Count > 0)
            iReturn = symbolsUsed[0];
        else
            iReturn = UnityEngine.Random.Range(0,Statics.mainManager.symbols.Length-2);
        while (symbolsUsed.Contains(iReturn))
            iReturn = UnityEngine.Random.Range(0, Statics.mainManager.symbols.Length - 2);
        return iReturn;
    }

    void GeneratePatternTile(int iTileNumber)
    {
        Debug.Log("Generating Pattern Tile");
        //TOFO activate another pattern tile
        Debug.Log(" new tile generated ");
    }

    DiscSymbol ReturnChildPattern(int iTileNumber)
    {
        try
        {
            return Statics.discSymbolManager.discSymbols[iTileNumber];
        }
        catch
        {
            Debug.Log("iTileNumber = " + iTileNumber.ToString() + " is not a valid tileNumber to return");
            return null;
        }
    }

    int[] ReturnRange()
    {
        int[] returnValue = new int[2];

        Debug.Log("Generating range for getting DiscSymbols between.");

        return returnValue;
    }

    DiscSymbol[] ProcessSymbols(DiscSymbol[] startingArray,List<DiscSymbol> symbolsToNotUse)
    {
        List<DiscSymbol> returnValue = new List<DiscSymbol>();
        foreach (DiscSymbol symbol in startingArray)
        {
            if (!symbolsToNotUse.Contains(symbol))
                returnValue.Add(symbol);
        }
        return returnValue.ToArray();
    }

    public void SetPattern(int patternLengthTillReset)
    {
        pattern = new DiscSymbol[patternLengthTillReset];
        resetMatchAfter = patternLengthTillReset;
        // TODO Connect to main manager DiscSymbolManager
        DiscSymbolManager DiscSymbolManager = Statics.discSymbolManager;
        //symbol to use should be pulled from inumber of symbols available on disc
        List<int> symbolsToNotUse = new List<int>();
        //If you have this flexible then only use the middle symbols
        for (int i = 0; i < patternLengthTillReset; i++)
        {
            DiscSymbol child = ReturnChildPattern(i);
            pattern[i] = child;
            int symbolToUse = UnityEngine.Random.Range(0, Statics.mainManager.symbols.Length-1);
            while (symbolsToNotUse.IndexOf(symbolToUse) > -1)
            {
                symbolToUse = UnityEngine.Random.Range(0, Statics.mainManager.symbols.Length - 1);
            }
            pattern[i].iSymbolNumber = symbolToUse;
            //Set sprite of child Symbol *TODO Generate Pattern in future**
            pattern[i].ToggleNewSymbol(symbolToUse, true);
            symbolsToNotUse.Add(pattern[i].iSymbolNumber);
        }
        for (int i = patternLengthTillReset; i < transform.childCount; i++)
        {
            ReturnChildPattern(i).ToggleObjectVisibility(false);
        }
        Statics.discSymbolManager.RotateToNextSymbol();
        Statics.UITileManager.SetTiles();
    }

    int[] RemoveSymbolFromArray(int[] discSymbolArray,int symbolUsed)
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < discSymbolArray.Length; i++)
        {
            if (discSymbolArray[i] != symbolUsed)
                tempList.Add(discSymbolArray[i]);
        }
        int[] returnList = new int[tempList.Count];
        tempList.CopyTo(returnList);
        return returnList;
    }

    public void ResetPattern()
    {
        iPatternsMatched += 1;
        Statics.mainManager.ResetPattern();
    }

    void CheckGenerateNewPattern()
    {
        if (Statics.discSymbolManager.ReturnActiveSymbolSlots().Length == 0)
            ResetPattern();
    }

    void CheckGenerateNewRule()
    {
        int iPatternsMatchtoUse = iPatternsMatched;
        if (Statics.discSymbolManager.ReturnActiveSymbolSlots().Length == 0)
            iPatternsMatchtoUse = iPatternsMatched+1;
        int rulesToBeInPlay = (iPatternsMatchtoUse  - (iPatternMatchToRuleChange * rulesInPlay.Count)) - iPatternMatchToRuleChange;
        while (rulesToBeInPlay == 0)
        {
            AddNewRule();
            ruleCounter++;
            rulesToBeInPlay--;
        }
    }

    void TurnOffPatternMatched()
    {
        DiscSymbol patternTilematched = Statics.discSymbolManager.ReturnCurrentSymbol();
        Statics.discSymbolManager.TurnOffMatchedSymbol(patternTilematched);
    }

    public void SymbolMatched()
    {
        TurnOffPatternMatched();
        CheckGenerateNewRule();
        CheckGenerateNewPattern();
        Statics.discSymbolManager.RotateToNextSymbol();
    }

    void AddNewRule()
    {
        //Set a new rule based on range of rules that can be had
        Debug.Log("Generating a new rule");
        int ruletoAddint = UnityEngine.Random.Range(0, (int)RulesToAdd.None);
        bool ruleAdded = false;

        if (RuleToGenerate == RulesToAdd.None)
        {
            Debug.Log("Generating a new rule - " + (RulesToAdd)ruletoAddint);
            switch ((RulesToAdd)ruletoAddint)
            {
                case RulesToAdd.IncreaseSymbolDisc:
                    ruleAdded = Statics.mainManager.IncreaseSymbolUsedOnDisc();
                    break;
            }
            if (ruleAdded)
            {
                rulesInPlay.Add((RulesToAdd)ruletoAddint);//Track the rule that was added
            }
        }
        else
        {
            Debug.Log("Generating a new rule - " + RuleToGenerate.ToString());
            switch (RuleToGenerate)
            {                
                case RulesToAdd.IncreaseSymbolDisc:
                    ruleAdded = Statics.mainManager.IncreaseSymbolUsedOnDisc();
                    break;
            }
            if (ruleAdded)
            {
                rulesInPlay.Add((RulesToAdd)ruletoAddint);//Track the rule that was added
            }
        }
    }

}
