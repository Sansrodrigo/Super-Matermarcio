using System;
using System.IO;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Serializable]
public class SaveManager
{
    public static SaveManager save = new SaveManager();
    // private string caminho = Application.dataPath + "/Save/Arquivo.TXT"; ainda nao apagar teste 
    private string caminho;
    public Vector3 posicao_Mundo = new Vector3(-0.63f, -7.99f, 0f);
    public int HP = 3;
    public Inimigo[] inimigo = new Inimigo[70];
    public int inimigoArenaID = -1;
    public Vector3 posicao_Arena = new Vector3(-0.63f, -7.99f, 0f);
    public Vector3 posicao_Atual;
    public float musicVolume = 1f;
    public SaveManager()
    {
        for (int i = 0; i < inimigo.Length; i++)
        {
            inimigo[i] = new Inimigo();
        }
    }
    public void Save() //Salva os dados do jogo em um arquivo de texto usando JSON
    {
        string pasta = Application.persistentDataPath + "/Save";
        if (!Directory.Exists(pasta))
        {
            Directory.CreateDirectory(pasta);
        }
        caminho = pasta + "/Arquivo.txt";
        try
        {
            string content = JsonUtility.ToJson(this, true); //Converte o objeto SaveManager para uma string JSON formatada
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
            SaveManager dados = JsonUtility.FromJson<SaveManager>(content); //Converte a string JSON de volta para um objeto SaveManager
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
        public bool isActive = true;

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
        save = new SaveManager();
    }
    public bool TemSave()
    {
        return File.Exists(caminho);
    }
   
}
