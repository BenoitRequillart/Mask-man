using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bag : MonoBehaviour
{
    private bool asDoubleJump;
    [SerializeField]
    private TextMeshProUGUI jumpText;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    private int stageCoin;
    [SerializeField]
    private TextMeshProUGUI doubleJumpText;

    void Start()
    {
        asDoubleJump = false;
        jumpText.text = "Pas de double saut";
        stageCoin = 0;
        coinsText.text = stageCoin.ToString() + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDoubleJump(bool state)
    {
        asDoubleJump = state;

        if (state)
        {
            jumpText.text = "Double Saut Dispo";
            
            StartCoroutine(PauseCoroutine());
            
        }
        else
        {
            jumpText.text = "Pas de double saut";
        }
    }
    public bool getDoubleJump()
    {
        if (asDoubleJump)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void setStageCoin()
    {
        if(stageCoin < 10)
        {
            stageCoin += 1;
            coinsText.text = stageCoin.ToString()+"/10";
        }
    }
    public int getAnimals()
    {
        return stageCoin;
    }
    IEnumerator PauseCoroutine()
    {
        doubleJumpText.text = "Vous avez recup le double saut";

        yield return new WaitForSeconds(1);

        doubleJumpText.text = "";
    }
}

