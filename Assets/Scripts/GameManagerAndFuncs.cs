using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManagerAndFuncs 
{
    public static void DestroyGameObjectsWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("canica");
        foreach(GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }


}
