using UnityEngine;
using System.Collections;
 
public class WorldGenerator : MonoBehaviour {
 
    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject) {
        // Клон
        GameObject clone = (GameObject)Instantiate(originalGameobject,
                                                   newPosition,
                                                   Quaternion.identity);
        // Позиция
        clone.transform.position = newPosition;
        // Переименовывем
        clone.name = "Voxel@" + clone.transform.position;
    }
}