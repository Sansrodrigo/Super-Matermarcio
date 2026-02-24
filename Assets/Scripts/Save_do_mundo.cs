using System;
using System.IO;
using UnityEngine;
public class Save_do_mundo : MonoBehaviour
{
  
    private string caminho = Application.dataPath + "/Save/Arquivo.TXT";
    public Vector3 posicao = Vector3.zero;
    public int HP = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
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

    }
}
