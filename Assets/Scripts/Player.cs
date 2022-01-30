using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    public UnityEvent<float> ChangeHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(int health)
    {
        _health = Mathf.Clamp(_health + health, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_health);
    }

    public void TakeDamage(int health)
    {
        _health = Mathf.Clamp(_health - health, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_health);
    }
}