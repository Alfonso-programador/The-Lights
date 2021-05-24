﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangulito : MonoBehaviour
{
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        Destroy(gameObject);
    }
}
