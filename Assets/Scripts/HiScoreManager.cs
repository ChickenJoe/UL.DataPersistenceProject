using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class HiScoreManager : MonoBehaviour
{
    public static HiScoreManager Instance;
    public static string playerName;
    public string hiscoreName;
    public int hiscoreScore;
    public Text hiscoreText;
    public TMP_Text inputNameField;
    public GameObject menuItems;


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
        data.savedScore = hiscoreScore;

        hiscoreText.text = "Hiscore - " + playerName + ": " + hiscoreScore.ToString();

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

            hiscoreName = data.savedName;
            hiscoreScore = data.savedScore;

            hiscoreText.text = "Hiscore - " + hiscoreName + ": " + hiscoreScore.ToString();
        }
    }

    public void StoreName()
    {
        playerName = inputNameField.text;
    }

    public void StartGame()
    {
        menuItems.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        menuItems.SetActive(true);
    }
}