using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefap;

    public Transform spawnPosition;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefap, spawnPosition.position, Quaternion.identity); //Crear clon 
        // (objeto, donde queremos clonar, rotacion (Quaternion.identity coje los valores que tiene el prefab, en este caso 0 0 0))
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SpawnEnemy();
        }
    }
}
