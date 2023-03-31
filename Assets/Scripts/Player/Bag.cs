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

    void Start()
    {
        asDoubleJump = false;
        jumpText.text = "0";
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
            jumpText.text = "1";
        }
        else
        {
            jumpText.text = "0";
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
}
