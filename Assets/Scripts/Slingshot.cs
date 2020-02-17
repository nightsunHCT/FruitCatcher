using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabBasket;
    public float velocityMult = 2f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject basket;
    public bool aimingMode;

    private Rigidbody basketRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        // print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        // print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        // player pressed left click while over Slingshot
        aimingMode = true;
        // instantiate a basket projectile
        basket = Instantiate(prefabBasket) as GameObject;
        // start at launch point
        basket.transform.position = launchPos;
        // set it to isKinematic
        basketRigidbody = basket.GetComponent<Rigidbody>();
        basketRigidbody.isKinematic = true;

    }

    void Update()
    {
        if (!aimingMode) return;

        // get mouse position
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;
        // limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        // move the basket to this new position
        Vector3 basketPos = launchPos + mouseDelta;
        basket.transform.position = basketPos;

        if (Input.GetMouseButtonUp(0))
        {
            // the Mouse has been released
            aimingMode = false;
            basketRigidbody.isKinematic = false;
            basketRigidbody.velocity = -mouseDelta * velocityMult;
            basket = null;
        }
    }
}
