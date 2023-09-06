using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _playerSpeedText;

    private void Start()
    {
        _playerSpeedText.text = "CURRENT SPEED: " + GameManager.Instance.PlayerSpeed.ToString("0.00");
        _slider.onValueChanged.AddListener((v) =>
        {
            GameManager.Instance.PlayerSpeed = v;
            _playerSpeedText.text = "CURRENT SPEED: " + v.ToString("0.00");
        });
    }
}
