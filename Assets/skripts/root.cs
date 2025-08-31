using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root : MonoBehaviour
{
    public float horizontalSpeed = 20.0f;
    public bool UnLockScreen = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            UnLockScreen = !UnLockScreen; /*отвечает за показ/скрытие курсора*/
        }

        if (UnLockScreen == false)
        {
            Cursor.lockState = CursorLockMode.Confined; /*курсор может двигаться в пределах окна*/
            Cursor.lockState = CursorLockMode.Locked; /*блокируем курсор в центре экрана*/
            Cursor.visible = false; /*устанавливаем прозрачность курсора на "нет"*/
   }
        else
        {
            Cursor.lockState = CursorLockMode.None; /*разблокировка курсора*/
            Cursor.visible = true; /*прозрачность курсора на "да"*/
        }
        if (UnLockScreen == false)
        {
            float v = horizontalSpeed * Input.GetAxis("Mouse X");
            gameObject.transform.Rotate(0f, v, 0f); /*поворот камеры влево/вправо*/
        }
    }
}
