using System;
using UnityEngine;

public class SpringTrigger : MonoBehaviour
{
    public event Action<bool> OnTrigger;

    [SerializeField] private string _tag;

    private void OnTriggerEnter(Collider other)
    {
        SetTrrigger(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        SetTrrigger(other, false);
    }

    private void SetTrrigger(Collider other, bool isEnter)
    {
        if (other.tag != _tag)
        {
            return;
        }

        Debug.Log($"Trigger {isEnter}");
        OnTrigger?.Invoke(isEnter);
    }
}
