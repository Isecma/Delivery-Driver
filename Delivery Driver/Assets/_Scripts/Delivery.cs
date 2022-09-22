using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;

    bool hasPackage;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
        }
        
        if (collision.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
