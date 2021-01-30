﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HearthController : MonoBehaviour
{
	private float speed = 15.0f;
	private Rigidbody2D rb;
	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;

	private float blood;
	private float maxBlood;
	private float timer = 0.0f;
	private bool gameOver = false;
	public GameObject gameOverUI;
	public GameObject timeCounterUI;
	public Slider slider;
	private State state;

	private enum State
    {
		PAUSE,
		WALKING,
		RUNNING
    }

	private void Start()
	{
		state = State.PAUSE;
		maxBlood = 10.0f;
		rb = GetComponent<Rigidbody2D>();
		slider.maxValue = maxBlood;
		slider.value = blood;
		SetBlood();
	}

	private void FixedUpdate()
	{
		if (!gameOver)
		{

			if (horizontal != 0 && vertical != 0)
			{
				horizontal *= moveLimiter;
				vertical *= moveLimiter;
			}

			rb.velocity = new Vector2(horizontal * speed, vertical * speed);
		}
	}

    private void Update()
    {
		if (!gameOver)
		{
			//movement
			horizontal = Input.GetAxisRaw("Horizontal"); 
			vertical = Input.GetAxisRaw("Vertical"); 

			if (!(Input.GetKeyDown(KeyCode.LeftShift)) && 
			     (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) 
			   || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
			{
				state = State.WALKING;
			}

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				speed = 25.0f;
				state = State.RUNNING;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = 15.0f;
				state = State.WALKING;
			}
			DrainBlood();
		}
    }

	private void DrainBlood()
    {
		if (blood > 0)
		{
			if(state == State.PAUSE)
            {
				timer -= Time.deltaTime * 0;
			}
			else if(state == State.WALKING)
            {
				timer -= Time.deltaTime;
			}
			else if(state == State.RUNNING)
            {
				timer -= Time.deltaTime * 2.5f;
			}
			blood = timer % 60;
			slider.value = blood;
		}
		else
        {
			GameOver();
        }
	}

	public void GameOver()
    {
		gameOver = true;
		gameOverUI.SetActive(true);
		timeCounterUI.SetActive(false);
	}

	public void ReloadGame()
    {

    }

	public void SetBlood()
    {
		blood = maxBlood + 1;
		timer = maxBlood;
	}
}
