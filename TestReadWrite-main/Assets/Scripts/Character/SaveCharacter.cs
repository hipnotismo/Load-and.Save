using System;
using UnityEngine;

public class SaveCharacter:MonoBehaviour
{
    public const string path = "Assets/Data/Player/CharacterPosition.dat";
    public static event Action<Transform,string> SavePosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SavePosition?.Invoke(transform,path);
    }
}
