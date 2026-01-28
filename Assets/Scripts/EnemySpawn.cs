using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefap;

    public int enemiesToSpawn = 5;

    private BoxCollider2D _boxCollider;

    public Transform spawnPosition;
    public Transform spawnPosition2;

    public Transform[] spawnPoints; //variable array una bariable que permite almacenar diversos valores en ella

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    //void SpawnEnemy()
    //{
       

        //for (int i = 0; i < enemiesToSpawn; i++) //bucle que se ejecuta mientras se cumpla una condicion sirve para repetir codigo,
        // (variable de control; Condicion que se tiene que cumplir para que se ejecute el bucle como numero de veces que quieres que se ejecute; 
        // lo que le pasa a la variable de control cada vez que se ejecuta el bucle, ejemplo suma uno a la veriable de bucle)
        //{
        //     Instantiate(enemyPrefap, spawnPosition.position, Quaternion.identity); //Crear clon 
        // (objeto, donde queremos clonar, rotacion (Quaternion.identity coje los valores que tiene el prefab, en este caso 0 0 0))
        //}
    //}
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    IEnumerator SpawnEnemy() //Es una funcion que se puede parar (corrutina)
    {
        for (int i = 0; i < enemiesToSpawn; i++) //bucle que se ejecuta mientras se cumpla una condicion sirve para repetir codigo,
        // (variable de control; Condicion que se tiene que cumplir para que se ejecute el bucle como numero de veces que quieres que se ejecute; 
        // lo que le pasa a la variable de control cada vez que se ejecuta el bucle, ejemplo suma uno a la veriable de bucle)
        {

            foreach (Transform item in spawnPoints) //bucle que por cada elemento en mi arrai pasa algo
            // se ejecuta uan vez por cada elemento que hay en el arey en este caso, (tipo de variable)
            {
                Instantiate(enemyPrefap[Random.Range(0, enemyPrefap.Length)], item.position, Quaternion.identity);
            //el enemyPrefap la hemos echo array entonces le ponemos que coje el enemigo random escogiendo entre los numeros que hay en el aray
            // con esto puedes spawnear 2 o mas tipos de enemigos que esten dentro de la variable array de enemyPrefap
            //Crear clon (objeto, donde queremos clonar en este caso con variable de arrai, rotacion (Quaternion.identity coje los valores que tiene el prefab, en este caso 0 0 0))
            }
             yield return new WaitForSeconds(0.5f); //para la funcion si esta en una funcion si esta en una coorutina la para y luego la reanuda

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            StartCoroutine(SpawnEnemy()); //inicia la corrutina
        }
    }
}
