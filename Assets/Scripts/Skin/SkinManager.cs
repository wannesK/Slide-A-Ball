using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinManager : MonoBehaviour
{    
    public DiamondsControl diamonds;

    public Button[] buyButtons;
    public Button[] equipButtons;

    public int soccerValue, wheelValue, eyeValue, metalValue;

    private SaveManager save;

    void Start()
    {
        save = SaveManager.instance;
        CheckSkinIsBuyed();
        CheckSkinEquip();
    }

    public void BuyButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Buy" && save.data.diamond >= soccerValue) // Which button pressed control
        {
            save.data.diamond -= soccerValue;
            save.data.buySoccerSkin = 1;  
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy1" && save.data.diamond >= wheelValue) 
        {
            save.data.diamond -= wheelValue;
            save.data.buyWheelSkin = 1;           
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy2" && save.data.diamond >= eyeValue)
        {
            save.data.diamond -= eyeValue;
            save.data.buyEyeSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy3" && save.data.diamond >= metalValue)
        {
            save.data.diamond -= metalValue;
            save.data.buyMetalSkin = 1;
        }
        else
        {
            Debug.Log("Not Enough Money");
        }

        diamonds.SetDiamondText();

        CheckSkinIsBuyed();

    }  
    public void CheckSkinIsBuyed() 
    {
        if (save.data.buySoccerSkin == 1)
        {
            buyButtons[0].gameObject.SetActive(false);
            equipButtons[1].gameObject.SetActive(true);
        }
        if (save.data.buyWheelSkin == 1)
        {
            buyButtons[1].gameObject.SetActive(false);
            equipButtons[2].gameObject.SetActive(true);
        }
        if (save.data.buyEyeSkin == 1)
        {
            buyButtons[2].gameObject.SetActive(false);
            equipButtons[3].gameObject.SetActive(true);
        }
        if (save.data.buyMetalSkin == 1)
        {
            buyButtons[3].gameObject.SetActive(false);
            equipButtons[4].gameObject.SetActive(true);
        }
        
    }

    public void EquipButton()
    {
        save.data.equipDefaultSkin = 0;
        save.data.equipSoccerSkin = 0;
        save.data.equipWheelSkin = 0;
        save.data.equipEyeSkin = 0;
        save.data.equipMetalSkin = 0;

        if (EventSystem.current.currentSelectedGameObject.name == "EquipDefault")
        {
            save.data.equipDefaultSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip")
        {
            save.data.equipSoccerSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip1")
        {
            save.data.equipWheelSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip2")
        {
            save.data.equipEyeSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip3")
        {
            save.data.equipMetalSkin = 1;
        }

        CheckSkinEquip();
    }
    public void CheckSkinEquip()
    {

        for (int i = 0; i < equipButtons.Length; i++)
        {
            equipButtons[i].interactable = true;
        }

        if (save.data.equipDefaultSkin == 1)
        {
            equipButtons[0].interactable = false;
        }
        else if (save.data.equipSoccerSkin == 1)
        {
            equipButtons[1].interactable = false;
        }
        else if (save.data.equipWheelSkin == 1)
        {
            equipButtons[2].interactable = false;
        }
        else if (save.data.equipEyeSkin == 1)
        {
            equipButtons[3].interactable = false;
        }
        else if (save.data.equipMetalSkin == 1)
        {
            equipButtons[4].interactable = false;
        }
    }

}
