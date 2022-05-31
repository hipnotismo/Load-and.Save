using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private string path = "Assets/Data/level.dat";
    
    public static event Action<GameObject,string,Transform> LoadLevel;

    private void Start()
    {
        LoadLevel?.Invoke(prefab,path,transform);
    }
}
