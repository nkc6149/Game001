using UnityEngine;

public class hakopakopako : MonoBehaviour
{
    public GameObject squarePrefab; 

    public float lifetime = 3f; 

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; 
            GameObject square = Instantiate(squarePrefab, clickPosition, Quaternion.identity);

            Destroy(square, lifetime);
        }
    }
}

