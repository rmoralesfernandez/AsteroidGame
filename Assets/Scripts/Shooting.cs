using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;

    [SerializeField]
    private Transform trReference;

    private bool isShooting = false;

    private int poolPos;
    // Start is called before the first frame update
    void Start()
    {
        poolPos = ObjectPooler.instance.SearchPool(prefabBullet);
    }

    // Update is called once per frame
    void Update()
    {
        //Disparamos utilizando el click izquierdo del ratón
        isShooting = Input.GetMouseButtonDown(0);
        Shoot();
    }

    private void Shoot () {
        if(isShooting) {
            //Instaciar balas sin poolObject
            //GameObject bullet = Instantiate(prefabBullet, trReference.position, trReference.rotation);

            //Por si se sale del object pooler que nos salga un error
            if(poolPos == -1)
            {
                Debug.LogError("Shooting::Shoot there is no bullets prefab in ObjectPooler");
                return;
            }

            //Llamamos al ObjectPooler e instaciamos las balas en active para volver a usarlas
            GameObject bullet = ObjectPooler.instance.GetPooledObject(poolPos);
            bullet.transform.position = trReference.position;
            bullet.transform.rotation = trReference.rotation;

            bullet.SetActive(true);
        }
    }
}
