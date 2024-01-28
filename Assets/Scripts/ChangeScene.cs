using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool change;
    float timer = 3f;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (change)
        {
            if (timer > 0)
            {
                timer = -Time.deltaTime;
            } else { SceneChange("Menu"); }
        }
    }

    public void SceneChange(string next)
    {
        SceneManager.LoadScene(next);
    }
}
