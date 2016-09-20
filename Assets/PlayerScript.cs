using UnityEngine;
using System.Collections;
using UnityEngine.UI;  //its a must to access new UI in script

public class PlayerScript : MonoBehaviour {

    Rigidbody myRigitBody;
    public Text Score_UIText; // assign it from inspector
    public GameObject Fireworks1;
    public GameObject Fireworks2;




    public float speed = 7;
   
    int coinCount = 0;

    Vector3 velocity;


    // Use this for initialization
    void Start() {

        myRigitBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
     
        Vector3 destination = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        velocity = destination.normalized * speed;


    }

    void FixedUpdate() {
        myRigitBody.position += velocity * Time.deltaTime;

    }

    void OnTriggerEnter(Collider target) {

        if (target.tag == "Coin")
        {
            Destroy(target.gameObject);
            int enemyCount = GameObject.FindGameObjectsWithTag("Coin").Length;
            print(enemyCount);
            coinCount++;
            
            if (enemyCount == 1)
            {
                Score_UIText.text = "Completed";
                for (var i = 0; i <= 5; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(-30, 30), 20, Random.Range(-30, 30));
                    Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);
                    
                    if (i % 2 == 0)
                    {
                        Instantiate(Fireworks1, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
                    }
                    else
                    {
                        Instantiate(Fireworks2, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
                    }
                    
                }
            }
            else
            {
                Score_UIText.text = coinCount.ToString();
            }
        }
    }


}
