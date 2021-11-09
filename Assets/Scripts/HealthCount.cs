using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class HealthCount : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        _text.text = Mathf.Floor(_slider.value).ToString();
    }
}