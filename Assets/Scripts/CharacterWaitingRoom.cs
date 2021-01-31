using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;

public class CharacterWaitingRoom : MonoBehaviour
{
	private float speed = 15.0f;
	private Rigidbody2D rb;
	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;

	private float blood;
	private float maxBlood;
	public Slider slider;

	private CharacterManager characterManager;

	[HideInInspector] public UnityArmatureComponent anim;

	private void Start()
	{
		characterManager = GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>();
		maxBlood = 10.0f;
		anim = GetComponentInChildren<UnityArmatureComponent>();
		rb = GetComponent<Rigidbody2D>();
		SetBlood();
		slider.maxValue = maxBlood;
		slider.value = blood;
		anim.animation.Play(("Idle_Walk"), -1);
	}

	private void FixedUpdate()
	{
		if (horizontal != 0 && vertical != 0)
		{
			horizontal *= moveLimiter;
			vertical *= moveLimiter;
		}

		rb.velocity = new Vector2(horizontal * speed, vertical * speed);
	}

	private void Update()
	{
		//movement
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = 25.0f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 15.0f;
		}
	}

	public void BuyTirita()
    {
		characterManager.coins -= 10;
		SoundManager.PlaySound("InsertCoin");
	}
	public void BuyCafe()
	{
		characterManager.coins -= 25;
		SoundManager.PlaySound("InsertCoin");
	}
	public void BuyDesfibrilador()
	{
		characterManager.coins -= 50;
		SoundManager.PlaySound("InsertCoin");
	}

	public void SetBlood()
	{
		blood = maxBlood + 1;
	}
}
