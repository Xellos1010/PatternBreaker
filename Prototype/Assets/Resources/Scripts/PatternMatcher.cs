using UnityEngine;
using System.Collections;

public class PatternMatcher : MonoBehaviour 
{
    public bool matchpattern = false;
    public float timeToMatch = 0.65f;
    public DiscSymbol currentSymbol;

    DiscSymbolManager _discSymbolManager;
    DiscSymbolManager discSymbolManager
    {
        get
        {
            if (_discSymbolManager == null)
                _discSymbolManager = transform.GetComponent<DiscSymbolManager>();
            return _discSymbolManager;
        }
    }

    public void AllowMatching()
    {
        matchpattern = true;
        Debug.Log(gameObject.name);
    }

    public void UnAllowMatching()
    {
        matchpattern = false;
    }

    public void CheckPatternMatch(UITile symbolToMatch)
    {
        //Pull Symbol from Disc Symbol Manager and Pattern to see if they match
        currentSymbol = discSymbolManager.ReturnCurrentSymbol();
        if (Statics.discSymbolManager.ReturnActiveSymbolSlots().Length > 0)
        {
            if (symbolToMatch.iSymbolNumber == currentSymbol.iSymbolNumber)
            {
                symbolToMatch.ToggleObjectVisibility(false);
                PatternMatched(currentSymbol);
            }
            else
            {
                Debug.Log("Pattern Doesn't Match symbolToMatch.iSymbolNumber=" + symbolToMatch.iSymbolNumber + " current Symbol number = " + currentSymbol.iSymbolNumber);
                //Play Error and reset wheel
                symbolToMatch.PlayError();
            }
        }
    }

    void PatternMatched(DiscSymbol symbolUsed)
    {
        Statics.scoreCounter.IncreaseScore();
        //Increase the patterns matched
        //Take away symbol from disc and reset pattern
        Statics.patternManager.SymbolMatched(); // Checks for new rule and then new pattern
    }
}
