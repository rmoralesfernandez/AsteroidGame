using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20;

    [SerializeField]
    private float timeToHide = 2;

    private float count = 0;

    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        count = timeToHide;
    }

    private void OnEnable ()
    {
        count = timeToHide;
    }

    // Update is called once per frame
    void Update()
    {
        if(count > 0) {
            count -= Time.deltaTime;
        } else {
            this.gameObject.SetActive(false);
        }

        tr.position += tr.up * speed * Time.deltaTime;
    }
}
