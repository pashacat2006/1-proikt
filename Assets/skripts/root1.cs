using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root1 : MonoBehaviour
{
    public float horizontalSpeed = 20.0f;
    public bool UnLockScreen = false;
    [SerializeField]
    private Camera root;
    void Update()
    {
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
            float v = horizontalSpeed * Input.GetAxis("Mouse Y");
            root.transform.Rotate(v, 0f, 0f); /*поворот камеры влево/вправо*/
        }
    }
}
