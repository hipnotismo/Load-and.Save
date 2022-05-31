using System;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public static event Action<Transform,string> LoadPosition;
    
    private void Start()
    {
       LoadPosition?.Invoke(transform,SaveCharacter.path);
    }
    
    
}
