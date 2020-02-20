using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Orange : MonoBehaviour
{
    public Text fallenOrange;

    void OnCollisionEnter (Collision coll)
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Ground")
        {
            Destroy(this.gameObject, .3f);

            GameObject missed = GameObject.Find("Rotten");
            fallenOrange = missed.GetComponent<Text>();

            int score = int.Parse(fallenOrange.text);
            score += 1;
            fallenOrange.text = score.ToString();

            if (score > 3)
            {
                SceneManager.LoadScene("Scene_0");
            }

        }
    }

}
