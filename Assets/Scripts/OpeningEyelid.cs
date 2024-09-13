using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningEyelid : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode toTitleKey = KeyCode.Space;
    [SerializeField] private string sceneToLoad;

    private bool isMoving = false;
    void Start()
    {
        isMoving = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(toTitleKey))
        {
            SceneManager.LoadScene(sceneToLoad);
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
            
        }
    }
}
