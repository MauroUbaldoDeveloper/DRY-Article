using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{

    float _Speed_X = 5;
    int _HP = 100;

    bool _Right_Movementation;
    bool _Left_Movementation;

    Rigidbody2D _Rdb;

    Vector2 _Right_Vector;
    Vector2 _Left_Vector;

    Health_System_Enemy _Health_System_Enemy_Script;

    // Start is called before the first frame update
    void Start()
    {

        _Right_Movementation = true;

        _Rdb = GetComponent<Rigidbody2D>();
        _Health_System_Enemy_Script = GetComponent<Health_System_Enemy>();

        _Right_Vector = new Vector2(_Speed_X, _Rdb.linearVelocity.y);
        _Left_Vector = new Vector2(-_Speed_X, _Rdb.linearVelocity.y);

    }

    // Update is called once per frame
    void Update()
    {

        if (_Right_Movementation == true)
            _Rdb.linearVelocity = _Right_Vector;
        if (_Left_Movementation == true)
            _Rdb.linearVelocity = _Left_Vector;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Left_Limit"))
        {
            _Right_Movementation = true;
            _Left_Movementation = false;
        }

        if (collision.gameObject.CompareTag("Right_Limit"))
        {
            _Right_Movementation = false;
            _Left_Movementation = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            _Health_System_Enemy_Script.Reduce_HP(15);
        }

    }

}

