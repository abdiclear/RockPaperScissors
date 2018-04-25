using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour {
    [Header("Set Dynamically")]

    public Text compGT;
    public Text playGT;
    public Text gameGT;

    Vector3 p3 = new Vector3(-200f, 50f, 0f);
    Vector3 c3 = new Vector3(200f, 50f, 0f);
    Vector3 l3 = new Vector3(0f, 50f, 0f);

    public GameObject RockPrefab;
    public GameObject PaperPrefab;
    public GameObject ScissorsPrefab;
    public GameObject PlayerWinPrefab;
    public GameObject ComputerWinPrefab;
    public GameObject DrawPrefab;

    int gamesPlayed = 0;
    int yourWins = 0;
    int computerWins = 0;

	// Use this for initialization
	void Start () {

        GameObject gameGO = GameObject.Find("Round");
        GameObject playGO = GameObject.Find("Your Score");
        GameObject compGO = GameObject.Find("Computer Score");

        gameGT = gameGO.GetComponent<Text>();
        playGT = playGO.GetComponent<Text>();
        compGT = compGO.GetComponent<Text>();

        gameGT.text = "0";
        playGT.text = "0";
        compGT.text = "0";
		
	}


    public void RockBttnClick() {

        GameObject rPrfb = Instantiate(RockPrefab, p3, Quaternion.identity) as GameObject;
        rPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        rPrfb.transform.Translate(p3);

        logicWork(1, rPrfb);

       

    }

    public void PaperBttnClick()
    {
        GameObject pPrfb = Instantiate(PaperPrefab, p3, Quaternion.identity) as GameObject;
        pPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        pPrfb.transform.Translate(p3);

        logicWork(2, pPrfb);

        

    }

    public void ScissorsBttnClick()
    {
        GameObject sPrfb = Instantiate(ScissorsPrefab, p3, Quaternion.identity) as GameObject;
        sPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        sPrfb.transform.Translate(p3);

        logicWork(3, sPrfb);

       

    }

    void CheckForGameOver()
    {

        if (gamesPlayed == 10) {

            if(computerWins < yourWins)
            {

                GameObject cWPrfb = Instantiate(PlayerWinPrefab, l3, Quaternion.identity) as GameObject;
                cWPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                cWPrfb.transform.Translate(l3);

                StartCoroutine(ShortPause());

                


            }else if(computerWins > yourWins)
            {

                GameObject pWPrfb = Instantiate(ComputerWinPrefab, l3, Quaternion.identity) as GameObject;
                pWPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                pWPrfb.transform.Translate(l3);

                StartCoroutine(ShortPause());

                


            }
            else
            {

                GameObject dWPrfb = Instantiate(DrawPrefab, l3, Quaternion.identity) as GameObject;
                dWPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                dWPrfb.transform.Translate(l3);

                StartCoroutine(ShortPause());

                


            }


        }


    }

    void logicWork(int pMove, GameObject prefab)
    {

        System.Random rnd = new System.Random();

        GameObject cPrfb = new GameObject();
        GameObject wPrfb = prefab;

        int computerMove = rnd.Next(1, 4);
        int playerMove = pMove;

        if (computerMove == 1)
        {

            cPrfb = Instantiate(RockPrefab, c3, Quaternion.identity) as GameObject;
            cPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            cPrfb.transform.Translate(c3);

        }
        else if (computerMove == 2)
        {

            cPrfb = Instantiate(PaperPrefab, c3, Quaternion.identity) as GameObject;
            cPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            cPrfb.transform.Translate(c3);

        }
        else if(computerMove == 3)
        {

            cPrfb = Instantiate(ScissorsPrefab, c3, Quaternion.identity) as GameObject;
            cPrfb.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            cPrfb.transform.Translate(c3);

        }

        if (computerMove != playerMove)
        {

            if ((playerMove == 1 && computerMove == 3) || (playerMove == 2 && computerMove == 1)
                || (playerMove == 3 && computerMove == 2))
            {

                int score = int.Parse(playGT.text);
                score += 1;
                playGT.text = score.ToString();

                int round = int.Parse(gameGT.text);
                round += 1;
                gameGT.text = round.ToString();

                yourWins++;
                gamesPlayed++;

            }
            else
            {
                int score = int.Parse(compGT.text);
                score += 1;
                compGT.text = score.ToString();

                int round = int.Parse(gameGT.text);
                round += 1;
                gameGT.text = round.ToString();

                computerWins++;
                gamesPlayed++;


            }


        }
        else
        {

            int round = int.Parse(gameGT.text);
            round += 1;
            gameGT.text = round.ToString();
            gamesPlayed++;

        }

        StartCoroutine(VeryShortPause(wPrfb, cPrfb));

      

        CheckForGameOver();
         
    }

    
    
    IEnumerator ShortPause()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }

    IEnumerator VeryShortPause(GameObject g1, GameObject g2)
    {
        yield return new WaitForSeconds(2);

        Destroy(g1);
        Destroy(g2);

    }
}
