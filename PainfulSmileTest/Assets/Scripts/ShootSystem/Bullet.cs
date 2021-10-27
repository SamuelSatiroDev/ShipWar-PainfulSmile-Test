using UnityEngine;

public sealed class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeedMove = 0.0f;


    private void Update()
    {
        this.transform.position += this.transform.up * this.bulletSpeedMove * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.ObstableTag))
            this.gameObject.SetActive(false);
    }
}