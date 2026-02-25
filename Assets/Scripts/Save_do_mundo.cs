using System;
using System.IO;
using UnityEngine;
[Serializable]
public class Save_do_mundo
{

    private string caminho = Application.dataPath + "/Save/Arquivo.TXT";
    public Vector3 posicao = Vector3.zero;
    public int HP = 3;
    
    public Inimigo[] inimigo = new Inimigo[0];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Save()
    {
        try
        {
            string content = JsonUtility.ToJson(this, true);
            File.WriteAllText(caminho, content);
        }
        catch
        {
            Debug.Log("Erro ao Salvar");
        }
    }
    public void Load()
    {
        string content = File.ReadAllText(caminho);
        // Json p = JsonUtility.FromJson<Json>(content);

    }
    [Serializable]
    public class Inimigo
    {
        public Vector3 position;
    }
}
