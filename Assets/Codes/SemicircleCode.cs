using UnityEngine;

public class SemicircleCode : MonoBehaviour
{

    public Transform semicircle_1;
    public Transform semicircle_2;
    public Transform semicircles;
    public Transform main_camera;

    public float speed;
    public bool canMove;
    
    Vector3 camera_distance;
    

    private void Start()
    {
        canMove = true;
        camera_distance = main_camera.transform.position - transform.position;
        main_camera.transform.position = transform.position + camera_distance;
    }



    private void LateUpdate()
    {
        main_camera.transform.position = Vector3.Lerp(main_camera.transform.position,
                new Vector3(0, semicircles.transform.position.y, main_camera.transform.position.z), 0.1f);
    }
    void Update()
    {
        if (canMove)
        {
            if (Input.GetButton("Fire1"))
            {
                semicircle_1.position = new Vector2(-1.5f, semicircle_1.position.y);
                semicircle_2.position = new Vector2(1.5f, semicircle_2.position.y);
                semicircles.position = new Vector2(0f, semicircles.position.y + speed);
            }
            else
            {
                semicircle_1.position = new Vector2(-0.5f, semicircle_1.position.y);
                semicircle_2.position = new Vector2(0.5f, semicircle_2.position.y);
                semicircles.position = new Vector2(0f, semicircles.position.y + speed);
            }
            
        }
        
    }

    
}
