using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickParticle;
    public AudioSource dzwiek;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        dzwiek.Play();
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<BoxCollider>());
        Destroy(gameObject);
    }
}
