using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private bool is_move_left;
    private bool is_move_right;
    private float speed_move;

    // Start is called before the first frame update
    void Start()
    {
        is_move_left = false;
        is_move_right = false;
        speed_move = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // перемещаем камеру влево
        if(is_move_left)         
        {
            this.transform.position -= new Vector3(speed_move * Time.deltaTime, 0.0f, 0.0f);

            // проверяем ограничение команты слева
            if(this.transform.position.x < -20.75f) 
            {
                this.transform.position = new Vector3(-20.75f, this.transform.position.y, this.transform.position.z);
            }
        }

        // перемещаем камеру вправо
        if(is_move_right)         
        {
            this.transform.position += new Vector3(speed_move * Time.deltaTime, 0.0f, 0.0f);

            // проверяем ограничение команты справа
            if(this.transform.position.x > 20.75f) 
            {
                this.transform.position = new Vector3(20.75f, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    // запуск перемещения
    public void LeftButtonDown()
    {
        is_move_left = true;
    }

    // остановка перемещения
    public void LeftButtonUp()
    {
        is_move_left = false;
    }

    // запуск перемещения
    public void RightButtonDown()
    {
        is_move_right = true;
    }

    // остановка перемещения
    public void RightButtonUp()
    {
        is_move_right = false;
    }
}
