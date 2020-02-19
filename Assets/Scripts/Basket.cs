using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public static float bottomY = -8f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject, 1f);
        }
    }

    void OnCollisionEnter (Collision coll)
    {
        // find what hit the basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Orange")
        {
            Destroy(collideWith);
        }
    }

}
