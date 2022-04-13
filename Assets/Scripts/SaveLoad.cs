using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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

            T toReturn;
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                toReturn = formatter.Deserialize(fs) as T;
            }

            return toReturn;
        }

    }
}
