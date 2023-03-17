using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };


    private void Start()
    {
        int originalLength = faceIndexes.Count;
        float yPosition = 2.3f;
        float xPosition = -2.2f;

        for (int i = 0; i <7; i++)
        {
            shuffleNum = rnd.Next(0, faceIndexes.Count);
            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, 0),
                Quaternion.identity);

            temp.GetComponent<MainToken>().faceindex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);

            xPosition = xPosition + 4;

            if (i == originalLength/2 - 2)
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }
        }
        token.GetComponent<MainToken>().faceindex = faceIndexes[0];
    }

    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 00)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFaces[0] >= -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] >= -2)
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

    public bool CheckMatch()
    {
        bool sucess = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            sucess = true;
        }
        return sucess;
    }

    private void Awake()
    {
        token = GameObject.Find("Token");

    }
}
