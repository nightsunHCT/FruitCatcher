using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public static float bottomY = -8f;
    public Text scoreGT;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject, .5f);
        }
    }

    void OnCollisionEnter (Collision coll)
    {
        // find what hit the basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Orange")
        {
            Destroy(collideWith);

            GameObject scoreGo = GameObject.Find("Score");
            scoreGT = scoreGo.GetComponent<Text>();

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }       

        

    }
    

   
       


}
