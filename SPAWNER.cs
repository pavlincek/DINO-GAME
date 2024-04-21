using UnityEngine;

public class SPAWNER : MonoBehaviour
{
    [System.Serializable]
   public struct SpawnableObject
   {
    public GameObject prefab;
    [Range(0f, 1f)]
    public float spawnChance;
   }

    public SpawnableObject[] objects;

    public float minSpawnRate = 0f;
    public float maxSpawnRate = 0.5f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


    private void Spawn()
    {       float spawnChance = Random.value;
       
            foreach(var obj in objects)
            {
             if(spawnChance < obj.spawnChance)
                {
                    GameObject obstacle = Instantiate(obj.prefab);
                    obstacle.transform.position += transform.position;
                    break;
                }

                spawnChance -= obj.spawnChance;
            
            }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
        
        
    }

    

}
