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
    public void IncreaseDiamond()
    {
        save.data.diamond += Random.Range(4, 10);

        SetDiamondText();
    }
    public void SetDiamondText()
    {
        diaomdText.text = save.data.diamond.ToString();
    }
}
