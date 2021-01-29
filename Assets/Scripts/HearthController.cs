using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private Vector2 force;
	public float blood;
	[HideInInspector]
	public float maxBlood = 15f;
	private float timer = 0.0f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		SetBlood();
	}

	private void FixedUpdate()
	{
		force = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed).normalized;
		rb.MovePosition(rb.position + force * speed * Time.fixedDeltaTime);
	}

    private void Update()
    {
		DrainBlood();
    }

	private void DrainBlood()
    {
		if (blood > 0)
		{
			timer -= Time.deltaTime;
			blood = timer % 60;
			Debug.Log((int)blood);
		}
	}

	public void SetBlood()
    {
		blood = maxBlood + 1;
		timer = maxBlood;
	}
}
