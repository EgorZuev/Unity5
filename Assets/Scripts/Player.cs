using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _health;

    public float Health => _health;

    public void AddHealth(int health)
    {
        if(_health + health <= _healthBar.maxValue)
        {
            _health += health;
        }
        else
        {
            _health = _healthBar.maxValue;
        }
    }

    public void TakeHealth(int health)
    {
        if (_health - health >= _healthBar.minValue)
        {
            _health -= health;
        }
        else
        {
            _health = _healthBar.minValue;
        }
    }
}