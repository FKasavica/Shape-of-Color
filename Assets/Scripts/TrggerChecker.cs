using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerChecker : MonoBehaviour
{
    private bool _triggered;

    public abstract void ApplyEffect(Collider2D collision, bool condition);
    public abstract void CheckExitCondition(Collider2D collision);
    public abstract bool CheckCondition(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_triggered)
        {
            _triggered = true;

            ApplyEffect(collision, CheckCondition(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_triggered)
        {
            CheckExitCondition(collision);
            _triggered = false;
        }
    }
}
