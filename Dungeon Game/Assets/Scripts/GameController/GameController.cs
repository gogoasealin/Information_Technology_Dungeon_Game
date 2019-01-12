using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController gameController;

    private GameObject player;
    private PlayerController playerControllerScript;
    public GameObject gameOverWindow;
    public GameObject pauseWindow;
    public GameObject backToMenuButton;
    public GameObject hintButton;

    private GameManager gameManagerScript;

    public int levelReached;
    public int currentLevelReached;
    public int nextAddFromDeath;
    public int nextAddFromLvls;
    public bool death;
    private AdsManager adsManager;
    public bool pause;
    public bool resume;
    [SerializeField] AudioSource audioSourceDeath;

   

    private string[] levelsHint = new string[] {
        "https://www.youtube.com/watch?v=__ZUTb5_Uss&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=1&ab_channel=DonutProductions",
        "https://www.youtube.com/watch?v=p1K8DAFrMLA&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=2&ab_channel=DonutProductions",
        "https://www.youtube.com/watch?v=Fl1JPp-e81E&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=3",
        "https://www.youtube.com/watch?v=TSgYyzLlT8I&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=4",
        "https://www.youtube.com/watch?v=-hMuAZi-XRI&index=5&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=_3TlApjKx2g&index=6&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=eqHpPZtx_3s&index=7&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=EpVRoPr5Seg&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=8",
        "https://www.youtube.com/watch?v=9D16Xp6HJGQ&index=9&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=vDuR8udRH50&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=10",
        "https://www.youtube.com/watch?v=8K5N2HWqYqs&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl&index=11",
        "https://www.youtube.com/watch?v=wZ7zWDvLbW8&index=12&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=bDab89scJ5Y&index=13&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=d7xySraRYC4&index=14&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl",
        "https://www.youtube.com/watch?v=Q04sG7K1N2Y&index=15&list=PLPC8ITuBW8uaicSTjhq5AlDUH4Ux1NWUl"
    };

    private void Awake()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManagerScript.Load();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<PlayerController>();


        adsManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AdsManager>();
        adsManager.InitializeAdd();

        audioSourceDeath = GetComponent<AudioSource>();
        PrepareGame();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            SwitchPause();
        }
        if (pause)
        {
            Pause();
        }
        else if (!pause)
        {
            if (resume)
            {
                ResumeButton();
            }
        }
        if (death)
        {
            player.transform.localScale -= new Vector3(0.003f, 0.003f, 0);
            if (player.transform.localScale.x <= 0.001f)
            {
                death = false;
                AfterGameOver();
            }
        }
    }


    public void AfterGameOver()
    {
        Time.timeScale = 0;

        nextAddFromDeath += 1;

        if (nextAddFromDeath >= 10 || nextAddFromLvls >= 5)
        {
            adsManager.ShowAd();
        }
        else
        {
            ShowDeathMenus();
            gameManagerScript.Save();
        }

    }

    public void AddShowSuccesfully()
    {
        ShowDeathMenus();
        nextAddFromDeath = 0;
        nextAddFromLvls = 0;
        gameManagerScript.Save();
    }

    public void AddFailed()
    {
        ShowDeathMenus();
    }

    public void ShowDeathMenus()
    {
        EnableMenuText();
        gameOverWindow.SetActive(true);
    }

    public void GameOver()
    {
        if (player.activeInHierarchy)
        {
            transform.position = player.transform.position;
            if (playerControllerScript != null)
            {
                playerControllerScript.enabled = false;
            }
        }
        death = true;
        player.GetComponent<AudioSource>().Stop();
        audioSourceDeath.Play();     

    }

    public void EnableMenuText()
    {
        if (backToMenuButton != null)
        {
            backToMenuButton.SetActive(true);
            hintButton.SetActive(true);
        }

    }

    public void DisableMenuText()
    {
        backToMenuButton.SetActive(false);
        hintButton.SetActive(false);
    }

    public void RestartButton()
    {
        gameOverWindow.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("" + scene.name); // current scene 

    }

    public void Pause()
    {
        Time.timeScale = 0;
        EnableMenuText();
        pauseWindow.SetActive(true);

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        DisableMenuText();
        pauseWindow.SetActive(false);
        resume = false;
    }

    public void PrepareGame()
    {
        Time.timeScale = 1;
        pause = false;
        gameOverWindow.SetActive(false);
        pauseWindow.SetActive(false);
        backToMenuButton.SetActive(false);
        hintButton.SetActive(false);
    }

    public void SwitchPause()
    {
        if (pause)
        {
            pause = false;
            resume = true;
        }
        else if (!pause)
        {
            pause = true;
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoToHint()
    {
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        int index = 15;
        if (scene.name.Length == 6)
        {
            index = int.Parse(nextLevel.Substring(nextLevel.Length - 1));
        }
        else if (scene.name.Length == 7)
        {
            index = int.Parse(nextLevel.Substring(nextLevel.Length - 2));
        }

        if (index <= levelsHint.Length)
        {
            Application.OpenURL(levelsHint[index - 1]);
        }
    }
}
