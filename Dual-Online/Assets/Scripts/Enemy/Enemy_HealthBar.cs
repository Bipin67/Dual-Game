using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{
 //Public instances
 public Slider HealthSlider;
 public Gradient GradientColor;
 public Image Fill;
 
 /// <summary>
 /// Setting health slider max health.
 /// Filling the gradient color in the max health.
 /// </summary>
 /// <param name="health"></param>
 public void SetMaxHealth(int health)
 {
  HealthSlider.maxValue = health;
  HealthSlider.value = health;
  Fill.color= GradientColor.Evaluate(1f);
 }

 public void SetHealth(int health)
 {
  HealthSlider.value = health;
  Fill.color= GradientColor.Evaluate(HealthSlider.normalizedValue);
 }
}
