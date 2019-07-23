using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    public int score;

    /*
     * La posición en unity al guardarla debe hacerse
     * a través de arrays, vector2 es una clase de unity,
     * no está implementada en C#
     */
    public float[] position;

    // TO DO : Implement for pachinko
    // public int money;

    //Constructor

    
    public playerData(playerController player)
    {
        score = player.score;

        //monney = player.money;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
