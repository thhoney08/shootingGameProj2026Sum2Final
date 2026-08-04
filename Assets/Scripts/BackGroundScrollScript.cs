using UnityEngine;

public class BackGroundScrollScript : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public Color BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1f); // Dark gray color
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        /**if (mat.HasProperty("_Color"))
        {
            mat.color = BackgroundColor;
        }
        else
        {
            Debug.LogWarning("Material does not have a _Color property.");
        }**/
    }

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        mat.mainTextureOffset = offset;
    }
}
