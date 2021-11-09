using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _secondsBeforeHealth;
    [SerializeField] private float _health;

    public void ChangeHealth(int health)
    {
        if(_health + health <= _healthBar.maxValue && _health + health >= _healthBar.minValue)
        {
            _health += health;
            StartCoroutine(IAddHealth(health));
        }
    }

    private IEnumerator IAddHealth(int health)
    {
        float currentHealth = _healthBar.value;
        float targetHealth = _health;

        float secondsBeforeRuningHealth = 0;

        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (_healthBar.value != targetHealth)
        {
            secondsBeforeRuningHealth += Time.deltaTime;

            _healthBar.value = Mathf.MoveTowards(currentHealth, targetHealth, secondsBeforeRuningHealth / (_secondsBeforeHealth / Mathf.Abs(targetHealth - currentHealth)));

            yield return waitForFixedUpdate;
        }
    }
}