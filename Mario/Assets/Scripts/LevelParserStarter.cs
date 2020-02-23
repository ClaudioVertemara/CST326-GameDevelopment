using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Claudio Vertemara
//CST 326 Mario (Project 2)
//Feb 23, 2020

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;
    public GameObject Brick;
    public GameObject QuestionBox;
    public GameObject Stone;

    public GameObject Lava;
    public GameObject Goal;
    public GameObject Coin;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column, -row, -0.5f));
                    column++;
                }
                row++;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': ToSpawn = Brick; break;
            case '?': ToSpawn = QuestionBox; break;
            case 'x': ToSpawn = Rock; break;
            case 's': ToSpawn = Stone; break;
            case 'l': ToSpawn = Lava; break;
            case 'g': ToSpawn = Goal; break;
            case 'c': ToSpawn = Coin; break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
