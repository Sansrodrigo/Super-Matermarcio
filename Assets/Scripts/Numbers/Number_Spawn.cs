using UnityEngine;
using System.Collections.Generic;

public class Number_Spawn : MonoBehaviour
{
    // Spawn area boundaries
    private const float minX = -6.46f;
    private const float maxX = 5.4f;
    private const float minY = -4.5f;
    private const float maxY = 4.5f;
    private const bool randomizeOnStart = true;
    private const bool useLocalPosition = false;
    
    // Collision avoidance
    private const float minDistance = 2.5f;
    private const int maxAttempts = 100;

    // Global registry to prevent overlapping positions
    private static List<Vector2> occupiedPositions = new List<Vector2>();
    private static Dictionary<int, Vector2> positionByInstance = new Dictionary<int, Vector2>();

    void Start()
    {
        // Auto-spawn at random position if enabled
        if (randomizeOnStart) RandomizePosition();
    }

    // Find unique position and place object, or fallback if max attempts exceeded
    [ContextMenu("Randomize Position")]
    public void RandomizePosition()
    {
        float z = useLocalPosition ? transform.localPosition.z : transform.position.z;
        Vector2 chosenPos = Vector2.zero;
        bool found = false;

        // Try to find a position that doesn't collide with existing objects
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            // Convert to world position if using local coordinates
            Vector3 worldPos3 = useLocalPosition && transform.parent != null
                ? transform.parent.TransformPoint(new Vector3(x, y, z))
                : new Vector3(x, y, z);

            Vector2 worldPos2 = new Vector2(worldPos3.x, worldPos3.y);

            // Check for collisions with already occupied positions
            bool collision = false;
            foreach (var occupied in occupiedPositions)
            {
                if (Vector2.Distance(worldPos2, occupied) < minDistance)
                {
                    collision = true;
                    break;
                }
            }

            // Found a valid position
            if (!collision)
            {
                chosenPos = worldPos2;
                SetPositionFromWorldXY(chosenPos, z);
                occupiedPositions.Add(chosenPos);
                positionByInstance[GetInstanceID()] = chosenPos;
                found = true;
                break;
            }
        }

        // Fallback if no unique position found
        if (!found)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            chosenPos = new Vector2(x, y);
            SetPositionFromWorldXY(chosenPos, z);
            occupiedPositions.Add(chosenPos);
            positionByInstance[GetInstanceID()] = chosenPos;
            Debug.LogWarning($"Number_Spawn: no unique position found after {maxAttempts} attempts for {name}");
        }
    }

    // Apply world position, handling both local and world coordinate modes
    private void SetPositionFromWorldXY(Vector2 worldXY, float z)
    {
        if (useLocalPosition && transform.parent != null)
        {
            Vector3 localPos = transform.parent.InverseTransformPoint(new Vector3(worldXY.x, worldXY.y, z));
            transform.localPosition = localPos;
        }
        else
        {
            Vector3 p = transform.position;
            p.x = worldXY.x;
            p.y = worldXY.y;
            p.z = z;
            transform.position = p;
        }
    }

    // Remove this object's position from global registry when destroyed
    private void OnDestroy()
    {
        int id = GetInstanceID();
        if (positionByInstance.TryGetValue(id, out Vector2 pos))
        {
            positionByInstance.Remove(id);
            occupiedPositions.Remove(pos);
        }
    }
}
