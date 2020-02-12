// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
 
// public class CharacterController : MonoBehaviour
// {
//     public float speed = 20.0f;
//     public float rotationSpeed = 70;
//     public float force = 700f;
//     public GameObject cannon;
//     public GameObject bullet;
 
//     Rigidbody rb;
//     Transform t;
 
//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         t = GetComponent<Transform>();
//     }
 
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKey(KeyCode.W))
//             rb.velocity += this.transform.forward * speed * Time.deltaTime;
//         else if (Input.GetKey(KeyCode.S))
//             rb.velocity -= this.transform.forward * speed * Time.deltaTime;
 
//         if (Input.GetKey(KeyCode.D))
//             t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
//         else if (Input.GetKey(KeyCode.A))
//             t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);
       
//         if (Input.GetKeyDown(KeyCode.Space))
//             rb.AddForce(t.up * force);
 
//         if (Input.GetButtonDown("Fire1")){
//             GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
//             newBullet.GetComponent<Rigidbody>().velocity += Vector3.up *0.5f;
//             newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 15000);
//         }
//     }
// }