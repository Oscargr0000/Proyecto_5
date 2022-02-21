using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] targertPrefabs;
    public bool IsGameOver;
    public List<Vector3> TargetPositions;

    private float minX = -3.75f;
    private float miny = -3.75f;
    private float disntaceBetweemSaquare = 2.5f;

    private float spawnRate = 2f;
    private Vector3 randomPos;


    public TextMeshProUGUI pointsText;

    private int score = 0;

    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomTarget());
        pointsText.text = $"Score:{score}";
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {

    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltarX = Random.Range(0, 4);
        int SaltarY = Random.Range(0, 4);

        float spawnPos = minX + SaltarX + disntaceBetweemSaquare;
        float spawnPosY = miny + SaltarY + disntaceBetweemSaquare;

        return new Vector3(spawnPos, spawnPosY, 0);

    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!IsGameOver) //Mientras que estas vivo -->
        {

            yield return new WaitForSeconds(spawnRate); // Ejecutar este comando cada 2 segundos.


            int randomIndex = Random.Range(0, targertPrefabs.Length);
            randomPos = RandomSpawnPosition();


            //Comprueba que la posicion en la que quiere spawnear esta siendo utilizada o no.   Si se esta utilizando genera una nueva posición aleatoria.  Traducción del codigo = Mientras la posición de spawn esta en la lista --> Generar nueva posición
            while (TargetPositions.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            //Instancia el prefab.
            Instantiate(targertPrefabs[randomIndex], randomPos, targertPrefabs[randomIndex].transform.rotation);

            //Añade la posición donde se ha instanciado a la lista.
            TargetPositions.Add(randomPos);
        }
    }

    public void updatescore (int pointsadd)
    {
        score += pointsadd;
        pointsText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
}
