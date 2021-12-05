using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public UnityEvent<float> ChangeHealthEvent;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxHealth);
        ChangeHealthEvent?.Invoke(_health);
    }

    public void TakeDamage(int health)
    {
        _health = Mathf.Clamp(_health - health, 0, _maxHealth);
        ChangeHealthEvent?.Invoke(_health);
    }
}