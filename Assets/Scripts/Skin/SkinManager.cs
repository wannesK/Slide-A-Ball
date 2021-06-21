using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinManager : MonoBehaviour
{
    
    public SaveManager save;

    public Button[] buyButtons;
    public Button[] equipButtons;

    void Start()
    {
        CheckSkinIsBuyed();
        CheckSkinEquip();
    }

    public void BuyButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Buy" && save.data.diamond >= 100) //Hangi button a bas�ld� kontrolu
        {
            save.data.diamond -= 100;
            save.data.buySoccerSkin = 1;  //save deki int lari 1 e e�itleyip a�a��da kontrol ediyo

            Debug.Log("Skin buyed");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy1" && save.data.diamond >= 100) //Hangi button a bas�ld� kontrolu
        {
            save.data.diamond -= 100;
            save.data.buyWheelSkin = 1;  //save deki int lari 1 e e�itleyip a�a��da kontrol ediyo
            
            Debug.Log("Skin buyed");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy2" && save.data.diamond >= 200)
        {
            save.data.diamond -= 200;
            save.data.buyEyeSkin = 1;

            Debug.Log("Skin buyed1");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy3" && save.data.diamond >= 300)
        {
            save.data.diamond -= 300;
            save.data.buyMetalSkin = 1;

            Debug.Log("Skin buyed2");
        }
        else
        {
            Debug.Log("Not Enough Money");
        }

        CheckSkinIsBuyed();

    }  
    public void CheckSkinIsBuyed() // kay�tl� int de�erlerini kontrol edip ona g�re butonlar� aktif ediyo
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
