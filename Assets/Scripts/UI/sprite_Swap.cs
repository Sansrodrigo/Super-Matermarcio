using UnityEngine;

public class sprite_Swap : MonoBehaviour
{
    SpriteRenderer sprite;

    public Sprite inimigoMulti;
    public Sprite inimigoMais;
    public Sprite inimigoMenos;

    void Start()
    {

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        int id = SaveManager.save.inimigoArenaID; //nao apagar aqui pega os id dos inimigos e salva
        Debug.Log("ID inimigo Arena: " + SaveManager.save.inimigoArenaID);
        if (id == 0)
            sprite.sprite = inimigoMulti;
        else if (id == 1)
            sprite.sprite = inimigoMais;
        else if (id == 2)
            sprite.sprite = inimigoMenos;
    }
}
