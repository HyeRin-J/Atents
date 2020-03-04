using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArrowTrigger : MonoBehaviour {
    public int blackAreaWidth;
    public int blackAreaHeight;
    public GameObject blackPanel;
    public Image[,] blackImageUIs;
    public int[] playerPos = new int[2];
    public RectTransform directionArrowImage;
    private void Start()
    {
        blackImageUIs = new Image[blackAreaHeight, blackAreaWidth];
        Image[] images = blackPanel.GetComponentsInChildren<Image>();

        int n = 1;

        for(int i = 0; i < blackAreaHeight; i++)
        {
            for(int j = 0; j < blackAreaWidth; j++)
            {
                blackImageUIs[i, j] = images[n];
                n++;
            }
        }
    }

    private void Update()
    {
        for(int i = playerPos[0] - 1; i <= playerPos[0] + 1; i++)
        {
            if (i >= blackAreaHeight) break;
            for (int j = playerPos[1] - 1; j <= playerPos[1] + 1; j++)
            {
                if (i < 0) break;
                if (j >= blackAreaWidth) break;
                if (j < 0) break;
                blackImageUIs[i, j].color = new Color(0, 0, 0, 0);
            }
        }
    }
}
