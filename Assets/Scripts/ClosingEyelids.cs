using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ClosingEyelids : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode moveKey = KeyCode.Space;
    [SerializeField] private string sceneToLoad;

    private bool isMoving = false; 

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(moveKey))
        {
            isMoving = true;
        }


        if (!isMoving) return;
        
        MoveTowardsTarget();
        
    }

    void MoveTowardsTarget()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            isMoving = false;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    
}
