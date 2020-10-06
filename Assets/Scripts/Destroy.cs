using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{   

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private GameObject myPlat;
    public GameObject moedaPrefab;
    public GameObject cloud1Prefab;
    public GameObject cloud2Prefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if(Random.Range(1,7) == 1)
            {
                Destroy(collision.gameObject);                
                Instantiate(springPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))) , Quaternion.identity);
                
            } 
            else 
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));
            }

            if (Random.Range(1,7) == 2)
            {
                Instantiate(moedaPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (7 + Random.Range(0.2f, 1.0f))) , Quaternion.identity);
            }

            if (Random.Range(1,7) == 1)
            {
                Instantiate(cloud1Prefab, new Vector3(Random.Range(-13f, 13f), player.transform.position.y + (20 + Random.Range(0.4f, 0.9f)),9f) , Quaternion.identity);
            }

            if (Random.Range(1,7) == 1)
            {
                Instantiate(cloud2Prefab, new Vector3(Random.Range(-13f, 13f), player.transform.position.y + (20 + Random.Range(0.6f, 0.7f)), 9f) , Quaternion.identity);
            }
        } else if(collision.gameObject.name.StartsWith("Spring"))
        {
            if(Random.Range(1,7) == 1)
            {   
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));                
            } else 
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))) , Quaternion.identity);
            }
        }

    }
    
}
