using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{

    float _Speed_X = 5;
    float _Speed_Y = 5;
    float _Time;

    int _HP = 100;

    bool _Right_Movementation;
    bool _Left_Movementation;
    bool _Up_Movementation;
    bool _Down_Movementation;

    Rigidbody2D _Rdb;

    Vector2 _Right_Up_Diagonal;
    Vector2 _Right_Down_Diagonal;

    Vector2 _Left_Up_Diagonal;
    Vector2 _Left_Down_Diagonal;

    Health_System_Enemy _Health_System_Enemy_Script;

    // Start is called before the first frame update
    void Start()
    {

        _Left_Movementation = true;
        _Up_Movementation = true;

        _Rdb = GetComponent<Rigidbody2D>();
        _Health_System_Enemy_Script = GetComponent<Health_System_Enemy>();

        _Right_Up_Diagonal = new Vector2(_Speed_X, _Speed_Y);
        _Right_Down_Diagonal = new Vector2(_Speed_X, -_Speed_Y);

        _Left_Up_Diagonal = new Vector2(-_Speed_X, _Speed_Y);
        _Left_Down_Diagonal = new Vector2(-_Speed_X, -_Speed_Y);

    }

    // Update is called once per frame
    void Update()
    {

        if (_Right_Movementation == true && _Up_Movementation == true)
            _Rdb.linearVelocity = _Right_Up_Diagonal;

        if (_Right_Movementation == true && _Down_Movementation == true)
            _Rdb.linearVelocity = _Right_Down_Diagonal;

        if (_Left_Movementation == true && _Up_Movementation == true)
            _Rdb.linearVelocity = _Left_Up_Diagonal;

        if (_Left_Movementation == true && _Down_Movementation == true)
            _Rdb.linearVelocity = _Left_Down_Diagonal;

        _Time += Time.deltaTime;

        if (_Time > 5)
        {
            _Time = 0;

            if (_Up_Movementation == true)
            {
                Change_For_Down_Movementation();
            }

            if (_Down_Movementation == true)
            {
                Change_For_Up_Movementation();
            }

            if (_Left_Movementation == true)
            {
                Change_For_Right_Movementation();
            }

            if (_Right_Movementation == true)
            {
                Change_For_Left_Movementation();
            }

        }

    }

    void Change_For_Up_Movementation()
    {
        _Up_Movementation = true;
        _Down_Movementation = false;
    }

    void Change_For_Down_Movementation()
    {
        _Up_Movementation = false;
        _Down_Movementation = true;
    }

    void Change_For_Left_Movementation()
    {
        _Left_Movementation = true;
        _Right_Movementation = false;
    }

    void Change_For_Right_Movementation()
    {
        _Left_Movementation = false;
        _Right_Movementation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Left_Limit"))
        {
            Change_For_Right_Movementation();
        }

        if (collision.gameObject.CompareTag("Right_Limit"))
        {
            Change_For_Left_Movementation();
        }

        if (collision.gameObject.CompareTag("Up_Limit"))
        {
            Change_For_Down_Movementation();
        }

        if (collision.gameObject.CompareTag("Down_Limit"))
        {
            Change_For_Up_Movementation();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            _Health_System_Enemy_Script.Reduce_HP(15);
        }

    }

}