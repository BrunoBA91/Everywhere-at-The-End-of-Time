using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject PanelID1;
    public GameObject PanelID2;
    public GameObject PanelID3;
    public GameObject PanelID4;
    public GameObject PanelID5;
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public int[] visibleFaces = { -1, -2 };

    FlipManager tokenUp1 = null;
    FlipManager tokenUp2 = null;

    void Start()
    {
        int originalLength = faceIndexes.Count;
        float yPosition = 3.2f;
        float xPosition = -6.1f;
        float xSpacing = 4f;
        float ySpacing = -3.25f;

        for (int i = 0; i < 11; i++)
        {
            xPosition = xPosition + xSpacing;
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<FlipManager>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            if (i == 2 || i == 6)
            {
                yPosition += ySpacing;
                xPosition = -10.1f;
            }
        }
        token.GetComponent<FlipManager>().faceIndex = faceIndexes[0];
    }

    public bool TwoCardsUp()
    {
        bool cardsUp = false;

        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }

        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public void TokenDown(FlipManager tempToken)
    {
        if (tokenUp1 == tempToken)
        {
            tokenUp1 = null;
        }
        else if (tokenUp2 == tempToken)
        {
            tokenUp2 = null;
        }
    }

    public bool TokenUp(FlipManager tempToken)
    {
        bool flipCard = true;
        if (tokenUp1 == null)
        {
            tokenUp1 = tempToken;
        }
        else if (tokenUp2 == null)
        {
            tokenUp2 = tempToken;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }


    public void CheckTokens()
    {
        if (tokenUp1 != null && tokenUp2 != null)
        {
            if ((tokenUp1.faceIndex == 0 || tokenUp1.faceIndex == 1) && (tokenUp2.faceIndex == 0 || tokenUp2.faceIndex == 1))
            {
                tokenUp1.matched = true;
                tokenUp2.matched = true;
                tokenUp1 = null;
                tokenUp2 = null;
                PanelID1.SetActive(true);

            }
            else if ((tokenUp1.faceIndex == 2 || tokenUp1.faceIndex == 3) && (tokenUp2.faceIndex == 2 || tokenUp2.faceIndex == 3))
            {
                tokenUp1.matched = true;
                tokenUp2.matched = true;
                tokenUp1 = null;
                tokenUp2 = null;
                PanelID2.SetActive(true);
            }
            else if ((tokenUp1.faceIndex == 4 || tokenUp1.faceIndex == 5) && (tokenUp2.faceIndex == 4 || tokenUp2.faceIndex == 5))
            {
                tokenUp1.matched = true;
                tokenUp2.matched = true;
                tokenUp1 = null;
                tokenUp2 = null;
                PanelID3.SetActive(true);
            }
            else if ((tokenUp1.faceIndex == 6 || tokenUp1.faceIndex == 7) && (tokenUp2.faceIndex == 6 || tokenUp2.faceIndex == 7))
            {
                tokenUp1.matched = true;
                tokenUp2.matched = true;
                tokenUp1 = null;
                tokenUp2 = null;
                PanelID4.SetActive(true);
            }
            else if ((tokenUp1.faceIndex == 8 || tokenUp1.faceIndex == 9) && (tokenUp2.faceIndex == 8 || tokenUp2.faceIndex == 9))
            {
                tokenUp1.matched = true;
                tokenUp2.matched = true;
                tokenUp1 = null;
                tokenUp2 = null;
                PanelID5.SetActive(true);
            }
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if ((visibleFaces[0] == 0 || visibleFaces[0] == 1) && (visibleFaces[1] == 0 || visibleFaces[1] == 1))
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        else if ((visibleFaces[0] == 2 || visibleFaces[0] == 3) && (visibleFaces[1] == 2 || visibleFaces[1] == 3))
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        else if ((visibleFaces[0] == 4 || visibleFaces[0] == 5) && (visibleFaces[1] == 4 || visibleFaces[1] == 5))
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        else if ((visibleFaces[0] == 6 || visibleFaces[0] == 7) && (visibleFaces[1] == 6 || visibleFaces[1] == 7))
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        else if ((visibleFaces[0] == 8 || visibleFaces[0] == 9) && (visibleFaces[1] == 8 || visibleFaces[1] == 9))
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }

        return success;
    }

    private void Awake()
    {
        token = GameObject.Find("Card");
    }

    
}
