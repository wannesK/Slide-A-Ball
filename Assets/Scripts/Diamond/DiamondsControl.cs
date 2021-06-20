using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondsControl : MonoBehaviour
{
    public TextMeshProUGUI diaomdText;

    public SaveManager save;
    void Start()
    {
        SetDiamondText();
    }
    public int IncreaseDiamond(int value)
    {
        save.data.diamond += value;

        SetDiamondText();

        return save.data.diamond;
    }
    public void SetDiamondText()
    {
        diaomdText.text = save.data.diamond.ToString();
    }
}
