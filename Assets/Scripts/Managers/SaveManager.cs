/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

#nullable enable
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance
        {
            get
            {
                Debug.Assert(_instance is not null, nameof(_instance) + " != null");
                return _instance;
            }
        }

    #region Variables
    #endregion
    
    #region Private Fields

        private static SaveManager? _instance;
    #endregion

    #region Unity Methods
        void Awake()
        {
            if (_instance is null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    #endregion

    #region Public Methods

        public void Save(object entity, string filename)
        {
            filename = Application.persistentDataPath + "\\" + filename;
            string saveData = entity.Serialize().json;
            var outputFile = new StreamWriter(filename);

            outputFile.WriteLine(saveData);
            outputFile.Close();
        }
        
        public T? Load<T>(string filename) where T:class
        {
            filename = Application.persistentDataPath + "\\" + filename;

            if (!File.Exists(filename))
                return null;
            
            var inputFile = new StreamReader(filename);
            var saveData = inputFile.ReadToEnd();

            Debug.Log(filename + " " + saveData);

            return new SerializationData(saveData).Deserialize() as T;
        }

        #endregion

    #region Private Methods
    #endregion
    }
}