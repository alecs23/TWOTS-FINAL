using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBulbos : MonoBehaviour
{

    List<GameObject> Bulbos = new List<GameObject>();

    public int NumSpawnNadadores = 1; //numero mínimo a generar
    public int NumSpawnVoladores = 1; //numero mínimo a generar
    public int NumSpawnRobustos = 1; //numero mínimo a generar

    public GameObject Nadadores; //objectos (prefabs) a generar
    public GameObject Voladores; //objectos (prefabs) a generar
    public GameObject Robustos; //objectos (prefabs) a generar

    public float RandomRange = 1f; //rango de aparicion

    // Start is called before the first frame update

    void Start()
    {

        // INSTANCIAR LOS BULBOS NADADORES EN EL MAPA DE FORMA ALEATORIA EN UN EMPTY QUE ACTUA DE SPAWNER

        for (var i = 0; i < NumSpawnNadadores; i++) //bucle para generar los objetos
        {
            GameObject padre = GameObject.Find("SpawnerBulbosNAD"); //busca el objeto padre

            float posicionPadreEnX = Random.Range(padre.transform.position.x - RandomRange, padre.transform.position.x + RandomRange); //genera una posicion aleatoria en X
            float posicionPadreEnZ = Random.Range(padre.transform.position.z - RandomRange, padre.transform.position.z + RandomRange); //genera una posicion aleatoria en Z
            float posicionPadreEnY = Random.Range(padre.transform.position.y - RandomRange, padre.transform.position.y + RandomRange); //genera una posicion aleatoria en Y


            GameObject Nadador = Instantiate(Nadadores, new Vector3(posicionPadreEnX, posicionPadreEnY, posicionPadreEnZ), Quaternion.identity); //instancia el objeto
            Nadador.name = "Nadador" + i; //le pone un nombre
            Nadador.transform.parent = GameObject.Find("SpawnerBulbosNAD").transform; //lo pone como hijo del objeto padre
        }


            // LO MISMO PERO PARA VOLADORES

        for (var i = 0; i < NumSpawnVoladores; i++)
        {
            GameObject madre = GameObject.Find("SpawnerBulbosVOL");

            float posicionMadreEnX = Random.Range(madre.transform.position.x - RandomRange, madre.transform.position.x + RandomRange);
            float posicionMadreEnZ = Random.Range(madre.transform.position.z - RandomRange, madre.transform.position.z + RandomRange);
            float posicionMadreEnY = Random.Range(madre.transform.position.y - RandomRange, madre.transform.position.y + RandomRange);


            GameObject Volador = Instantiate(Voladores, new Vector3(posicionMadreEnX, posicionMadreEnY, posicionMadreEnZ), Quaternion.identity);
            Volador.name = "Volador" + i;
            Volador.transform.parent = GameObject.Find("SpawnerBulbosVOL").transform;
        }
        

            // LO MISMO PERO PARA ROBUSTOS

        for (var i = 0; i < NumSpawnRobustos; i++)
        {
            GameObject abuelo = GameObject.Find("SpawnerBulbosROB");

            float posicionAbueloEnX = Random.Range(abuelo.transform.position.x - RandomRange, abuelo.transform.position.x + RandomRange);
            float posicionAbueloEnZ = Random.Range(abuelo.transform.position.z - RandomRange, abuelo.transform.position.z + RandomRange);
            float posicionAbueloEnY = Random.Range(abuelo.transform.position.y - RandomRange, abuelo.transform.position.y + RandomRange);


            GameObject Robusto = Instantiate(Robustos, new Vector3(posicionAbueloEnX, posicionAbueloEnY, posicionAbueloEnZ), Quaternion.identity);
            Robusto.name = "Robusto" + i;
            Robusto.transform.parent = GameObject.Find("SpawnerBulbosROB").transform;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
