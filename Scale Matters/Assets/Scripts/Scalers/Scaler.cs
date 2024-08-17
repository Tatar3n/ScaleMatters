using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float speed = 2f; 
    public float distance = 5f; 
    public float minPauseTime = 1f; 
    public float maxPauseTime = 3f;
    public Transform startPosition;
    
    private Transform scalerTransform;
    private bool movingRight = true;
    private bool canMove = true;
    private bool isRandomEnumStart = false;
    private bool isRandomEnumStartFully = false;

    void Start()
    {
        scalerTransform = GetComponent<Transform>();
        scalerTransform.position = new Vector3(startPosition.position.x + Random.Range(-distance, distance), startPosition.position.y, 0);

        if ((int)Random.Range(0f, 2f) == 0)
            movingRight = true;
        else
            movingRight = false;

        speed += Random.Range(-1f, 1f);

        StartCoroutine(Pause());
    }

    void Update()
    {
        StandartMove();
        Rotate();
    }

	private void StandartMove()
    {
        if (canMove)
            if (movingRight)
                transform.position += Vector3.right * speed * Time.deltaTime;
            else
                transform.position -= Vector3.right * speed * Time.deltaTime;

        if (transform.position.x >= startPosition.position.x + distance)
        {
            movingRight = false;
            StartCoroutine(Pause());
        }
        else if (transform.position.x <= startPosition.position.x - distance)
        {
            movingRight = true;
            StartCoroutine(Pause());
        }

        if(!isRandomEnumStart)
            StartCoroutine(IsRandomlyRotateEnumenator());
    }

    private IEnumerator IsRandomlyRotateEnumenator()
    {
        isRandomEnumStart = true;
        yield return new WaitForSeconds(5f);
        if (Random.Range(0f, 3f) <= 1f)
        {
            StartCoroutine(RandomlyRotateEnumenator());
            isRandomEnumStartFully = true;
        }
        if (!isRandomEnumStartFully)
            isRandomEnumStart = false;
    }

    private IEnumerator RandomlyRotateEnumenator()
    {
        canMove = false;
        yield return new WaitForSeconds(3f);
        movingRight = !movingRight;
        Rotate();
        isRandomEnumStart = false;
        isRandomEnumStartFully = false;
        canMove = true;
    }

    private void Rotate()
    {
        if (movingRight)
            scalerTransform.rotation = Quaternion.Euler(0, 0, 0);
        else
            scalerTransform.rotation = Quaternion.Euler(0, 180, 0);
    }

	private IEnumerator Pause()
    {
        float pauseDuration = Random.Range(minPauseTime, maxPauseTime);
        canMove = false;
        yield return new WaitForSeconds(pauseDuration);
        canMove = true;
    }
}
