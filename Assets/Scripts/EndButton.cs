using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    LevelManager LM;
    private void Start()
    {
        LM = LevelManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LM.EndGame(LevelManager.Timer);
    }
}
