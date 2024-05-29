using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockManager : MonoBehaviour
{
    private static MouseLockManager _instance;
    public static MouseLockManager Instance => _instance;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
