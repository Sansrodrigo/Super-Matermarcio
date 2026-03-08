using System;
using System.IO;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Serializable]
public class Save_do_mundo
{
    public static Save_do_mundo save = new Save_do_mundo();
    private string caminho = Application.dataPath + "/Save/Arquivo.TXT";
    public Vector3 posicao = new Vector3(-0.63f, -7.99f, 0f);
    public int HP = 3;
    public Inimigo[] inimigo = new Inimigo[3];
    public int inimigoArenaID = -1;


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

            this.posicao = dados.posicao;
            this.HP = dados.HP;
            this.inimigo = dados.inimigo;
            this.inimigoArenaID = dados.inimigoArenaID;
        }
        else
        {
            Debug.Log("Erro ao carregar");
        }
    }
    [Serializable]
    public class Inimigo
    {
        public Vector3 position;
        public bool inimigoActive = true;
        public Inimigo()
        {
            this.position = new Vector3();
              
             }
    }
    public void DeleteSave()
    {
        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            Debug.Log("Save deletado com sucesso.");
        }
        save = new Save_do_mundo(); 
    }
}
