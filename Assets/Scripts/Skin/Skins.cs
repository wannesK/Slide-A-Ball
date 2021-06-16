using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skins : MonoBehaviour
{
    public SaveManager save;

    public GameObject[] skins;

    private void Start()
    {
        CheckSkinEquip();
    }

    public void CheckSkinEquip()
    {

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].gameObject.SetActive(false);
        }


        if (save.data.equipDefaultSkin == 1)
        {
            skins[0].gameObject.SetActive(true);
        }
        if (save.data.equipWheelSkin == 1)
        {
            skins[1].gameObject.SetActive(true);
        }
        if (save.data.equipEyeSkin == 1)
        {
            skins[2].gameObject.SetActive(true);
        }
        if (save.data.equipMetalSkin == 1)
        {
            skins[3].gameObject.SetActive(true);
        }
    }


    public void SkinScreen()
    {
        SceneManager.LoadScene("Skin"); // + variable working
    }
}
