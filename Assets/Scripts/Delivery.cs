using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [Header("Colors Delivery")]
    [SerializeField] Color32 originalColor;
    [SerializeField] Color32 hasPackageColor;
    [Header("Tags")]
    [SerializeField] string packageTag;
    [SerializeField] string customerTag;
    // [SerializeField] float destroyDelay = 1f;
    private bool havePackage = false;
    private SpriteRenderer spriteRenderer;
    private GameObject[] packages;
    private GameObject[] customers;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Store packages, and customers, then hide them all
        hideAllTags();
    }

    void Start()
    {
        // Show a random package
        showRandom(packages);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

/*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == packageTag && !havePackage)
        {
            Debug.Log("Picked up package.");
            // Picked up package
            havePackage = true;
            Destroy(other.gameObject, destroyDelay);

        } else if (other.tag == customerTag && havePackage) {
            Debug.Log("Dropped off package.");
            // Dropped off the package
            havePackage = false;
            Destroy(other.gameObject, destroyDelay);
        }
    }
*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == packageTag && !havePackage)
        {
            Debug.Log("Picked up package.");

            // Alright, now we have a package
            havePackage = true;

            // Change the color of our car
            spriteRenderer.color = hasPackageColor;

            // Get a random destination and enable
            showRandom(customers);

            // Disable this package location
            other.gameObject.SetActive(false);

        } else if (other.tag == customerTag && havePackage) {
            Debug.Log("Dropped off package.");

            // Dropped off the package
            havePackage = false;

            // Chance the color of our car
            spriteRenderer.color = originalColor;

            // Get a random package and enable
            showRandom(packages);

            // Disable this customer location
            other.gameObject.SetActive(false);
        }
    }

    void hideAllTags()
    {
        // Set up our list of packages and customers
        packages = GameObject.FindGameObjectsWithTag(packageTag);
        customers = GameObject.FindGameObjectsWithTag(customerTag);

        // Now that we have them all, hide them
        GameObject[][] arrays = {packages, customers};
        foreach (GameObject[] arr in arrays)
            foreach (GameObject o in arr)
                o.SetActive(false);
    }

    void showRandom(GameObject[] g)
    {
            g[UnityEngine.Random.Range(0, g.Length)].SetActive(true);
    }
}
