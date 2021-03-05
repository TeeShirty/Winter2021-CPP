using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int score = 0;
    int _score
    {
        get {return _score;}
        set
        {
            _score = value;
            Debug.Log("Current score is " + _score);
        }
    }

    public int maxLives = 3;
    int _lives = 3;
    public int lives
    { 
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                //respawn code goes here
                //Destroy player;
            }
            _lives = value;
            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (_lives < 0)
            {
                _lives = 0;
                SceneManager.LoadScene("GameOver");
                _lives = maxLives;
                //insert game end code here
            }
            Debug.Log("Current lives are " + _lives);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == true)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Level")
            {
                SceneManager.LoadScene("TitleScreen");
            }
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("Level");
            }
            else if (SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
