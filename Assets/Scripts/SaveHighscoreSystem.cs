using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveHighscoreSystem : MonoBehaviour
{

   public static void SaveHighscore(string[] names, float[] times)
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/highscore.gothic2";
      FileStream stream = new FileStream(path, FileMode.Create);

      HighscoreData data = new HighscoreData(names, times);
      
      formatter.Serialize(stream,data);
      stream.Close();
   }

   public static HighscoreData LoadHighscore()
   {
      string path = Application.persistentDataPath + "/highscore.gothic2";

      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         
         HighscoreData data = formatter.Deserialize(stream) as HighscoreData;
         stream.Close();

         return data;
      }
      else
      {
         Debug.Log($"Save file in {path} doesn't exisit");
         return null;
      }
   }
}
