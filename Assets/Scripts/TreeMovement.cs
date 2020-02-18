using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    //orange
    public GameObject orangeprefab;
    public float speed = 1f; //spped that tree moves
    public float leftAndRightEdge = 10f; // distnace where tree turns around
    public float chanceToChangeDirections = 0.02f; //chance tree changes direction
    public float secondsBetweenOrangeDrops = 1f; //rate at which apples will be instantaited

    void Start()
    {
        // Dropping oranges every second
        InvokeRepeating("DropOrange", 2f, secondsBetweenOrangeDrops);
    }

    void DropOrange()
    {
        GameObject orange = Instantiate(orangeprefab) as GameObject;
        orange.transform.position = transform.position;
    }
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //change of direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }

    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change directions
        }
    }


}


