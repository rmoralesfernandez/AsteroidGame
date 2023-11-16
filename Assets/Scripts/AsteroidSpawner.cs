using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabAster;

    [SerializeField]
    private Transform[] spawners;

    [SerializeField]
    private float timeToSpawn = 1;

    private int poolPos;
    // Start is called before the first frame update
    void Start()
    {
        poolPos = ObjectPooler.instance.SearchPool(prefabAster);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn () 
    {
        
        while(true)
        {

            int randomSpawner = Random.Range(0, spawners.Length);
            //Instantiate(prefabAster, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
            //yield return new WaitForSeconds(timeToSpawn);
        

        if(poolPos == -1)
        {
            Debug.LogError("Shooting::Shoot there is no bullets prefab in ObjectPooler");
            yield return null;
        }

            //Llamamos al ObjectPooler e instaciamos las balas en active para volver a usarlas
            GameObject asteroid = ObjectPooler.instance.GetPooledObject(poolPos);
            asteroid.transform.position = spawners[randomSpawner].position;
            asteroid.transform.rotation = spawners[randomSpawner].rotation;

            asteroid.SetActive(true);
            
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
