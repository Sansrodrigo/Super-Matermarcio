using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
   // private float minX = -13.86f;
   // private float maxX = 3.13f;
   // private float minY = -1.8f;
    //float maxY = 2.78f;

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    private List<GameObject> countEnemies = new List<GameObject>();

    void Start()
    {
        PopulateFromEnemies();
    }
    public void PopulateFromEnemies()
    {
        SaveManager.save.Load();

        for (int i = 0; i < enemies.Count; i++)
        {

            var instance = Instantiate(enemies[i], transform.position, Quaternion.identity);
            instance.name = $"{enemies[i].name}_{i}";
            instance.transform.parent = this.gameObject.transform;
            instance.GetComponent<Movement_Enemy>().id = i;
            countEnemies.Add(instance);
        }
        
        SaveManager.save.Save();
    }
}
