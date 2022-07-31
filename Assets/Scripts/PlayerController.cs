using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMinimum, xMaximum, yMinimum, yMaximum;

}

public class PlayerController : MonoBehaviour
{
    public Move moveComponent;
    public float speed;
    public Boundary boundary;

    public Transform shootOrigin;
    public GameObject shotPrefab;

    private void Start()
    {
        moveComponent.speed = speed;
        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;
    }

    private void OnHasShoot()
    {
        Instantiate(shotPrefab, shootOrigin, false);
    }

    private void OnDirection(Vector3 direction)
    {
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),transform.position.y, transform.position.z);
        moveComponent.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.position.z);
        //moveComponent.direction = direction;

        //X = 8.5
        //Y = 4.7
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x,y);
    }
}
