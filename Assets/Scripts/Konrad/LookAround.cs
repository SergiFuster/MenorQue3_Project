using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    [SerializeField]
    public Transform player;
    [SerializeField]
    private LayerMask layers;

    void Update()
    {
        RaycastGround();
    }

    private void RaycastGround()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 1000f, layers))
        {
            transform.position = new Vector3(raycastHit.point.x, player.position.y, raycastHit.point.z);
        }
    }
}
