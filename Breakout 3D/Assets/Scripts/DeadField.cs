using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GM.instance.LoseLife();
        Destroy(other.gameObject);
    }
}
