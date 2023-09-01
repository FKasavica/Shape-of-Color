using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public static float Timer;

    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private GameObject Joystick;
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject Star3;
    [SerializeField] private GameObject YSText;

    TextMeshProUGUI TimerUI;
    TextMeshProUGUI EndGameTimerUI;

    private int _starCount;
    [SerializeField] private string _levelName;
    GameManager GM;
    AudioManager AM;
    private bool _isPassed;

    [Header("Uslovi za zvezde (in seconds)")]
    [SerializeField] private float _oneStarTreshold;
    [SerializeField] private float _twoStarTreshold;
    [SerializeField] private float _threeStarTreshold;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GM = GameManager.Instance;
        AM = AudioManager.Instance;
        _levelName = SceneManager.GetActiveScene().name;

        PauseMenu.SetActive(false);
        EndMenu.SetActive(false);
        YSText.SetActive(false);

        Joystick.SetActive(true);
        Time.timeScale = 1f;

        TimerUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        Timer = 0f;

        _isPassed = false;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        TimerUI.text = Mathf.FloorToInt(Timer / 60f).ToString() + ":" + Mathf.FloorToInt(Timer % 60f).ToString();
    }

    public void EndGame(float timer)
    {
        _isPassed = true;
        EndMenu.SetActive(true);

        Time.timeScale = 0f;
        Joystick.SetActive(false);

        EndGameTimerUI = GameObject.FindGameObjectWithTag("EndGameTimer").GetComponent<TextMeshProUGUI>();
        EndGameTimerUI.text = "LEVEL FINISHED!\nYour time:\n" + TimerUI.text;

        if (timer < _threeStarTreshold)
        {
            _starCount = 3;
        }
        else if (timer < _twoStarTreshold && timer > _threeStarTreshold)
        {
            _starCount = 2;
            Star3.SetActive(false);
        }
        else if (timer < _oneStarTreshold && timer > _twoStarTreshold)
        {
            _starCount = 1;
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
        else 
        {
            _starCount = 0; 
            _isPassed = false;
            Star1.SetActive(false);
            Star2.SetActive(false);
            Star3.SetActive(false);
            YSText.SetActive(true);
        }
    }

    #region Dugmad
    public void Pause()
    {
        AudioManager.Instance.PlayButtonClickSound();
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        AudioManager.Instance.PlayButtonClickSound();
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlayButtonClickSound();
        if (_isPassed)
        {
            GM.AddPassedLevel(_levelName, _starCount);
        }
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        AudioManager.Instance.PlayButtonClickSound();
        Application.Quit();
    }

    public void Restart()
    {
        AudioManager.Instance.PlayButtonClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        AudioManager.Instance.PlayButtonClickSound();
        if (_isPassed)
        {
            GM.AddPassedLevel(_levelName, _starCount);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void LevelSelector()
    {
        AudioManager.Instance.PlayButtonClickSound();
        if (_isPassed)
        {
            GM.AddPassedLevel(_levelName, _starCount);
        }
        SceneManager.LoadScene("LevelSelector");
    }
    #endregion 
}
