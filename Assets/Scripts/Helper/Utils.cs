using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color color = default(Color), TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 0)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return textMesh;
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        return worldCamera.ScreenToWorldPoint(screenPosition);
    }

    public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles)
    {
        vertices = new Vector3[4 * quadCount];
        uvs = new Vector2[4 * quadCount];
        triangles = new int[6 * quadCount];
    }

    public static void AddToMeshArrays(Vector3[] vertices, Vector2[] uvs, int[] triangles, int index, Vector3 quadPosition, float rotation, Vector3 quadSize, Vector2 uv00, Vector2 uv11)
    {
        int vIndex = index * 4;
        int tIndex = index * 6;

        for (int i = 0; i < 4; i++)
        {
            vertices[vIndex + i] = ApplyRotationToVector(quadSize * 0.5f, rotation) + quadPosition;
        }

        uvs[vIndex + 0] = new Vector2(uv00.x, uv00.y);
        uvs[vIndex + 1] = new Vector2(uv00.x, uv11.y);
        uvs[vIndex + 2] = new Vector2(uv11.x, uv11.y);
        uvs[vIndex + 3] = new Vector2(uv11.x, uv00.y);

        triangles[tIndex + 0] = vIndex + 0;
        triangles[tIndex + 1] = vIndex + 1;
        triangles[tIndex + 2] = vIndex + 2;
        triangles[tIndex + 3] = vIndex + 0;
        triangles[tIndex + 4] = vIndex + 2;
        triangles[tIndex + 5] = vIndex + 3;
    }

    public static Vector3 ApplyRotationToVector(Vector3 vector, float rotation)
    {
        float rad = rotation * (Mathf.PI / 180);
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        float x = vector.x;
        float y = vector.y;

        return new Vector3(cos * x - sin * y, sin * x + cos * y);
    }
}
