using UnityEngine;
using System.Collections;

public class ObstacleCode : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;

    public Transform player;
    public float destroy_time;
    public float between_space;
    public float instantiate_speed;
    private void Start()
    {
        InvokeRepeating("nesne_klonla", 0, instantiate_speed);
    }


    void nesne_klonla()
    {
        int rastsayi = Random.Range(0, 9);

        if (rastsayi >= 0 && rastsayi < 5)
        {
            StartCoroutine(klonla(obstacle1));
        }
        if (rastsayi >=5 && rastsayi < 10)
        {
            StartCoroutine(klonla(obstacle2));
        }
        

    }

    IEnumerator klonla (GameObject nesne)
    {
        GameObject yeni_klon = Instantiate(nesne);

        yeni_klon.transform.position = new Vector2(0, player.position.y + between_space);
        yield return new WaitForSeconds(destroy_time);
        yeni_klon.SetActive(false);
        
    }
}
