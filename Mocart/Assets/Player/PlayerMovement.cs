using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool frozen = false;
    float speed = 1.33f;
    private void Update()
    {
        if (frozen)
            return;

        Movement();
    }
    void Movement()
    {
        float movement = Input.GetAxisRaw("Horizontal");

        if (transform.position.x > 3.5f && movement > 0 || transform.position.x < -3.5f && movement < 0)
            return;

        transform.Translate(movement * speed * Time.deltaTime, 0, 0);
    }
    public void Freeze() //"UpdateShopButton" button in Hierarchy
    {
        frozen = true;
    }
    public void UnFreeze() //"Back" button in Hierarchy
    {
        frozen = false;
    }
}
