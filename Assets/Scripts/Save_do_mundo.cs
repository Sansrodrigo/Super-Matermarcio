using System;
using System.IO;
using UnityEngine;
[Serializable]
public class Save_do_mundo
{
    private string caminho = Application.dataPath + "/Save/Arquivo.TXT";
    public Vector3 posicao = new Vector3(-11.2f,2.5f,0f);
    public int HP = 3;
   
    public Inimigo[] inimigo = new Inimigo[3];
    public  Save_do_mundo()
    { 
        for (int i = 0; i < inimigo.Length; i++)
        {
            inimigo[i] = new Inimigo();
        }
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
        if (File.Exists(caminho))
        {
            string content = File.ReadAllText(caminho);
            Save_do_mundo dados = JsonUtility.FromJson<Save_do_mundo>(content);
            // copiando dados
            this.posicao = dados.posicao;
            this.HP = dados.HP;
            this.inimigo = dados.inimigo;
        }
        else
        {
            Debug.Log("erro ao carregar");
        }
    }
    [Serializable]
    public class Inimigo
    {
        public Vector3 position;
    }
}
