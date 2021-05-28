using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public int row = 20;
    public int col = 20;
    public GameObject floorTile;
    public GameObject ColTile;
    public GameObject BoxTile;
    public GameObject WallTile;
    public GameObject BombUp;


    // Start is called before the first frame update
    void Start()
    {
        //MapaSinCajas = Instantiate(new GameObject(name = "MAPA"), this.transform);
        //CreateMap();
        PonerCajas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PonerCajas()
    {
        for (int x = 2; x < col - 2; x += 2)
        {
            for (int z = 2; z < row - 2; z += 2)
            {
                if (PonerCaja())
                {
                    Instantiate(BoxTile, new Vector3(x, 0.5f, z), BoxTile.transform.rotation);
                    //Meter power ups en la misma posición.
                    Instantiate(BombUp, new Vector3(x, 1f, z - 1), BombUp.transform.rotation);
                }
            }
        }
    }
    void CreateMap()
    {
        for(int x = -1; x <= col; x++)
        {
            for(int z = 0; z <= row; z++)
            {
                Instantiate(floorTile, new Vector3(x, 0f, z), floorTile.transform.rotation);
            }
        }

        foreach(int z in new int[] { -1, row })
        {
            for(int x = 0; x < col; x+=1)
            {
                if (z ==-1)
                {
                    Instantiate(WallTile, new Vector3(x, 0f, z), Quaternion.AngleAxis(WallTile.transform.rotation.eulerAngles.y - 180, new Vector3(0, 1, 0)));
                }
                else
                {
                    Instantiate(WallTile, new Vector3(x, 0f, z), WallTile.transform.rotation);
                }
                
            }
        }

        foreach(int x in new int[] { -1, col})
        {
            for(int z = 0; z < row; z += 1)
            {
                if (x == -1)
                {
                    Instantiate(WallTile, new Vector3(x, 0f, z), Quaternion.AngleAxis(WallTile.transform.rotation.eulerAngles.y - 90, new Vector3(0, 1, 0)));
                }
                else
                {
                    Instantiate(WallTile, new Vector3(x, 0f, z), Quaternion.AngleAxis(WallTile.transform.rotation.eulerAngles.y+90, new Vector3(0,1,0)));
                }
                
            }
        }

        for(int x = 1; x < col-1; x+=2)
        {
            for(int z = 1; z < row-1; z += 2)
            {
                Instantiate(ColTile, new Vector3(x, 0f, z), ColTile.transform.rotation);

            }
        }

        

        // -------------------------- ESQUINAS / COLUMNAS --------------------------

        Instantiate(ColTile, new Vector3(col-0.25f, 0f, row-0.25f), ColTile.transform.rotation); //Columna esquina superior derecha
        Instantiate(ColTile, new Vector3(-0.75f, 0f, row - 0.25f), ColTile.transform.rotation); //Columna esquina superior izquierda
        Instantiate(ColTile, new Vector3(-0.75f, 0f, -0.75f), ColTile.transform.rotation); //Columna esquina inferior izquierda
        Instantiate(ColTile, new Vector3(col - 0.25f, 0f, -0.75f), ColTile.transform.rotation); //Columna esquina derecha inferior


    }

    bool PonerCaja()
    {
        return Random.Range(0, 3) > 0;
    }
}
