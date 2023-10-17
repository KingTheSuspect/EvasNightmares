using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public float maxHealth = 100;

    [Range(0,100)]
    public float health;

    public Slider slider;
    public Image sliderFill;

    private Color minColor = Color.green;
    private Color maxColor = Color.red;

    private void Start()
    {

        slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();

        sliderFill = GameObject.FindGameObjectWithTag("Fill").GetComponent<Image>();

    }

    private void Update()
    {
        OnSliderValueChanged(slider.value);
        slider.value = health;

        if(health <= 0)
        {

            this.transform.position = GetComponent<PlayerController>().checkPoint;

            health = 100;

        }
    }

    public void GetDamage(int damage)
    {

        health -= damage;

    }

    private void OnSliderValueChanged(float value)
    {
        float normalizedValue = Mathf.InverseLerp(slider.minValue, slider.maxValue, value);
        sliderFill.color = Color.Lerp(maxColor, minColor, normalizedValue);
    }


}
