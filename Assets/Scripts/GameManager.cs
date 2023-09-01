using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, int> PassedLevels; //string je ime nivoa, a int je broj zvezda
    public static int Score = 0; //broj zvezda
    public float PlayerSpeed;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        PassedLevels = new Dictionary<string, int>();
    }

    public void AddPassedLevel(string s, int i)
    {
        if (PassedLevels.ContainsKey(s))
        {
            if (PassedLevels[s] < i) {
                PassedLevels[s] = i;
            }
        }
        else
        {
            PassedLevels.Add(s, i);
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        Score = 0;
        foreach (KeyValuePair<string, int> kvp in PassedLevels)
        {
            Score += kvp.Value;
        }
    }
}
