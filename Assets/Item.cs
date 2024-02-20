using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3f, 6f);
        if (GameObject.Find("monkey").GetComponent<PlayerController>() != null)
        {
            controller = GameObject.Find("monkey").GetComponent<PlayerController>();
            if (controller.anduocvatpham)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y <= -5f) Destroy(gameObject);    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
