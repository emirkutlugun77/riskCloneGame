using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text PlayerTurn;
    private bool gameWinner = false;
    public Shader shader,shader1;
    public bool shaderCheck=false;
    public bool lightCheck=false,textureSwap=false,panelOpener=true;
    public int columnCount,winCondition;//6 ya 6
    public int turn =0,battleCounter=2 ;
    public Player[] player;
    public int playerChosenTileId;
    public int playerId;
    public int random;
    public Material[] gameMaterials;
    public int chosenPlayerCount;
    public int friendlyTileId,idCounter=0;
    public GameObject mouseObject;
    public List<GameObject> nearEnemies;
    public Text  playerText;
 
    private void Start()
    {

        for (int i = 0; i <player.Length; i++)
        {
            Debug.Log("Player" + player[i].playerId + " joined" + "with id " + player[i].playerId +"\n");
           
        }

        
       
        Tile[] components = GameObject.FindObjectsOfType<Tile>();
        foreach (Tile comp in components)
            nearEnemies.Add(comp.gameObject);
        for (int t = 0; t < nearEnemies.Count; t++)
        {
            
                nearEnemies[t].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.0f);
            nearEnemies[t].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_OutlineColor", Color.white);
           




        }
        for (int o = 0; o < nearEnemies.Count; o++)
        {
            if (nearEnemies[o].GetComponent<Tile>().tileNation == playerId)
            {
                nearEnemies[o].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.1f);
                
            }
            if (nearEnemies[o].GetComponent<Tile>().tileNation == 0)
            {
                nearEnemies[o].GetComponent<MeshRenderer>().sharedMaterial.SetColor("Outline Color", Color.red);
            }
            
        }
        



    }
    
    void Update()
    {      
        updateGame();
    }
    //oyuncu saldiracagi yeri secer
    void updateGame()
    {
    
        panelOpener = false;
        textureSwap = false;

        //for(int z = 0; z < 30; z++) { if (nearEnemies[z]) ; }
        for (int t = 0; t < nearEnemies.Count; t++)
        {
            if (nearEnemies[t].GetComponent<Tile>().tileId == playerId)
            {
                nearEnemies[t].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.1f);
            }
        }
            lightCheck = true;
        //kullanicin sectigi ilk tile kendisine ait degilse
        if (Input.GetMouseButtonDown(0))
        {
            shaderCheck = !shaderCheck; 
            if (mouseObject.GetComponent<MouseManager>().mouseCounter % 2 == 0 )
            {
                Debug.Log("CheckMouseCounter");
                if(player[turn].playerId== mouseObject.GetComponent<MouseManager>().nationId)
                {
                    friendlyTileId = mouseObject.GetComponent<MouseManager>().tileId;
                    glowFunction(friendlyTileId);
                }
                else
                {
                    //errorPanel
                }
                
                
            }
            
            
            else 
            {
                playerChosenTileId = mouseObject.GetComponent<MouseManager>().tileId;
                randomBattle(friendlyTileId,playerChosenTileId);
                
             
            }
            

           
        }
    }

  
  
    void glowFunction(int friendlyTileId) {
        
            
            Debug.Log("GlowFunction" );
        
            for(int a = 0; a < nearEnemies.Count; a++)
        {
            if (player[turn].playerId == nearEnemies[a].GetComponent<Tile>().tileNation)
            {

                
                 nearEnemies[a].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.1f);
                

            }
            if (player[turn].playerId != nearEnemies[a].GetComponent<Tile>().tileNation)
            {


                nearEnemies[a].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.0f);

            }
        }
        if (Input.GetMouseButtonDown(0)) {
            for (int z = 0; z < nearEnemies.Count; z++)
            {



                if ((nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId + 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId - 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId - columnCount && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId - columnCount + 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId - columnCount - 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId + columnCount - 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId) ||
                    (nearEnemies[z].GetComponent<Tile>().tileId == friendlyTileId + columnCount + 1 && nearEnemies[z].GetComponent<Tile>().tileNation != player[turn].playerId)


                    )
                {
                    Debug.Log("Lights on ");

                    nearEnemies[z].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.1f);
                    

                }
                else
                {
                    nearEnemies[z].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.0f);
                }
            }



            
         
         
        }

        //glow function sarı yanan tile ların id sini gecici olarak 99 yapsin
    }




    void randomBattle(int friendlyId, int enemyId)
    {



        Debug.Log("EnteredBattleFunction");

        if (mouseObject.GetComponent<MouseManager>().hit.collider.gameObject.GetComponent<Renderer>().material.shader != shader)
        {
            Debug.Log("BattleCheck3");
            random = 1;
            Debug.Log(random + "random");
            //buraya kadar calisiyo
            if (random == 1)
            {
                if (player[turn].playerId == 0)
                {
                    textureSwap = true;
                    winCondition = 1;
                }
                if (player[turn].playerId == 1)
                {
                    textureSwap = true;
                    winCondition = 1;
                }
                if (player[turn].playerId == 2)
                {
                    textureSwap = true;
                    winCondition = 1;
                }
                if (player[turn].playerId == 3)
                {
                    textureSwap = true;
                    winCondition = 1;
                }
                Debug.Log("win");
                mouseObject.GetComponent<MouseManager>().hit.collider.gameObject.GetComponent<Tile>().tileNation = 2;
                //player win
                for (int z = 0; z < columnCount; z++)
                {
                    nearEnemies[z].GetComponent<Light>().enabled = false;
                }

            }
            else
            {
                if (player[turn].playerId == 0)
                {
                    winCondition = 0;
                    textureSwap = true;
                    Debug.Log("lose");
                }
                if (player[turn].playerId == 1)
                {
                    textureSwap = true;
                    winCondition = 0;
                    Debug.Log("lose");
                }
                if (player[turn].playerId == 2)
                {
                    textureSwap = true;
                    winCondition = 0;
                    Debug.Log("lose");
                }
                if (player[turn].playerId == 3)
                {
                    textureSwap = true;
                    winCondition = 0;
                    Debug.Log("lose");
                }
                Debug.Log("lose");
                playerChosenTileId = mouseObject.GetComponent<MouseManager>().tileId;
                //player lose
                for (int z = 0; z < columnCount; z++)
                {
                    nearEnemies[z].GetComponent<Light>().enabled = false;
                }
            }


            turn++;
            if (turn == 2)
            {
                turn = 0;
            }
            for (int t = 0; t < nearEnemies.Count; t++)
            {

                nearEnemies[t].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.0f);
              



            }
            for (int s = 0; s < nearEnemies.Count; s++)
            {
                if (player[turn].playerId == nearEnemies[s].GetComponent<Tile>().tileNation)
                {
                    nearEnemies[s].GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Outline", 0.1f);
                 






                }
               
              
               
            }







        }
    }
}
