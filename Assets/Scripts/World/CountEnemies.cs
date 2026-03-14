using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> countEnemies = new List<GameObject>();

    void Start()
    {
        PopulateFromEnemies();
    }

    // Preenche 'countEnemies' com instâncias baseadas na lista 'enemies'.
    // Limpa a lista atual antes de popular para evitar duplicatas.
    public void PopulateFromEnemies()
    {
        countEnemies.Clear();

        for (int i = 0; i < enemies.Count; i++)
        {
            var prefab = enemies[i];
            if (prefab == null) continue;

            var instance = Instantiate(prefab, transform.position, Quaternion.identity, transform);
            instance.name = $"{prefab.name}_{i}";
            countEnemies.Add(instance);
        }
    }
}
