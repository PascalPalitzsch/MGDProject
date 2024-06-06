using System.Collections;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    private Collider2D trapCollider;
    private Renderer trapRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trapCollider = GetComponent<Collider2D>();
        trapRenderer = GetComponent<Renderer>();
    }

    private IEnumerator MakeTrapPassable(GameObject player)
    {
        // 3 Sekunden warten
        yield return new WaitForSeconds(3f);

        // Falle unsichtbar und nicht kollidierbar machen
        trapCollider.enabled = false;
        trapRenderer.enabled = false;

        // Den Spieler herunterfallen lassen
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -Mathf.Abs(playerRigidbody.velocity.y));
        }

        // 5 Sekunden warten
        yield return new WaitForSeconds(3f);

        // Falle wieder sichtbar und kollidierbar machen
        trapRenderer.enabled = true;
        trapCollider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MakeTrapPassable(collision.gameObject));
        }
    }
}
