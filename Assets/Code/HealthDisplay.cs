using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthDisplay : MonoBehaviour
{
    Player player;
    TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
    }

    private void UpdatePlayerHealth()
    {
        if (player.GetPlayerHealth() <= 0)
        {
            healthText.text = "0";
        }
        else
        {
            healthText.text = player.GetPlayerHealth().ToString();
        }
    }
}
