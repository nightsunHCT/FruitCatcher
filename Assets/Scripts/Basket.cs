using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text scoreGt;

    void Start()
    {
        GameObject scoreGo = GameObject.Find("Score");
        scoreGt = scoreGo.GetComponent<Text>();
        scoreGt.text = "0";
    }
    void OnCollisionEnter (Collision coll)
    {
        // find what hit the basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Orange")
        {
            Destroy(collideWith);

        }
        int score = int.Parse(scoreGt.text);
        score += 1;
        scoreGt.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }

    }
    

   
       


}
