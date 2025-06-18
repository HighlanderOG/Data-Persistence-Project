using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class DataStoring : MonoBehaviour
{
    public static DataStoring Instance;
    public string username;
    public int hi; //high score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserData();

    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int hi;
    }

    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.hi = hi;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            username = data.username;
            hi = data.hi;
        }
    }
}
