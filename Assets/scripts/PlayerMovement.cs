using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Key")
        {
            haveKey = true;
            Destroy(other.gameObject);
            OrangeText.SetActive(false);
        }
        if (other.gameObject.name == "OrangeNpc")
        {
            OrangeText.SetActive(true);
        }
        if (other.gameObject.name == "OrangeNpc" && haveKey == true)
        {
            OrangeText2.SetActive(true);
        }
        if (other.gameObject.name == "Door" && haveKey == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "BlueNpc" && haveKey == true)
        {
            BlueText.SetActive(true);
        } 
    }
}
