using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;

    public float shootForce = 700.0f;
    GameSceneManager gameSceneManager;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
        }

        if (Input.touchCount == 2) //&& (Input.GetTouch(1).phase == TouchPhase.Began)
        { 
            gameSceneManager.convertScene();
        }
    }
}
