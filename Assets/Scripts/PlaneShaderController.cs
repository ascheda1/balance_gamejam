using UnityEngine;

public class PlaneShaderController : MonoBehaviour
{
    public enum PlaneType { White, Black }
    public PlaneType planeType;

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 normal = transform.up; // or .forward depending on your plane

        if (planeType == PlaneType.White)
        {
            Shader.SetGlobalVector("_WhitePlanePosition", pos);
            Shader.SetGlobalVector("_WhitePlaneNormal", normal);
        }
        else
        {
            Shader.SetGlobalVector("_BlackPlanePosition", pos);
            Shader.SetGlobalVector("_BlackPlaneNormal", normal);
        }
    }
}
