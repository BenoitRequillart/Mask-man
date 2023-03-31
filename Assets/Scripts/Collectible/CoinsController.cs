using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private Bag bag;
    [SerializeField]
    private AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.PlaySound(coinSound);
            bag = collision.GetComponent<Bag>();
            bag.setStageCoin();
            Destroy(gameObject);
        }
    }
}
