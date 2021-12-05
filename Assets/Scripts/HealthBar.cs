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
    private Coroutine coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
    }

    public void StartChangingValue(float health)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ChangeValue(health));
    }

    private IEnumerator ChangeValue(float health)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _changingSpeed);
            yield return waitForFixedUpdate;
        }
    }
}
