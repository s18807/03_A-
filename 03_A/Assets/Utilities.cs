using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Utilities
{
    public static TextMesh CreateTextPanel(Transform parent, string txt, Vector3 pos, int fontsize, Color color, TextAnchor textAnchor, TextAlignment alignment, Vector3 rotation = default)
    {
        GameObject gameObject = new GameObject("Dummy text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = pos;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = alignment;
        textMesh.text = txt;
        textMesh.characterSize = 0.01f;
        textMesh.alignment = alignment;
        textMesh.fontSize = fontsize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = 0;
        if (rotation != default) transform.Rotate(rotation);
        return textMesh;
    }

    public static Vector3 GetMouseWorldPos(Vector3 pos)
    {
        Debug.Log(pos);
        Vector3 vector3 = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 1));
        vector3.y = 0;
        return vector3;
    }

    public static Vector3 GetMouseWorldPos3D()
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999))
            return raycastHit.point;

        return Vector3.zero;
    }
    public static Vector3 GetMouseWorldPos2D() {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return mousePos;
    }
    public static GameObject GetMouseWorldPos3DHitGameObject()
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999))
            return raycastHit.collider.gameObject;

        return null;
    }
}
