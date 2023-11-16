using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float velocity = 10;

    [SerializeField]
    private float maxSpeed = 20;

    private float vertical;

    private Rigidbody2D rb;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        Rotate();
    }

    private void FixedUpdate () {
        Move();
    }

    private void Move () {
        rb.AddForce(velocity * tr.right * vertical, ForceMode2D.Force);

        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate () {
        Vector2 mousePos = Input.mousePosition;

        Vector2 objectPos = Camera.main.WorldToScreenPoint(tr.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
