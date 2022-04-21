using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [System.Serializable]
    public class LevelData
    {
        public string LevelName;
        public SceneReference Scene;
    }

    [SerializeField] private LevelData Mainmenu;
    [SerializeField] private LevelData[] Levels;

    void Start()
    {
        LoadLevel("FirstLevel");
    }

    public void LoadLevel(string name)
    {
        foreach (LevelData data in Levels)
        {
            if (data.LevelName.Equals(name))
            {
                SceneManager.LoadScene(data.Scene);
                return;
            }
        }
    }
}
