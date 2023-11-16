using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private int score = 5;

    [SerializeField]
    private Vector2 goal;

    [SerializeField]
    private GameObject prefabMiniAster;

    private Vector2 distance;

    private Rigidbody2D rb;
    private Transform tr;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent <Rigidbody2D>();
        tr = GetComponent<Transform>();

        // Rotación de los asteroides
        Vector2 objectPos = tr.position;
        distance.x = goal.x - objectPos.x;
        distance.y = goal.y - objectPos.y;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.Euler(new Vector3(0, 0, angle));  

        

        if(this.gameObject.tag == "MiniAsteroid")
        {
            int x = Random.Range(-1, 1);
            int y = Random.Range(-1, 1);

            rb.AddForce(speed * new Vector3(x, y, 0), ForceMode2D.Impulse);

        }
        else 
        {
            // Movimiento de los asteroides
            rb.AddForce(speed * tr.right, ForceMode2D.Impulse); 
        }
    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.tag == "Bullet")
        {
            collider.gameObject.SetActive(false);

            GameController.instance.ScoreUp(score);

            if(this.gameObject.tag == "Asteroid") 
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(prefabMiniAster, tr.position, Quaternion.identity);
                }
            }

            this.gameObject.SetActive(false);
        }
    }


}
