using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{

    public int _Time;

    public GameObject _Enemy_1;
    public GameObject _Enemy_2;

    public bool _Enemy_1_Actived;
    public bool _Enemy_2_Actived;

    // Start is called before the first frame update
    void Start()
    {

        _Enemy_1_Actived = true;

        if (_Enemy_1_Actived == true)
            _Enemy_1.SetActive(true);

        Invoke("Enemy_2", 10);

    }

    void Enemy_1()
    {
        _Enemy_1.SetActive(true);
        _Enemy_2.SetActive(false);
        _Enemy_1_Actived = true;
        _Enemy_2_Actived = false;
        Invoke("Enemy_2", 10);
    }

    void Enemy_2()
    {
        _Enemy_2.SetActive(true);
        _Enemy_1.SetActive(false);
        _Enemy_2_Actived = true;
        _Enemy_1_Actived = false;
        Invoke("Enemy_1", 10);
    }

}