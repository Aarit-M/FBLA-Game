using UnityEngine;

public class IndexAccessor : MonoBehaviour
{
    private SquareTransparencyRandomizer transparencyRandomizer; // Reference to SquareTransparencyRandomizer script
    private string newName;

    private void Start()
    {

        // Get the current name of the GameObject
        string currentName = gameObject.name;

        // Split the name to extract the row and column numbers
        string[] nameParts = currentName.Split('R', 'C');
        if (nameParts.Length == 3)
        {
            // Extract row and column numbers
            string column = nameParts[1];
            string row = nameParts[2];

            // Create the new name in the specified format
            newName = "R" + row + "C" + column;

            // Print the new name to the console
            //Debug.Log("Changed name to: " + newName);
        }

        Invoke("GetInfo", 0.5f);

    }

    private void GetInfo()
    {
        // Find the SquareTransparencyRandomizer script in the scene
        transparencyRandomizer = FindObjectOfType<SquareTransparencyRandomizer>();

        if (transparencyRandomizer != null)
        {
            // Retrieve the transparency information from the SquareTransparencyRandomizer script
            foreach (GameObject square in transparencyRandomizer.squares)
            {
                float transparency = transparencyRandomizer.GetTransparency(square);
               // Debug.Log("GameObject: " + square.name + ", Transparency: " + transparency);
            }
        }
        else
        {
            //Debug.LogError("SquareTransparencyRandomizer script not found in the scene!");
        }
    }

    private void OnMouseDown()
    {
        // Find the SquareTransparencyRandomizer script in the scene
        transparencyRandomizer = FindObjectOfType<SquareTransparencyRandomizer>();

        if (transparencyRandomizer != null)
        {
            // Retrieve the transparency information from the SquareTransparencyRandomizer script
            foreach (GameObject square in transparencyRandomizer.squares)
            {
                float transparency = transparencyRandomizer.GetTransparency(square);
                Debug.Log("GameObject: " + square.name + ", Transparency: " + transparency);
                if(transparency == 0.5f)
                {
                    if(newName == square.name)
                    {
                        Debug.Log("good job");
                    } else
                    {
                        Debug.Log("ur wrong if u clicked " + gameObject.name + "and bcuz " + newName + " not " + square.name);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("SquareTransparencyRandomizer script not found in the scene!");
        }
    }

}
