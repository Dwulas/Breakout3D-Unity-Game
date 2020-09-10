using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Paddle")
        {
            this.ApplyEffect();
        }
        if (collision.tag == "Paddle" || collision.tag == "Water")
        {
            Destroy(this.gameObject);
        }
    }

    protected abstract void ApplyEffect();
}
