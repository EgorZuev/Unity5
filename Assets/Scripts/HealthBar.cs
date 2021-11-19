using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _changingSpeed;

    private Slider _slider;

    public float MinValue => _slider.minValue;
    public float MaxValue => _slider.maxValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void StartChangingValue()
    {
        StopCoroutine(ChangeValue());
        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (_slider.value != _player.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, _changingSpeed);
            yield return waitForFixedUpdate;
        }
    }
}
