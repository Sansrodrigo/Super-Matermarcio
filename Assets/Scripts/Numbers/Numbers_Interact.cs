using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Numbers : MonoBehaviour
{
    [SerializeField] private List<int> numbers = new List<int>();

    // Retorna o índice da primeira ocorrência de `value`, ou -1 se não existir
    public int GetIndexOf(int value)
    {
        return numbers.IndexOf(value);
    }

    // Retorna todos os índices em que `value` aparece
    public int[] GetIndicesOf(int value)
    {
        var indices = new List<int>();
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == value) indices.Add(i);
        }
        return indices.ToArray();
    }

    // Retorna todos os índices válidos para a lista (0 .. Count-1)
    public int[] GetAllIndices()
    {
        return Enumerable.Range(0, numbers.Count).ToArray();
    }

    // Exemplo: loga os índices no console
    public void LogIndices()
    {
        Debug.Log(string.Join(", ", GetAllIndices()));
    }

    void Start() { }

    void Update() { }
}
