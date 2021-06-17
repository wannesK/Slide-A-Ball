using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinManager : MonoBehaviour
{
    
    public SaveManager save;

    public Button[] buyButtons;
    public Button[] equipButtons;
    public GameObject[] skins;

    void Start()
    {
        CheckSkinIsBuyed();
        CheckSkinEquip();
    }

    public void BuyButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Buy" && save.data.diamond >= 100) //Hangi button a basýldý kontrolu
        {
            save.data.diamond -= 100;
            save.data.buyWheelSkin = 1;  //save deki int lari 1 e eþitleyip aþaðýda kontrol ediyo
            
            Debug.Log("Skin buyed");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy1" && save.data.diamond >= 200)
        {
            save.data.diamond -= 200;
            save.data.buyEyeSkin = 1;

            Debug.Log("Skin buyed1");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Buy2" && save.data.diamond >= 300)
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
    public void CheckSkinIsBuyed() // kayýtlý int deðerlerini kontrol edip ona göre butonlarý aktif ediyo
    {
        if (save.data.buyWheelSkin == 1)
        {
            buyButtons[0].gameObject.SetActive(false);
            equipButtons[1].gameObject.SetActive(true);
        }
        if (save.data.buyEyeSkin == 1)
        {
            buyButtons[1].gameObject.SetActive(false);
            equipButtons[2].gameObject.SetActive(true);
        }
        if (save.data.buyMetalSkin == 1)
        {
            buyButtons[2].gameObject.SetActive(false);
            equipButtons[3].gameObject.SetActive(true);
        }
        
    }

    public void EquipButton()
    {
        save.data.equipDefaultSkin = 0;
        save.data.equipWheelSkin = 0;
        save.data.equipEyeSkin = 0;
        save.data.equipMetalSkin = 0;

        if (EventSystem.current.currentSelectedGameObject.name == "EquipDefault")
        {
            save.data.equipDefaultSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip")
        {
            save.data.equipWheelSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip1")
        {
            save.data.equipEyeSkin = 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Equip2")
        {
            save.data.equipMetalSkin = 1;
        }

        CheckSkinEquip();
    }
    public void CheckSkinEquip()
    {

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < equipButtons.Length; i++)
        {
            equipButtons[i].interactable = true;
        }

        if (save.data.equipDefaultSkin == 1)
        {
            skins[0].gameObject.SetActive(true);
            equipButtons[0].interactable = false;
        }

        if (save.data.equipWheelSkin == 1)
        {
            skins[1].gameObject.SetActive(true);
            equipButtons[1].interactable = false;
        }
        if (save.data.equipEyeSkin == 1)
        {
            skins[2].gameObject.SetActive(true);
            equipButtons[2].interactable = false;
        }
        if (save.data.equipMetalSkin == 1)
        {
            skins[3].gameObject.SetActive(true);
            equipButtons[3].interactable = false;
        }
    }

}
