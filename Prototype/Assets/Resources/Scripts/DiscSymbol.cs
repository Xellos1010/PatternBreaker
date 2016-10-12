using System;
using UnityEngine;
//TODO Setup like UITile
public class DiscSymbol : MonoBehaviour
{
    public int iSymbolNumber = 0;
    public bool isEnabled = false;
    public float rotationAngle;

    public void SetSpriteToSymbolNumber()
    {
        GetComponent<SpriteRenderer>().sprite = Statics.mainManager.symbols[iSymbolNumber];
    }

    public void SetSprite(Sprite spriteToUse)
    {
        GetComponent<SpriteRenderer>().sprite = spriteToUse;
    }

    public void ToggleObjectVisibility(bool OnOff)
    {
        GetComponent<SpriteRenderer>().enabled = OnOff;
        isEnabled = OnOff;
    }

    public void ToggleNewSymbol(int symbolNumber, bool bEnabled)
    {
        iSymbolNumber = symbolNumber;
        SetSpriteToSymbolNumber();
        ToggleObjectVisibility(bEnabled);
    }
}

