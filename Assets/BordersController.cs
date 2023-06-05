using UnityEngine;

public class BordersController : MonoBehaviour
{
    public GameObject ground;

    public BoxCollider lbCollider;
    public BoxCollider rbCollider;

    private void Start()
    {
        SetUpBorders();
    }

    private void SetUpBorders()
    {
        Vector3 groundScale = ground.transform.localScale;
        float groundZPosition = ground.transform.position.z;
        lbCollider.center = new Vector3((-groundScale.x - 1) / 2, 0f, groundZPosition);
        rbCollider.center = new Vector3((groundScale.x + 1) / 2, 0f, groundZPosition);
        lbCollider.size = new Vector3(1f, 6f, groundScale.z);
        rbCollider.size = new Vector3(1f, 6f, groundScale.z);
    }
}
