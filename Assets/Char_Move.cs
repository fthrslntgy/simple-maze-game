using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Char_Move : MonoBehaviour
{
    public float velocity = 100;
    public float jump_force = 5;
    public Rigidbody rb;
    public bool girdi = false;
    public bool bitti = false;
    public float timeToDisplay = 0.0f;
    public GameObject Timer;
    private TextMeshProUGUI testMesh;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        GameObject Timer = GameObject.Find("Timer");
        testMesh = Timer.GetComponent<TextMeshProUGUI>();
        DisplayTime();
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        testMesh.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {   
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(xMove, 0, zMove) * velocity;
        rb.velocity = move;

        if(Input.GetKey(KeyCode.Space) && rb.position.y < 6)
             rb.AddForce(Vector3.up * jump_force*2, ForceMode.Impulse);

        else if (rb.position.y > 1.5){
            rb.AddForce(Vector3.down * jump_force, ForceMode.Impulse);
        }

        if(!girdi){
            if(rb.position.x > -44 && rb.position.x < -5 && rb.position.z > -77 && rb.position.z < -73){
                Debug.Log("girdi");
                girdi = true;
            }
        }

        else if(girdi){
            if(rb.position.x > 18 && rb.position.x < 46 && rb.position.z > 80 && rb.position.z < 85){
                Debug.Log("cikti");
                girdi = false;
                bitti = true;
            }
        }
        
        if (girdi && !bitti){
            timeToDisplay += Time.deltaTime;
            DisplayTime();
        }
        
    }
}
