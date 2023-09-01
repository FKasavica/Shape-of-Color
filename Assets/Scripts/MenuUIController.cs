using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUIController : UIController
{
    GameManager _GM;
    TextMeshProUGUI _overallScore;

    private void Start()
    {
        _GM = GameManager.Instance;
        _overallScore = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        _overallScore.text = GameManager.Score.ToString();
    }
}
