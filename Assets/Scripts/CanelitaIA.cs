using System.Collections;
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

    public GameObject upCone;
    public GameObject bottomCone;
    public GameObject leftCone;
    public GameObject rightCone;
    public GameObject visualCones;

    [HideInInspector] public bool isDetecting = false;
    [HideInInspector] public bool stoppedDetecting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = 0;
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
        if (stoppedDetecting)
        {
            speed = 15.0f;
            currentPoint = 0;
            stoppedDetecting = false;
        }
        if (!isMoving && !isDetecting && !stoppedDetecting)
        {
            SetTargetPosition();
        }
        else if (isDetecting)
        {
            CatchPlayer();
        }
    }

    private void CatchPlayer()
    {
        isDetecting = true;
        speed = 25.0f;
        currentPointToGo = GameObject.FindGameObjectWithTag("Player");
        difference = currentPointToGo.transform.position - transform.position;
        targetPosition = currentPointToGo.transform.position;
        targetPosition.z = 0;
        upCone.SetActive(true);
        bottomCone.SetActive(true);
        leftCone.SetActive(true);
        rightCone.SetActive(true);
        visualCones.SetActive(true);
        isMoving = true;
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
        GetMoveDireccion(PointsToGo[currentPoint]);
        isMoving = true;
    }

    private void Move()
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
        if (transform.position == targetPosition)
        {
            isMoving = false;
            SetTargetPosition();
        }
    }

    private void GetMoveDireccion(GameObject pointToGo)
    {
        if (pointToGo.transform.position.x > gameObject.transform.position.x)
        {
            upCone.SetActive(false);
            bottomCone.SetActive(false);
            leftCone.SetActive(false);
            rightCone.SetActive(true);
        }
        if (pointToGo.transform.position.x < gameObject.transform.position.x)
        {
            leftCone.SetActive(true);
            rightCone.SetActive(false);
            upCone.SetActive(false);
            bottomCone.SetActive(false);
        }
        if (pointToGo.transform.position.y > gameObject.transform.position.y)
        {
            upCone.SetActive(true);
            bottomCone.SetActive(false);
            leftCone.SetActive(false);
            rightCone.SetActive(false);
        }
        if (pointToGo.transform.position.y < gameObject.transform.position.y)
        {
            upCone.SetActive(false);
            bottomCone.SetActive(true);
            leftCone.SetActive(false);
            rightCone.SetActive(false);
        }
    }
}
