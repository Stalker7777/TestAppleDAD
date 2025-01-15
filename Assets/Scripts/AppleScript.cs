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
        // �������� ������� ���������� �������
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
        // ���� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ������ ���������� �� �������
            if(IsCursorInApple())
            {
                // ������ ������� ���������� �������
                this.transform.position = new Vector3 (diference.x, diference.y, this.transform.position.z);
                // ��������� �����������
                is_mouse_left_button_down = true;
            }
        }

        // ���� �������� ����� ������ ����
        if (Input.GetMouseButtonUp(0))
        {
            if(is_mouse_left_button_down)
            {
                // ������ ���������� � �������� ��� ���
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

        // ���� �������� ����������� �������� ������� ���������� �������
        if(is_mouse_left_button_down) 
        {
            this.transform.position = new Vector3 (diference.x, diference.y, this.transform.position.z);
        }

    }

    // ���� � �������
    void OnTriggerEnter2D(Collider2D collider)
    {
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;

        is_apple_trigger_enter = true;
    }

    // ����� �� ��������
    void OnTriggerExit2D(Collider2D collider)
    {
        is_apple_trigger_enter = false;
    }

    // ���������� ���������� �� ������ �� �������
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
