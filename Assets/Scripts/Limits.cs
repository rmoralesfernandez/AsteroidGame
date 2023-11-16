using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{

    private WorldLimits worldLimits;
    // Start is called before the first frame update
    void Start()
    {
        worldLimits = GameController.instance.GetWorldLimits();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float x = transform.position.x;
        float y = transform.position.y;

        if(x > worldLimits.rightL)
        {
            pos.x = worldLimits.leftL;
            transform.position = pos;
        }

        if(x < worldLimits.leftL)
        {
            pos.x = worldLimits.rightL;
            transform.position = pos;
        }

        if(y < worldLimits.inferiorL)
        {
            pos.y = worldLimits.superiorL;
            transform.position = pos;
        }

        if(y > worldLimits.superiorL)
        {
            pos.y = worldLimits.inferiorL;
            transform.position = pos;
        }
    }
}
