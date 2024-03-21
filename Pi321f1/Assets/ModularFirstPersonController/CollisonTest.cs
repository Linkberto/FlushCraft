using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonTest : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Trees")
        {
            print("stay");
        }
    }
}