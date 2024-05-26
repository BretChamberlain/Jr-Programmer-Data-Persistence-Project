using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager thisInstance;
    public string playerName;
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


}
