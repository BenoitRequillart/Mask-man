using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject content;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(content, spawnPosition, spawnRotation);
            gameObject.SetActive(false);
        }
    }
}
