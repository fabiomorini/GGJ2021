using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private Vector2 force;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		force = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed).normalized;
		rb.MovePosition(rb.position + force * speed * Time.fixedDeltaTime);
	}
}
