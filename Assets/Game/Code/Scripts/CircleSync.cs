using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_PlayerPosition");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material WallMaterial;
    public Camera MainCamera;
    public LayerMask Mask;

    private void Update()
    {
        var direction = MainCamera.transform.position - transform.position;
        var ray = new Ray(transform.position, direction.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
            WallMaterial.SetFloat(SizeID, 1);
        else
            WallMaterial.SetFloat (SizeID, 0);

        var view = MainCamera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);

        Debug.DrawRay(transform.position,direction,Color.red);
    }
}
