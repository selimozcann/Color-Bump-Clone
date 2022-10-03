using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private ColorType colorType;
    public ColorType ColorType { get { return colorType; } set { colorType = value; } }
}
