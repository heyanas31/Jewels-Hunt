using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    public Animator animator;
    public int totalcoins;
    private bool Allcoinsdone;
    void Start()
    {
        Allcoinsdone = false;
    }
    void FixedUpdate()
    {
        animator.SetBool("CoinsCollected", Allcoinsdone);
        CoinsCollected();
    }
    private void CoinsCollected()
    {
        if (GameManager.coincount == totalcoins)
        {
            Allcoinsdone = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && Allcoinsdone)
        {
            gameObject.SetActive(false);
            AudioManager.instance.Play("YouWin");
            GameManager.isGameWin = true;
        }
    }
}
