using UnityEngine;

public class SpwanEnemiesManager : MonoBehaviour
{
    int setor,Setor_Oeste,Setor_Leste,Setor_Norte,Setor_Sul;
    public float minX, maxX, minY, maxY;
    public void SpawnEnemies()
    { 
    switch (setor)
        {
            case 0:
                Setor_Oeste = 0;
                break;
        }
    }
}
