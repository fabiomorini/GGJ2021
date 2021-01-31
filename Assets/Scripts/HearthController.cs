using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DragonBones;

public class HearthController : MonoBehaviour
{
	public float speed = 15.0f;
	private Rigidbody2D rb;
	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;

	public float blood;
	public float maxBlood;
	private float timer = 0.0f;
	private bool gameOver = false;
	public GameObject gameOverUI;
	public GameObject timeCounterUI;
	public Slider slider;
	private State state;
	public bool blockSpeed;
	public bool activeCoffee = false;
	public bool activeDesfibrillator = false;
	public bool activeBandAid = false;
	private bool blockLife = false;
	private bool blockSpeedCoffee = false;

	[HideInInspector] public UnityArmatureComponent anim;

	private enum State
    {
		PAUSE,
		WALKING,
		RUNNING
    }

	private void Start()
	{
		anim = GetComponentInChildren<UnityArmatureComponent>();
		state = State.PAUSE;
		rb = GetComponent<Rigidbody2D>();
		slider.maxValue = maxBlood;
		slider.value = blood;
		anim.animation.Play(("Idle_Walk"), -1);
		SetBlood();
	}

	private void FixedUpdate()
	{
		if (!gameOver)
		{
			if (!blockSpeed)
			{
				if (horizontal != 0 && vertical != 0)
				{
					horizontal *= moveLimiter;
					vertical *= moveLimiter;
				}

				rb.velocity = new Vector2(horizontal * speed, vertical * speed);
			}
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
				if (!blockLife)
				{
					state = State.WALKING;
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				if (!blockSpeedCoffee)
				{
					speed = 25.0f;
				}

				if (!blockLife)
				{
					state = State.RUNNING;
				}
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				if (!blockSpeedCoffee)
				{
					speed = 15.0f;
				}

				if (!blockLife)
				{
					state = State.WALKING;
				}
			}
			if (activeCoffee && Input.GetKeyDown(KeyCode.E))
			{
				StartCoroutine(Coffee());
			}

			if (activeBandAid && Input.GetKeyDown(KeyCode.E))
            {
				StartCoroutine(BandAid());
			}

			DrainBlood();
		}
    }

	private IEnumerator Coffee()
    {
		blockSpeedCoffee = true;
		speed = 30.0f;
		yield return new WaitForSeconds(2.5f);
		speed = 15.0f;
		activeCoffee = false;
		blockSpeedCoffee = false;
	}

	private IEnumerator BandAid()
	{
		blockLife = true;
		state = State.PAUSE;
		yield return new WaitForSeconds(2.5f);
		state = State.WALKING;
		activeBandAid = false;
		blockLife = false;
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
			if (activeDesfibrillator)
            {
				blood = maxBlood + 1;
				timer = maxBlood;
				activeDesfibrillator = false;
			}
            else
            {
				GameOver();
			}
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void SetBlood()
    {
		blood = maxBlood + 1;
		timer = maxBlood;
	}
}
