using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float startDelay = 1.0f;
    public float spawnInterval = 4.0f;
    private bool canCreateDogs;

    private void Awake()
    {
        canCreateDogs = false;
    }

    private void Start()
    {
        InvokeRepeating("AllowCreateDogs", startDelay, spawnInterval);
    }

    private void AllowCreateDogs()
    {
        canCreateDogs = !canCreateDogs;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canCreateDogs)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            AllowCreateDogs();
        }
    }
}
