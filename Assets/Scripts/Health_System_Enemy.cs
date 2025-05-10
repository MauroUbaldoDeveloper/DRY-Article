using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemy : MonoBehaviour
{

    int _HP = 100;

    //This method is used in Enemy_1 Class, and also Enemy_2 Class

    public void Reduce_HP(int Damage)
    {

        _HP -= Damage;
        if (_HP <= 0)
            print("Die");

    }

}