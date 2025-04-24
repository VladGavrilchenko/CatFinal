using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public List<Transform> points;
    public float speed = 5f;
    public float Delay= 1f;

    private Rigidbody2D rb;
    private int currentPointIndex = 0;
    private float timeSinceLastPoint = 0f; 
    private bool isWaiting = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (points.Count > 0)
        {
            MoveToNextPoint();
        }
    }

    void Update()
    {
        if (points.Count == 0) return;
     

        
        if (isWaiting)
        {
            timeSinceLastPoint += Time.deltaTime; 

            if (timeSinceLastPoint >= Delay)
            {
                isWaiting = false;
                timeSinceLastPoint = 0f;
                currentPointIndex++;

                if(currentPointIndex >= points.Count)
                {
                    currentPointIndex = 0;
                }
                MoveToNextPoint();
            }

            return; 
        }

        
        Vector2 targetPosition = points[currentPointIndex].position;
        Vector2 direction = (targetPosition - rb.position).normalized;

        rb.velocity = direction * speed;
         anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.sqrMagnitude);
        
        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            
            isWaiting = true;
            rb.velocity = Vector2.zero; 
        }
    }

    private void MoveToNextPoint()
    {
        Vector2 targetPosition = points[currentPointIndex].position;
        Vector2 direction = (targetPosition - rb.position).normalized;
        rb.velocity = direction * speed;
    }
}
