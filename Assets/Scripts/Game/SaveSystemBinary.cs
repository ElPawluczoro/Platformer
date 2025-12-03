namespace Game
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;

    public static class SaveSystemBinary
    {
        private static string _saveFileName = "gamesave.dat";

        public static void Save(GameSave save)
        {
            string path = Path.Combine(Application.persistentDataPath, _saveFileName);
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Create(path))
            {
                bf.Serialize(file, save);
            }
        }

        public static GameSave Load()
        {
            string path = Path.Combine(Application.persistentDataPath, _saveFileName);
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = File.OpenRead(path))
                {
                    return (GameSave)bf.Deserialize(file);
                }
            }
            else
            {
                return new GameSave();
            }
        }
    }

}