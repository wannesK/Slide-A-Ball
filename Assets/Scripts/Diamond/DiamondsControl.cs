using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiamondsControl : MonoBehaviour
{
    public TextMeshProUGUI diaomdText;
    public Text score, score1;

    //public Button adButton;

    public SaveManager save;

    public int levelTotalDiamonds;
    void Start()
    {
        SetDiamondText();
    }
    public int IncreaseDiamond(int value)
    {
        save.data.diamond += value;

        levelTotalDiamonds += value;

        SetDiamondText();

        return save.data.diamond;
    }
    public void SetDiamondText()
    {
        diaomdText.text = save.data.diamond.ToString();

        score.text = $"+{levelTotalDiamonds}";
        score1.text = $"{levelTotalDiamonds}";
    }

    public void AdWatched()
    {
        save.data.diamond += levelTotalDiamonds;

        diaomdText.text = save.data.diamond.ToString();

        //StartCoroutine(DisableButton());
    }

    //IEnumerator DisableButton()
    //{
    //    yield return new WaitForSeconds(1);
    //    adButton.gameObject.SetActive(false);
    //}
}
