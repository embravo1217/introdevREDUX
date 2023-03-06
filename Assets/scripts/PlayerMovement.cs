using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    public bool haveKey = false;
    public GameObject OrangeText;
    public GameObject OrangeText2;
    public GameObject BlueText;

    // Start is called before the first frame update
    void Start()
    {
        OrangeText.SetActive(false);
        OrangeText2.SetActive(false);
        BlueText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;
        }

        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Key")
        {
            haveKey = true;
            Destroy(other.gameObject);
            OrangeText.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "OrangeNpc" && haveKey == false && Input.GetKey(KeyCode.Space))
        {
            OrangeText.SetActive(true);
        }
        if (other.gameObject.name == "OrangeNpc" && haveKey == true && Input.GetKey(KeyCode.Space))
        {
            OrangeText.SetActive(false);
            OrangeText2.SetActive(true);
        }
        if (other.gameObject.name == "Door" && haveKey == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "BlueNpc" && haveKey == true && Input.GetKey(KeyCode.Space))
        {
            BlueText.SetActive(true);
        }

        if (other.gameObject.name == "exit")
        {
            SceneManager.LoadScene(0);
        }
    }
}
