using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float randX, randY;
    Vector2 spawnPoint;
    public float spawnRate;
    float nextSpawn = 0.0f;
    public int MAX_NUMBER_OF_ENEMIES = 15;
    public int enemiesLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();     
        
    }

    void Spawn()
    {
        //Solo spawnear si ha pasado el tiempo suficiente y si no se sobrepasa el numero máximo de enemigos
        if (Time.time > nextSpawn && enemiesLeft < MAX_NUMBER_OF_ENEMIES)
        {
            //Actualizar el tiempo que queda para el siguiente spawn
            nextSpawn = Time.time + spawnRate;

            //posicion de spawn random en pantalla
            randX = Random.Range(-2.4f, 2.4f);
            randY = Random.Range(-4.0f, 2.0f);
            spawnPoint = new Vector2(randX, randY);

            //instanciar enemigo en la posicion random
            Instantiate(enemy, spawnPoint, Quaternion.identity);

            enemiesLeft++;
        }
    }
}
