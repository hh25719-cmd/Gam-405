using UnityEngine;
using UnityEngine.SceneManagement;

public class killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);

        }
    }
}
