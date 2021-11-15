using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _health;

    public float Health => _health;

    public void Heal(int health)
    {
        _health = Mathf.Clamp(_health + health, _healthBar.minValue, _healthBar.maxValue);
    }

    public void TakeDamage(int health)
    {
        _health = Mathf.Clamp(_health - health, _healthBar.minValue, _healthBar.maxValue);
    }
}