using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveAndLoad
{
    public class SaveLoad
    {
        public static void Save<T>(T data)
            where T : class
        {
            using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "gameData.moodle")))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, data);
            }
        }

        public static T Load<T>()
            where T : class
        {
            var path = Path.Combine(Application.persistentDataPath, "gameData.moodle");

            if (!File.Exists(path))
                return null;


            using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "gameData.moodle")))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(fs) as T;
            }
        }

    }
}
