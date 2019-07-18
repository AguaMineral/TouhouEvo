using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectMousePosOnClick();
        MoveToClickPos();
    }

    void DetectMousePosOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void MoveToClickPos()
    {
        if (!(targetPosition.y >= 2.6) && !(targetPosition.y <= -4.5))
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20f);
    }
}
