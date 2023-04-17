using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropBehavior : MonoBehaviour
{
    public int healValue = 100;

    public float rotationAmount = 30f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, rotationAmount * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeHealth(healValue);
            Destroy(gameObject);
        }
    }
}
