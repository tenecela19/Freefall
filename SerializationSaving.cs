using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationSaving : MonoBehaviour
{
    GameController controller;
   GameObject BloquesPref;
    public static SerializationSaving Instance;

    private void Awake()
    {

        if (GameObject.FindGameObjectWithTag("GameController") == true)
            controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        else return;
    }
    public Save CreateSaveSerialization()
    {
        Save save = new Save();
        save.level = GameController.level;
        save.oldlevel = GameController.oldlevel;
        save.Highscore = GameController.BestPuntaje;
        save.BlockNum = controller.bloquesInGame;
            save.r = Bloques.colornuevo.r;
            save.g = Bloques.colornuevo.g;
            save.b = Bloques.colornuevo.b;
            save.a = Bloques.colornuevo.a;
            save.r1 = Muros.colornuevo.r;
            save.g1 = Muros.colornuevo.g;
            save.b1 = Muros.colornuevo.b;
            save.a1 = Muros.colornuevo.a;
           
            for (int i = 0; i < controller.bloquesInGame; i++)
            {
                save.blockpositionx.Add(controller.objects[i].transform.position.x);
                save.blockpositiony.Add(controller.objects[i].transform.position.y);
                save.blockpositionz.Add(controller.objects[i].transform.position.z);
                save.blockrotationy.Add(controller.objects[i].transform.localEulerAngles.y);
                save.bloquesLevel.Add(controller.objects[i].GetComponent<DestroyByCollision>().ObjectNumber);
            }
            
        return save;
    }
    public void SaveBySerialization()
    {
        Save save = CreateSaveSerialization();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream filestream = File.Create(Application.persistentDataPath + "/Data.iu");
        bf.Serialize(filestream, save);
        filestream.Close();
    }
    public void LoadBySerialization()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.iu"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream filestream = File.Open(Application.persistentDataPath + "/Data.iu", FileMode.Open);
            Save save = bf.Deserialize(filestream) as Save;
            GameController.level = save.level;
            GameController.oldlevel = save.oldlevel;
            GameController.BestPuntaje = save.Highscore;
            controller.bloquesInGame = save.BlockNum;
            Bloques.colornuevo = new Color(save.r, save.g, save.b, save.a);
            Muros.colornuevo = new Color(save.r1, save.g1, save.b1, save.a1);
            for (int i = 0; i < controller.bloquesInGame; i++)
            {
                float blockposx = save.blockpositionx[i];
                float blockposy = save.blockpositiony[i];
                float blockposz = save.blockpositionz[i];
                float blockroty = save.blockrotationy[i];
                int level = save.bloquesLevel[i];
                Instantiate(controller.BloquePrefab[level], new Vector3(blockposx, blockposy, blockposz), Quaternion.Euler(0, blockroty, 0), controller.Muro.transform);

            }
            controller.GuardadoDeBloques();
        }
        else
        {
            Debug.LogError("NO DATA");
        }
    }
}
