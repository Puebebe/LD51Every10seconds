using UnityEngine;

public class HexagonsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject hexagonPrefab;
    [SerializeField]
    private int generatingRadius;
    
    private float horizontalSpacing = 1.7f, verticalSpacing = 0.5f;

    private void Awake()
    {
        generateHexagons();
    }

    private void generateHexagons()
    {
        for (int row = -generatingRadius * 2; row <= generatingRadius * 2; row++)
        {
            float rowOffset = 0;
            int evenModifier = 0;

            if (row % 2 != 0)
            {
                rowOffset = horizontalSpacing / 2;
                evenModifier = 1;
            }

            for (int column = -generatingRadius + 1; column < generatingRadius - evenModifier; column++)
            {
                Vector3 position = new Vector3(column * horizontalSpacing + rowOffset, row * verticalSpacing);
                Instantiate(hexagonPrefab, transform.position + position, Quaternion.identity, parent: this.transform);
            }
        }
    }
}
