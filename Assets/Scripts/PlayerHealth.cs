using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth;
	public int health = 0;
	public List<Sprite> healthBarStates = new List<Sprite>();
	public Image healthBarImage;

	public void Init()
	{
		maxHealth = healthBarStates.Count -1;
		health = maxHealth;
		healthBarImage.sprite = healthBarStates[health];
	}

	public void UpdateHealthBar_Damage()
	{
		health = Mathf.Clamp(health - 1, 0, maxHealth);
		healthBarImage.sprite = healthBarStates[health];
	}

	public void UpdateHealthBar_Cure()
	{
		healthBarImage.sprite = healthBarStates[health];
		health = Mathf.Clamp(health + 1, 0, maxHealth);
	}
}
