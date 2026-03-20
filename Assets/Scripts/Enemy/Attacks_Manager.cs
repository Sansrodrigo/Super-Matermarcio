using System.Collections;
using UnityEngine;

public class Attacks_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Attack_List;
    //0 = Teardrop


    enum ATKSets //Salva os sets de ataques disponiveis
    {
        TearFall_Y,
        TearFall_X
    }

    ATKSets ActiveSet = ATKSets.TearFall_Y; //Set de ataque ativo no momento

    public void Start()
    {
        SetChange();
    }

    public void SetChange()
    {
        Debug.Log("SET CHANGED");
        switch (ActiveSet)
        {
            case ATKSets.TearFall_Y:
                StartCoroutine(TearSpawn(ActiveSet));
                break;
            case ATKSets.TearFall_X:
                StartCoroutine(TearSpawn(ActiveSet));
                break;
        }
    }

    ///////SPAWN DE ATTACKS

    IEnumerator TearSpawn(ATKSets ActiveSet)
    {
        int rand = Random.Range(3, 6); //Pode dar de 3 a 6 disparos

        for (int i = 0; i < rand; i++)
        {
            //Checkar Range determinado IN-GAME
            Instantiate(Attack_List[0], new Vector3(Random.Range(-6.0f, 7.49f), 8, 0), Quaternion.identity);
            Instantiate(Attack_List[0], new Vector3(Random.Range(-9.46f,8.49f),8,0), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }

        SetChange();
        StopCoroutine(TearSpawn(ActiveSet));
    }
}

