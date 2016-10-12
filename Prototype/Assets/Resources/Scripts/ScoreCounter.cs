using UnityEngine;
using System.Collections;

// The GameObject requires a UI.Text class component
[RequireComponent(typeof(UnityEngine.UI.Text))]
public class ScoreCounter : MonoBehaviour
{
    int iScore = 0;
    UnityEngine.UI.Text _text;
    UnityEngine.UI.Text text
    {
        get
        {
            if (_text == null)
                _text = gameObject.GetComponent<UnityEngine.UI.Text>();
            return _text;
        }
    }

    public Color colorToFadeTo;
    public float fadeLength = 0.6f;

    void Start()
    {
        fps = new FPSTracker();
    }
    
    public void ResetScore()
    {
        SetScore(0);
    }

    void SetScore(int iNumber)
    {
        iScore = 0;
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        ++iScore;
        UpdateScoreText();
    }
    FPSTracker fps;

    /*IEnumerator FadeUIColor()
    {
        Color toColor = new Color(242, 242, 242, 242);
        //Fade to white if already color otherwise fade to color
        if (text.color != colorToFadeTo)
            toColor = colorToFadeTo;
        //while ()
        //yield return new WaitForSeconds(1 / fps.fps);
    }*/

    void UpdateScoreText()
    {
        text.text = "Matched " + iScore.ToString();
    }

    void Update()
    {
        fps.Update();
    }

}
