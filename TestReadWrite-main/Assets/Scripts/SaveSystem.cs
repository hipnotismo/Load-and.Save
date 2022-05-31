using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private void OnEnable()
    {
        SaveCharacter.SavePosition += OnSavePosition;
    }

    private void OnDisable()
    {
        SaveCharacter.SavePosition -= OnSavePosition;
    }

    private void OnSavePosition(Transform p, string path)
    {
        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(p.position.x);
        bw.Write(p.position.y);
        bw.Write(p.position.z);
        
        bw.Close();
        fs.Close();
    }
}
