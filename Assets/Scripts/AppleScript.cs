using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private bool is_mouse_left_button_down;
    private bool is_apple_trigger_enter;

    // Start is called before the first frame update
    void Start()
    {
        is_mouse_left_button_down = false;
        is_apple_trigger_enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        // получить мировые координаты курсора
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
        // если зажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // если курсор находиться на объекте
            if(IsCursorInApple())
            {
                // задаем объекту координаты курсора
                this.transform.position = new Vector3 (diference.x, diference.y, this.transform.position.z);
                // запускаем перемещение
                is_mouse_left_button_down = true;
            }
        }

        // если отпущена левая кнопка мыши
        if (Input.GetMouseButtonUp(0))
        {
            if(is_mouse_left_button_down)
            {
                // объект находиться в триггере или вне
                if(is_apple_trigger_enter) 
                {
                    this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                }
                else
                {
                    this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                }
            }

            is_mouse_left_button_down = false;
        }

        // если запущено перемещение присваем объекту координаты курсора
        if(is_mouse_left_button_down) 
        {
            this.transform.position = new Vector3 (diference.x, diference.y, this.transform.position.z);
        }

    }

    // вход в триггер
    void OnTriggerEnter2D(Collider2D collider)
    {
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;

        is_apple_trigger_enter = true;
    }

    // выход из триггера
    void OnTriggerExit2D(Collider2D collider)
    {
        is_apple_trigger_enter = false;
    }

    // определяем находиться ли курсор на объекте
    private bool IsCursorInApple()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(
            diference.x > this.transform.position.x - 0.64f && diference.x < this.transform.position.x + 0.64f &&
            diference.y > this.transform.position.y - 0.64f && diference.y < this.transform.position.y + 0.64f
        ) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
