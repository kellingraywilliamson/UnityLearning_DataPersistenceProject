using System.IO;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;
    public string CurrentPlayer;
    public int CurrentScore;
    public int HighScore;
    public string PreviousPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    public string GetPreviousScoreText()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PreviousPlayer = CurrentPlayer;
            SaveGameData();
        }
        return $"Best Score : {PersistentDataManager.Instance?.HighScore} ({PersistentDataManager.Instance?.PreviousPlayer})";
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    private void SaveGameData()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.PlayerName = CurrentPlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PreviousPlayer = data.PlayerName;
            HighScore = data.HighScore;
        }
    }

}
