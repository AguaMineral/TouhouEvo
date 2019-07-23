using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem //Una clase estática no puede instanciarse
{
    public static void SavePlayer(playerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.aqu";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static playerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.aqu";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();

            return data;
        }
        else
        { 
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    // TO DO : Save and load system for enemies
    //public static void  SaveEnemies(enemyController enemy)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/enemies.aqu";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    enemiesData data = new enemiesData(enemy);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}
}
