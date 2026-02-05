using UnityEngine;

public class Delivery : MonoBehaviour
{
    public bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    [SerializeField] float packagedelay = 0.5f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected with Ozan and " + other.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("You Picked the Package" + other.gameObject.name);
            hasPackage = true;
            Destroy(other.gameObject, packagedelay);
            spriteRenderer.color = hasPackageColor;
            
        }
        else if (other.tag == "Deliver Spot")
        {
            Debug.Log("You Delivered the Package to " + other.gameObject.name);
            if (hasPackage)
            {
                Debug.Log("Package Delivered Successfully!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("No Package to Deliver!");
            }
        }
    }
}
