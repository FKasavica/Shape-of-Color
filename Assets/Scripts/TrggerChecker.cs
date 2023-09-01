using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerChecker : MonoBehaviour
{
    public bool isOut;

    public abstract void CheckTriggerCondition(Collider2D collision);
    public abstract void CheckExitCondition(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckTriggerCondition(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckExitCondition(collision);
    }
}
