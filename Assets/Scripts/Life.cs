using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxLifesAmount;
    public int currentLifesAmount;



    // Start is called before the first frame update
    public void Init()
    {

        currentLifesAmount = maxLifesAmount;

    }

    // Update is called once per frame
    public void DamagePlayer()
    {
        currentLifesAmount = Mathf.Clamp(currentLifesAmount - 1, 0, maxLifesAmount);

        if (currentLifesAmount <= 0)
        {
            //End Game 
        }

    }

    public void HealPlayer()
    {
        currentLifesAmount = Mathf.Clamp(currentLifesAmount + 1, 0, maxLifesAmount);
    }
}
