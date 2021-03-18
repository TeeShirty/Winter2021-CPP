using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    
    [Header("Text")]
    public Text livesText;
    public Text volumeText;

    [Header("Slider")]
    public Slider volumeSlider;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton == true)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame()); //add listener with specific parameters
        }

        if (quitButton == true)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame()); //add listener with specific parameters
        }
         
        if (returnToGameButton == true)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }

        if (returnToMenuButton == true)
        {  
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());
        }

        if (backButton == true)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }

        if (settingsButton == true)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu)
        {
          
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (pauseMenu == true)
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0f;
                    if (Time.timeScale == 0f)
                    {
                        //insert lock all inputs code here
                    }
                }
                if (pauseMenu == false)
                {
                    ReturnToGame();
                }

                //pauseMenu.SetActive(!pauseMenu.activeSelf);//set timescale to 0;
                //Time.timeScale = 0;
            }
        }

        if (livesText == true)
        {
            livesText.text = GameManager.instance.lives.ToString();
        }
        if (settingsMenu == true)
        {
            if (settingsMenu.activeSelf)
            {
                volumeText.text = volumeSlider.value.ToString();
            }
        }

        if(SceneManager.GetActiveScene().name == "Level") //make sure this happens only in level
        {
            for (int j = 0; j < hearts.Length; j++)
            {
                if (j < GameManager.instance.lives)
                {
                    hearts[j].enabled = true;
                }
                else
                {
                    hearts[j].enabled = false;
                }
                    
            }
        }

    }

    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    
}
