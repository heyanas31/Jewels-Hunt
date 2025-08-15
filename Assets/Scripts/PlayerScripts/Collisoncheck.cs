using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisoncheck : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameManager.isGameOver = true;
            AudioManager.instance.Play("Damage");
            AudioManager.instance.Play("YouLose");
            gameObject.SetActive(false);
        }
    }
}
