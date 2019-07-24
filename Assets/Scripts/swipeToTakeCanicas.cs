using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeToTakeCanicas : MonoBehaviour
{
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;

    Vector2 previousPosition;
    public float minCuttingVelocity = 0.001f;
    
    CircleCollider2D circleCollider;

    //Para actualizar el score al colisionar con las canicas
    public playerController player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // El corte del swip comienza al dar click y para al soltarlo
        // lo mismo para pantallas
        if (Input.GetMouseButtonDown(0))
        {
            StartCut();
        }else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        //El circleCollider que detectará la posición solo
        // se activará con una velocidad minima, que significa
        // que el control se está moviendo durante el swipe en la pantalla

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
            circleCollider.enabled = false;
        previousPosition = newPosition;
    }

    void StartCut()
    {
        isCutting = true;
        circleCollider.enabled = false;
    }

    void StopCut()
    {
        isCutting = false;
        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.CompareTag("canica"))
        {
            Destroy(other.gameObject);

            FindObjectOfType<AudioManager>().Play("Canica");

            player.score += 10;
            player.UpdateScore();
        }
        
    }
}
