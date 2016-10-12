using UnityEngine;
using System.Collections;

public static class Statics
{
    private static MainManager _mainManager;
    public static MainManager mainManager
    {
        get
        {
            if (_mainManager == null)
                _mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();
            return _mainManager;
        }
    }

    private static DiscSymbolManager _discSymbolManager;
    public static DiscSymbolManager discSymbolManager
    {
        get
        {
            if (_discSymbolManager == null)
                _discSymbolManager = GameObject.FindGameObjectWithTag("DiscManager").GetComponent<DiscSymbolManager>();
            return _discSymbolManager;
        }
    }

    private static PatternManager _patternManager;
    public static PatternManager patternManager
    {
        get
        {
            if (_patternManager == null)
                _patternManager = GameObject.FindGameObjectWithTag("DiscManager").GetComponent<PatternManager>();
            return _patternManager;
        }
    }

    private static RectTransform _discRect;
    public static RectTransform discRect
    {
        get
        {
            if (_discRect == null)
                _discRect = GameObject.FindGameObjectWithTag("DiscManager").GetComponent<RectTransform>();
            return _discRect;
        }
    }

    private static PatternMatcher _patternMatcher;
    public static PatternMatcher patternMatcher
    {
        get
        {
            if (_patternMatcher == null)
                _patternMatcher = GameObject.FindGameObjectWithTag("DiscManager").GetComponent<PatternMatcher>();
            return _patternMatcher;
        }
    }

    private static ScoreCounter _scoreCounter;
    public static ScoreCounter scoreCounter
    {
        get
        {
            if (_scoreCounter == null)
                _scoreCounter = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
            return _scoreCounter;
        }
    }
    private static UITileManager _UITileManager;
    public static UITileManager UITileManager
    {
        get
        {
            if (_UITileManager == null)
                _UITileManager = GameObject.FindGameObjectWithTag("UITileManager").GetComponent<UITileManager>();
            return _UITileManager;
        }
    }
}
