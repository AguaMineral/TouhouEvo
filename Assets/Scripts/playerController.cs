using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    GameObject spawner;
    int enemyCountFirst;
    int enemyCountLast;
    public int score = 0;
    public Text scoreText;

    public Vector2 targetPosition;

    // TO DO : Implement for pachinko
    // public int money;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("enemySpawner");
        LoadPlayer();
        UpdateScore();
        
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
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //score++;
            //
        }
            
    }

    void MoveToClickPos()
    {
        if (!(targetPosition.y >= 2.6) && !(targetPosition.y <= -4.5))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20f);
        }
    }

    public void UpdateScore()
    {
        
        scoreText.text = score.ToString();
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        playerData data = SaveSystem.LoadPlayer();

        score = data.score;
                
    }
}
