using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class Shake : MonoBehaviour
{
    public ShakeData MyShakeData;
    public static Shake Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShakeCamera()
    {
        CameraShakerHandler.Shake(MyShakeData);
    }
}
