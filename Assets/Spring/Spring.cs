using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Spring : MonoBehaviour
{
    [SerializeField] private SpringUpPanel _springUpPanel;
    [SerializeField] private SpringTrigger _springTrigger;
    [SerializeField] private BehaviorSpringsType _behaviorType;
    [SerializeField] private float _force = 800f;
    [SerializeField] private float _time = 3f;

    private const float Delay = 3f;
    private bool _isTrigger = false;

    private void Awake()
    {
        StartCoroutine(AutoSpringProcess());
    }

    private void Start()
    {
        TriggerHandler(false);
        _springTrigger.OnTrigger += TriggerHandler;
    }

    private IEnumerator AutoSpringProcess()
    {
        var currentForce = 0;
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            for (var f = 0f; f < _time; f += Time.deltaTime)
            {
                if (_behaviorType != BehaviorSpringsType.Auto)
                {
                    yield return new WaitWhile(() => _behaviorType != BehaviorSpringsType.Auto);
                }

                currentForce = Mathf.RoundToInt((f * _force) / _time);
                _springUpPanel.SetTension(currentForce);
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitWhile(() => _behaviorType != BehaviorSpringsType.Auto);
        }
    }

    private void TriggerHandler(bool isTrrigger)
    {
        _isTrigger = isTrrigger;
        if (_behaviorType != BehaviorSpringsType.Trigger)
        {
            return;
        }

        _springUpPanel.SetTension(isTrrigger ? 0 : _force);
    }

    private void OnMouseDown()
    {
        if (_behaviorType != BehaviorSpringsType.Press)
        {
            return;
        }

        _springUpPanel.SetTension(_force);
    }

    private void OnMouseUp()
    {
        if (_behaviorType != BehaviorSpringsType.Press)
        {
            return;
        }

        _springUpPanel.SetTension(0);
    }
}

public enum BehaviorSpringsType
{
    Auto,
    Press,
    Trigger,
    Off
}
