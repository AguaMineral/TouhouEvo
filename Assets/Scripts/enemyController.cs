using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private float characterVelocity = 1.2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    Vector2 center;
    bool goingToCenter = false;
    
    void Start()
    {
        center = GameObject.Find("CenterOfScreen").transform.position;
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void Update()
    {
        //Comprobar si está en rango o no está en rango
        if (ComprobarRango() && !goingToCenter)
        {

            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
            }
            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
        else
            IrAlOrigen();

        if (transform.position.x == center.x && transform.position.y == center.y)
            goingToCenter = false;
        
    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    bool ComprobarRango()
    {
        if ( (transform.position.x <= -2.7f) || (transform.position.x >= 2.7f) || (transform.position.y <= -4.84) || (transform.position.y >= 2.4))
            return false;
        else
            return true;
    }
    void IrAlOrigen()
    {
        transform.position = Vector2.MoveTowards(transform.position, center, Time.deltaTime * characterVelocity);
        goingToCenter = true;
    }

}
