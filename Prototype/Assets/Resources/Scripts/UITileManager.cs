using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UITileManager : MonoBehaviour {
    public void SetTiles()
    {
        List<int> discSymbols = new List<int>();
        DiscSymbol[] activeDiscSymbols = Statics.discSymbolManager.ReturnActiveSymbolSlots();
        int[] SymbolsToGenerate = new int[activeDiscSymbols.Length];
        for (int i = 0; i < activeDiscSymbols.Length; i++)
            SymbolsToGenerate[i] = activeDiscSymbols[i].iSymbolNumber;
        List<int> symbolsUsed = new List<int>();
        foreach (Transform tchild in transform)
        {
            if (symbolsUsed.Count != SymbolsToGenerate.Length)
            {           
                int symbol = UnityEngine.Random.Range(0, SymbolsToGenerate.Length);
                while (symbolsUsed.IndexOf(symbol) > -1)
                {
                    symbol = UnityEngine.Random.Range(0, SymbolsToGenerate.Length);
                }
                tchild.GetComponent<UITile>().SetTile(SymbolsToGenerate[symbol]);
                symbolsUsed.Add(symbol);
            }
            else
            {
                tchild.GetComponent<UITile>().SetTile(UnityEngine.Random.Range(0, Statics.mainManager.symbols.Length - 1));
            }
        }
    }
}
