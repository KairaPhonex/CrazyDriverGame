using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    float boostTimer = 0f;
    [SerializeField] float speed = 30;
    [SerializeField] float Boostspeed = 50;
    [SerializeField] float brakeSpeed = 15;
    [SerializeField] float rotationSpeed = 80;
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                speed = 30; 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed Up")
        {
            Debug.Log("Boost Activated!");
            speed = Boostspeed;
            Destroy(other.gameObject, 0.2f);
            float boostDuration = 5f;
            boostTimer = boostDuration;

        }
        else if (other.tag == "Brake")
        {
            Debug.Log("Brake Activated!");
            speed = brakeSpeed;
            Destroy(other.gameObject, 0.2f);
            float brakeDuration = 5f;
            boostTimer = brakeDuration;
        }
    }
}
