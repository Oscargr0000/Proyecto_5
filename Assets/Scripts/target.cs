using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private float lifetime = 2f;
    public ParticleSystem explosionParticle;

    private GameManager GameManagerScript;

    public int points;
    void Start()
    {
        Destroy(gameObject, lifetime);
        GameManagerScript = FindObjectOfType<GameManager>();
    }


    // Si haces click en la calavera Petas :)
    private void OnMouseDown()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        GameManagerScript.updatescore(points);
        
        Destroy(gameObject);

        if (gameObject.CompareTag("Bad"))
        {
            GameManagerScript.IsGameOver = true;
            GameManagerScript.GameOver();
        }
    }
    
    // Una vez se destrulle el prefab borra su posición de la lista para que se pueda volver a utilizar la posición
    private void OnDestroy()
    {
        GameManagerScript.TargetPositions.Remove(transform.position);
    }

   
}
