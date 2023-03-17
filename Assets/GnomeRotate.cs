using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(-90, 270, -90));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
