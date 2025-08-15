using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.coincount++;
            Destroy(gameObject);
            AudioManager.instance.Play("Coin");
        }
    }
}
