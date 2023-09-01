using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] AudioManager _AM;
    GameManager _GM;
    TextMeshProUGUI _overallScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _AM = AudioManager.Instance;
        _GM = GameManager.Instance;
        if (SceneManager.GetActiveScene().name == "Menu") 
        {
            _overallScore = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
            _overallScore.text = GameManager.Score.ToString();
        }
    }

    #region Dugmad
    public void Play()
    {
        _AM.PlayButtonClickSound();
        SceneManager.LoadScene("LevelSelector");
    }

    public void Settings()
    {
        _AM.PlayButtonClickSound();
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        _AM.PlayButtonClickSound();
        Application.Quit();
    }

    public void Menu()
    {
        _AM.PlayButtonClickSound();
        SceneManager.LoadScene("Menu");
    }

    public void Level1()
    {
        _AM.PlayButtonClickSound();
        SceneManager.LoadScene("Level 1");
    }
    #endregion
}
