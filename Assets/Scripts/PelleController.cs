using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelleController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifier si la collision concerne le terrain
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Debug.Log("Contact");
            // Modifier le terrain (baisser le niveau, par exemple)
            ModifyTerrain(hitPoint: collision.contacts[0].point);
        }
    }

    private void ModifyTerrain(Vector3 hitPoint)
    {
        // Trouver le terrain � partir du point de contact
        Terrain terrain = Terrain.activeTerrain;
        Debug.Log("Terrain : " + terrain);

        // Convertir le point de contact en coordonn�es locales du terrain
        Vector3 terrainLocalPos = hitPoint - terrain.transform.position;
        Vector3 normalizedPos = new Vector3(
            terrainLocalPos.x / terrain.terrainData.size.x,
            terrainLocalPos.y / terrain.terrainData.size.y,
            terrainLocalPos.z / terrain.terrainData.size.z
        );

        Debug.Log("Position : " + normalizedPos);

        // Modifier le terrain (baisser le terrain � cet endroit)
        float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        int x = Mathf.FloorToInt(normalizedPos.x * terrain.terrainData.heightmapResolution);
        int y = Mathf.FloorToInt(normalizedPos.z * terrain.terrainData.heightmapResolution);

        // Baisser le terrain
        heights[x, y] -= 0.1f;

        // Appliquer les modifications au terrain
        terrain.terrainData.SetHeights(0, 0, heights);

        //Option moins gourmande en ressources ?
        //terrain.terrainData.SetHeightsDelayLOD(0, 0, heights);
        //terrain.terrainData.SyncHeightmap();
    }
}

