using UnityEngine;

public class HexagonsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject hexagonPrefab;
    [SerializeField]
    private int sideLength;
    
    private float horizontalSpacing = 0.85f, verticalSpacing = 1f;

    private void Awake()
    {
        generateHexagons();
    }

    private void generateHexagons()
    {
        int hexagonsInColumn = sideLength;

        for (int column = -sideLength + 1; column < sideLength; column++)
        {
            float rowOffset = 0;
            
            if (column % 2 != 0)
            {
                rowOffset = verticalSpacing / 2;
            }

            for (int row = -hexagonsInColumn / 2; row < (hexagonsInColumn + 1) / 2; row++)
            {
                Vector3 position = new Vector3(column * horizontalSpacing, row * verticalSpacing + rowOffset);
                Instantiate(hexagonPrefab, transform.position + position, Quaternion.identity, parent: this.transform);
            }

            if (column < 0)
                hexagonsInColumn++;
            else
                hexagonsInColumn--;
        }
    }
}
