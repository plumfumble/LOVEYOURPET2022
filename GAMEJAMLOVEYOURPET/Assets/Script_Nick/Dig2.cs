using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig2 : MonoBehaviour
{
    public GameObject[] shapes;
    public GameObject[,] allShapes = new GameObject[5, 5];
    private bool isDragging = false;
    private Vector2 startPos;
    private Vector2 endPos;

    void Start()
    {
        PopulateBoard();
    }

    void PopulateBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject newShape = Instantiate(shapes[Random.Range(0, shapes.Length)], new Vector2(i, j), Quaternion.identity);
                allShapes[i, j] = newShape;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = Mathf.RoundToInt(mousePos.x);
            int y = Mathf.RoundToInt(mousePos.y);
            Debug.Log(x);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            CheckSwap();
        }
        
    }

    void CheckSwap()
    {
        if (!isDragging)
        {
            float swipeDistance = Vector2.Distance(startPos, endPos);

            if (swipeDistance > 50)
            {
                Vector2 direction = endPos - startPos;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                    {
                        SwapShapes(1, 0);
                    }
                    else
                    {
                        SwapShapes(-1, 0);
                    }
                }
                else
                {
                    if (direction.y > 0)
                    {
                        SwapShapes(0, 1);
                    }
                    else
                    {
                        SwapShapes(0, -1);
                    }
                }
            }
        }
    }

    void SwapShapes(int x, int y)
    {
        isDragging = true;

        // Get the first selected shape
        Debug.Log((int)startPos.x);
        Debug.Log((int)startPos.y);
        Vector2 firstShapePos = allShapes[(int)startPos.x, (int)startPos.y].transform.position;
        GameObject firstShape = allShapes[(int)startPos.x, (int)startPos.y];
        
        // Get the second selected shape
        Vector2 secondShapePos = allShapes[(int)startPos.x + x, (int)startPos.y + y].transform.position;
        GameObject secondShape = allShapes[(int)startPos.x + x, (int)startPos.y + y];

        // Swap their positions
        firstShape.transform.position = secondShapePos;
        secondShape.transform.position = firstShapePos;

        // Update the allShapes array
        allShapes[(int)startPos.x, (int)startPos.y] = secondShape;
        allShapes[(int)startPos.x + x, (int)startPos.y + y] = firstShape;

        // Wait for the swap animation to finish before checking for matches
        Invoke("CheckMatches", 0.5f);
    }

    void CheckMatches()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject currentShape = allShapes[i, j];

                if (i < 3 && currentShape.tag == allShapes[i + 1, j].tag && currentShape.tag == allShapes[i + 2, j].tag)
                {
                    Destroy(currentShape);
                    Destroy(allShapes[i + 1, j]);
                    Destroy(allShapes[i + 2, j]);

                    allShapes[i, j] = null;
                    allShapes[i + 1, j] = null;
                    allShapes[i + 2, j] = null;
                }
                else if (j < 3 && currentShape.tag == allShapes[i, j + 1].tag && currentShape.tag == allShapes[i, j + 2].tag)
                {
                    Destroy(currentShape);
                    Destroy(allShapes[i, j + 1]);
                    Destroy(allShapes[i, j + 2]);

                    allShapes[i, j] = null;
                    allShapes[i, j + 1] = null;
                    allShapes[i, j + 2] = null;
                }
            }
        }

        // Shift the shapes down to fill any gaps
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allShapes[i, j] == null)
                {
                    for (int k = j + 1; k < 5; k++)
                    {
                        if (allShapes[i, k] != null)
                        {
                            allShapes[i, j] = allShapes[i, k];
                            allShapes[i, k] = null;
                            allShapes[i, j].transform.position = new Vector2(i, j);
                            break;
                        }
                    }
                }
            }
        }

        // Populate any empty cells with new shapes
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allShapes[i, j] == null)
                {
                    GameObject newShape = Instantiate(shapes[Random.Range(0, shapes.Length)], new Vector2(i, j), Quaternion.identity);
                    allShapes[i, j] = newShape;
                }
            }
        }

        isDragging = false;
    }
    void SelectedPiece()
    {

    }
}
