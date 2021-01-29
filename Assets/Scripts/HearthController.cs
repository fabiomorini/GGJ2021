using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HearthController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private Vector2 force;
	public float blood;
	[HideInInspector]
	public float maxBlood = 15f;
	private float timer = 0.0f;
	private bool gameOver = false;
	public GameObject gameOverUI;
	public GameObject timeCounterUI;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		SetBlood();
	}

	private void FixedUpdate()
	{
		if (!gameOver)
		{
			force = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed).normalized;
			rb.MovePosition(rb.position + force * speed * Time.fixedDeltaTime);
		}
	}

    private void Update()
    {
        if (!gameOver)
        {
			DrainBlood();
		}
    }

	private void DrainBlood()
    {
		if (blood > 0)
		{
			timer -= Time.deltaTime;
			blood = timer % 60;
		}
		else
        {
			GameOver();
        }
	}

	private void GameOver()
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
