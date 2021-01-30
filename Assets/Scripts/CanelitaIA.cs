﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanelitaIA : MonoBehaviour
{
    public GameObject[] PointsToGo;
    private GameObject currentPointToGo;
    private int currentPoint = 0;
    private bool goingBackwards = false;
    private Vector3 difference;
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    private float speed = 15;
    private bool isMoving = false;
    private bool firstMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = 0;
        //SetTargetPosition();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void Update()
    {
        if (!isMoving)
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        if (currentPoint == PointsToGo.Length - 1)
        {
            goingBackwards = true;
        }

        if (currentPoint == 0)
        {
            goingBackwards = false;
        }

        if (!goingBackwards)
        {
            currentPoint++;
        }

        else
        {
            currentPoint--;
        }

        currentPointToGo = PointsToGo[currentPoint];
        difference = currentPointToGo.transform.position - transform.position;
        targetPosition = currentPointToGo.transform.position;
        targetPosition.z = 0;
        isMoving = true;
    }

    void Move()
    { 
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
        if (transform.position == targetPosition)
        {
            isMoving = false;
            SetTargetPosition();
        }
    }
}
