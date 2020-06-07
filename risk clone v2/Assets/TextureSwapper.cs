using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwapper : MonoBehaviour
{
   
    public List<GameObject> textureObjects;
    public GameObject goWon, goLost;
    public GameObject gameManager,explosion;
    public Material materialOfTile;
    public Material[] materials;

   
    // Start is called before the first frame update
    void Start()
    {
        Tile[] components = GameObject.FindObjectsOfType<Tile>();
        foreach (Tile comp in components)
            textureObjects.Add(comp.gameObject);

        for (int e = 0; e < materials.Length; e++)
        {
            
            if (textureObjects[e].GetComponent<Tile>().nationName == "China")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[0];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Sweden")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[1];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Switzerland")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[2];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Italy")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[3];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Papua New Ginea")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[4];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Jamaika")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[5];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Usa")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[6];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Albania")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[7];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Germany")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[8];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Canada")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[9];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Azerbaijan")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[10];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Egypt")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[11];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "France")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[12];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Portugese")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[13];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Crotia")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[14];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "England")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[15];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Iran")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[16];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Japan")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[17];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Qatar")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[18];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Mexico")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[19];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Argentina")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[20];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Pakistan")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[21];
            }
            
            if (textureObjects[e].GetComponent<Tile>().nationName == "Kazakhistan")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[22];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "England_2")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[23];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Ukraine")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[24];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Seychelles")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[25];
            }
            if (textureObjects[e].GetComponent<Tile>().nationName == "Spain")
            {
                textureObjects[e].GetComponent<TextureSwapper>().materialOfTile = materials[26];
            }

        }

    
       
    }


    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.GetComponent<GameManager>().textureSwap && gameManager.GetComponent<GameManager>().winCondition==1)
        {
            for(int a = 0; a < textureObjects.Count; a++)
            {
                if (textureObjects[a].GetComponent<Tile>().tileId == gameManager.GetComponent<GameManager>().playerChosenTileId)
                {
                    goLost = textureObjects[a];
                   
                }
                if (textureObjects[a].GetComponent<Tile>().tileId == gameManager.GetComponent<GameManager>().friendlyTileId)
                {
                    goWon = textureObjects[a];
                    
                }

            }
            for (int d = 0; d < materials.Length; d++)
            {
               
                if (goWon.GetComponent<MeshRenderer>().sharedMaterial.name==materials[d].name  )
                {
                Debug.Log("TEXTURE CHANGE WIN");
                   

                    goLost.GetComponent<MeshRenderer>().sharedMaterial = materials[d];
                    StartCoroutine(MyCoroutine());
                   


                }
            }
        }
        if(gameManager.GetComponent<GameManager>().textureSwap && gameManager.GetComponent<GameManager>().winCondition == 0)
        {
            for (int z = 0; z <textureObjects.Count; z++)
            {
                if (textureObjects[z].GetComponent<Tile>().tileId == gameManager.GetComponent<GameManager>().playerChosenTileId)
                {
                    goWon = textureObjects[z];
                    
                }
                if (textureObjects[z].GetComponent<Tile>().tileId == gameManager.GetComponent<GameManager>().friendlyTileId)
                {
                    goLost = textureObjects[z];
                   
                }

            }
            for(int c=0; c < materials.Length; c++)
            {   

                if (goWon.GetComponent<MeshRenderer>().sharedMaterial.name == materials[c].name)
                {
                    Debug.Log("TEXTURE CHANGE LOSE");
                    goLost.GetComponent<MeshRenderer>().sharedMaterial=materials[c];
                    StartCoroutine(MyCoroutine());

                }
            }
        }
    }
    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        explosion.transform.position = new Vector3(goLost.transform.position.x, goLost.transform.position.y,  - 10);

        yield return new WaitForSeconds(1);    //Wait one frame
        explosion.transform.position = new Vector3(goLost.transform.position.x, goLost.transform.position.y,  +10);

    }
}
