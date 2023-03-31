using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpCollectible : MonoBehaviour
{
    private Bag bag;
    [SerializeField]
    private AudioClip jumpSound;

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
        if(collision.tag == "Player")
        {
            AudioManager.instance.PlaySound(jumpSound);
            bag = collision.GetComponent<Bag>();
            bag.setDoubleJump(true);
            gameObject.SetActive(false);
        }
    }
}
