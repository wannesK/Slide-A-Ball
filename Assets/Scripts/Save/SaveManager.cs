using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public GameData data;
    private BinaryFormatter binaryFormatter;
    private string filePath;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        binaryFormatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/game.data";

        //Debug.Log(filePath);
    }

    public void SaveData()
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            data = (GameData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }
        else
        {
            Debug.LogError("Save File Not Found " + filePath);
        }
    }
    private void OnEnable()
    {
        DatabaseControl();
    }

    private void DatabaseControl()
    {
        if (!File.Exists(filePath))
        {
#if UNITY_ANDROID
            string file = Path.Combine(Application.streamingAssetsPath, "game.data");
            WWW data = new WWW(file);
            while (!data.isDone)
            {

            }
            File.WriteAllBytes(filePath, data.bytes);
            LoadData();
#endif
        }
        else
        {
            LoadData();
        }
    }
    private void OnDisable()
    {
        SaveData();
    }

}

[System.Serializable]
public class GameData
{
    public int diamond;
    public float highScore;
    public int currentLevel = 1;

    public int buySoccerSkin, buyWheelSkin, buyEyeSkin, buyMetalSkin;
    public int equipDefaultSkin = 1, equipSoccerSkin, equipWheelSkin, equipEyeSkin, equipMetalSkin;
}

