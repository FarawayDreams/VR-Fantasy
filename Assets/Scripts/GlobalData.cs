using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalData : MonoBehaviour
{
    public static int dreamPieceNum;
    public static int treasurePieceNum;
    private static bool already;

    static GlobalData()
    {
        already = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        dreamPieceNum = 0;
        if (already == true)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void getDreamPiece()
    {
        dreamPieceNum++;
        //Debug.Log("++");
    }

    public static void getTreasurePieces()
    {
        treasurePieceNum++;
    }
}
