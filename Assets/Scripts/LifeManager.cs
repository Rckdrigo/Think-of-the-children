﻿using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public int maxlife = 100;
	public int life;
	[HideInInspector()]
	public bool death;

	public delegate void HealthListener();
	public event HealthListener NoHealth;

	void Start(){	
		life = maxlife;
		GameState.Instance.Restart += Restart;
	}

	void Restart(){
		life = maxlife;
	}

	public void RecoverHealth(int recoveredHealth){
		life += recoveredHealth;
		if(life > maxlife)
			life = maxlife;
	}

	public void IncreaseMaxHealth(int amountIncreased){
		maxlife += amountIncreased;
	}

	public void IncreaseMaxHealthAndHeal(int amountIncreased){
		maxlife += amountIncreased;
		life = maxlife;
	}

	public void RecievedDamage(int damagedHealth){
		life -= damagedHealth;
		if(life < 0)
			life = 0;

		if(life <= 0){
			death = true;
			NoHealth();
		}
	}

	public void DecreaseMaxHealth(int amountDecreased){
		maxlife -= amountDecreased;
		if(maxlife < 0){
			maxlife = 1;
		}
		if(life > maxlife)
			life = maxlife;
	}
}
