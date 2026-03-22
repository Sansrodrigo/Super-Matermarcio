using System;
using System.IO;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Serializable]
public class Save_do_mundo
{
    public static Save_do_mundo save = new Save_do_mundo();
    private string caminho = Application.dataPath + "/Save/Arquivo.TXT"; 
    public Vector3 posicao_Mundo = new Vector3(-0.63f, -7.99f, 0f);
    public int HP = 3;
    public Inimigo[] inimigo = new Inimigo[70];
    public int inimigoArenaID = -1;
    public Vector3 posicao_Arena = new Vector3(-0.63f, -7.99f, 0f);
    public Vector3 posicao_Atual;
    public float musicVolume = 1f;

    public Save_do_mundo()
    { 
        for (int i = 0; i < inimigo.Length; i++)
        {
            inimigo[i] = new Inimigo();
        }
    }
    public void Save() //Salva os dados do jogo em um arquivo de texto usando JSON
    {
        try
        {
            string content = JsonUtility.ToJson(this, true); //Converte o objeto Save_do_mundo para uma string JSON formatada
            File.WriteAllText(caminho, content); //Escreve a string JSON no arquivo especificado pelo caminho
        }
        catch
        {
            Debug.Log("Erro ao Salvar"); //Exibe uma mensagem de erro no console caso ocorra algum problema ao salvar
        }
    }
    public void Load() //Carrega os dados do jogo de um arquivo de texto usando JSON
    {
        if (File.Exists(caminho)) //Verifica se o arquivo de salvamento existe
        {
            string content = File.ReadAllText(caminho); //Lê o conteúdo do arquivo de salvamento e armazena em uma string
            Save_do_mundo dados = JsonUtility.FromJson<Save_do_mundo>(content); //Converte a string JSON de volta para um objeto Save_do_mundo
            this.posicao_Arena = dados.posicao_Arena; 
            this.posicao_Mundo = dados.posicao_Mundo; 
            this.HP = dados.HP;
            this.inimigo = dados.inimigo;
            this.inimigoArenaID = dados.inimigoArenaID;
            this.musicVolume = dados.musicVolume;
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

    [ContextMenu("Delete Save")]
    public void DeleteSave()
    {
        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            Debug.Log("Save deletado com sucesso.");
        }
        save = new Save_do_mundo();
    }
    public bool TemSave()
    {
        return File.Exists(caminho);
    }
   
}
