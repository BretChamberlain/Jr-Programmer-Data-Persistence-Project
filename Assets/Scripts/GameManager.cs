using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager thisInstance;
    public string playerName;
    public int menuScore = 0;
    public string menuName = "Name";
    public Text bestScore;
    public InputField inputText;
    private bool isTrue = false;
    private void Awake()
    {
        if (thisInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        thisInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        isTrue = true;
        LoadScore();
        bestScore.text = "Highscore: " + menuName + " - " + menuScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrue == true)
        {
            playerName = inputText.text;
        }
    }

    public void BeginGame()
    {
        isTrue = false;
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public int scoreValue;
        public string playerName;
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            menuName = data.playerName;
            menuScore = data.scoreValue;
        }
    }
}
