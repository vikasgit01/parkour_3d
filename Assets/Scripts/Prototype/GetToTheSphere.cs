using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToTheSphere : MonoBehaviour
{
    [SerializeField] GameObject win;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere") win.SetActive(true);
    }
}
