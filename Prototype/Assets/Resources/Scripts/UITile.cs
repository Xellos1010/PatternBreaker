using System;
using UnityEngine;

public class UITile : MonoBehaviour
{
    public bool isEnabled = false;
    public int iSymbolNumber = -1;

    public void PlayError()
    {

    }

    public void SetNewTile()
    {
        iSymbolNumber = UnityEngine.Random.Range(0, Statics.mainManager.symbols.Length - 1);
    }

    public void SetTile(int iSymbolNum)
    {
        iSymbolNumber = iSymbolNum;
        SetSprite(Statics.mainManager.symbols[iSymbolNumber]);
        ToggleObjectVisibility(true);
    }

    public void SetPosition(Vector2 position)
    {
        Debug.Log("Setting position of " + gameObject.name + " to " + position.ToString());
        RectTransform transformRect = (RectTransform)transform;
        transformRect.anchoredPosition = position;
    }

    public void SetSize(Vector2 size)
    {
        Debug.Log("Setting size of " + gameObject.name + " to " + size.ToString());
        RectTransform transformRect = (RectTransform)transform;
        //gameObject.GetComponent<RectTransform>().anchoredPosition = position; //.Set(position.x, position.y);
        //gameObject.GetComponent<RectTransform>().rect.Set(transformRect.rect.xMin, transformRect.rect.yMin, size.x, size.y);
        transformRect.sizeDelta = size;
        transformRect.localScale = new Vector3(1, 1, 1);
    }

    public void SetSprite(Sprite spriteToUse)
    {
        transform.GetComponent<UnityEngine.UI.Image>().sprite = spriteToUse;
    }

    public void ToggleObjectVisibility(bool OnOff)
    {
        transform.GetComponent<UnityEngine.UI.Button>().interactable = OnOff;

    }
}

