using System.IO;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    private void OnEnable()
    {
        LoadCharacter.LoadPosition += OnLoadPosition;
        LevelGenerator.LoadLevel += OnLoadLevel;
    }

    private void OnDisable()
    {
        LoadCharacter.LoadPosition += OnLoadPosition;
        LevelGenerator.LoadLevel -= OnLoadLevel;
    }
    
    private void OnLoadPosition(Transform p, string path)
    {  
       if (!File.Exists(path)) return;
       FileStream fs = File.OpenRead(path);
       BinaryReader br = new BinaryReader(fs);
       Vector3 pos = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
       
       p.position = pos;
       br.Close();
       fs.Close();
    }
    
    private void OnLoadLevel(GameObject prefab,string path,Transform parent)
    {
        if (!File.Exists(path)) return;
        long tam;
        FileStream fs = File.OpenRead(path);
        BinaryReader br = new BinaryReader(fs);

        tam = fs.Length / 4;
        tam = tam / 2;

        for (int i = 0; i < tam; i++)
            Instantiate(prefab, new Vector3(br.ReadInt32(), 0.5f, br.ReadInt32()), prefab.transform.rotation,parent);
        
        br.Close();
        fs.Close();
    }
    
    

   
}
