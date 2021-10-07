using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HiScoreManager : MonoBehaviour
{
    public static HiScoreManager Instance;
    public int hiscore;
    public string playerName;
    public Text hiscoreText;

    private void Awake()
    {
        // Ensure only one instance is present, destroy self if instance already found
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string savedName;
        public int savedScore;
    }
        public void SaveScore()
    {
        SaveData data = new SaveData();
        data.savedName = playerName;
        data.savedScore = hiscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.savedName;
            hiscore = data.savedScore;

            //hiscoreText.text = "Hiscore - " + 
        }
    }
}