using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Image healthBarImage;
  public Player player;
  public void UpdateHealthBar() {
    if (player.GetPlayerHealth() > 200)
    {
      healthBarImage.color = new Color(0,1,0,1);
    }
    else
    {
      healthBarImage.color = new Color(1,0,0,1);
    }
    healthBarImage.fillAmount = Mathf.Clamp(player.GetPlayerHealth() / player.GetPlayerMaxHealth(), 0, 1000f);
  }
}