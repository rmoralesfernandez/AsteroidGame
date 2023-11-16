using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField]
    private float timeToRespawn = 1.5f;

    [SerializeField]
    private GameObject ShipModel;

    private bool alive = true;

    private Coroutine playerDeath;

    // Update is called once per frame
    private void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.tag == "Asteroid" && alive || collider.tag == "MiniAsteroid" && alive)
        {
            if(GameController.instance.PlayerDie())
            {
                alive = false;
                playerDeath = StartCoroutine(DieAndRevive());
            }
        }
    }

    private IEnumerator DieAndRevive()
    {
        while(!alive)
        {
            ShipModel.SetActive(false);

            yield return new WaitForSeconds(timeToRespawn);

            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ShipModel.SetActive(true);

            GameController.instance.Replay();
            alive = true;
            
            yield return null;
        }
    }
}
