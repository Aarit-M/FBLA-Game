using UnityEngine;

public class SquareTransparencyRandomizer : MonoBehaviour
{
    public GameObject[] squares; // Array to hold all square game objects

    private void Start()
    {
        // Find all square game objects in the scene
        squares = GameObject.FindGameObjectsWithTag("Square");

        // Select 5 random squares
        int[] selectedIndices = new int[5];
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, squares.Length);
            // Make sure the selected square hasn't been chosen before
            while (ArrayContains(selectedIndices, randomIndex))
            {
                randomIndex = Random.Range(0, squares.Length);
            }
            selectedIndices[i] = randomIndex;
        }

        // Make selected squares transparent and store transparency information
        foreach (int index in selectedIndices)
        {
            GameObject square = squares[index];
            // Make the square transparent
            SetTransparency(square, 0.5f);
            // Store transparency information
            float transparency = GetTransparency(square);
            // Print the transparency information
            Debug.Log("Square " + square.name + " transparency: " + transparency);
        }
    }

    // Helper function to check if an array contains a specific value
    private bool ArrayContains(int[] array, int value)
    {
        foreach (int item in array)
        {
            if (item == value)
            {
                return true;
            }
        }
        return false;
    }

    // Function to set transparency of a square
    public void SetTransparency(GameObject square, float alpha)
    {
        Renderer renderer = square.GetComponent<Renderer>();
        if (renderer != null)
        {
            Color color = renderer.material.color;
            color.a = alpha;
            renderer.material.color = color;
        }
    }

    // Function to get transparency of a square
    public float GetTransparency(GameObject square)
    {
        Renderer renderer = square.GetComponent<Renderer>();
        if (renderer != null)
        {
            Color color = renderer.material.color;
            return color.a;
        }
        return -1f; // Return -1 if transparency cannot be retrieved
    }
}
