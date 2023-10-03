using UnityEngine;

public class CubeGenerator : MonoBehaviour {
    public GameObject cubePrefab;
    public int totalBoxes = 67; // Set this value in the Inspector.

    private void Start() {
        GenerateCubes(totalBoxes);
    }
    void GenerateCubes(int totalCount) {
        int sets = Mathf.CeilToInt((float)totalCount / 9);
        float xOffset = 0,yOffset=0,yHeight=0;
        float temp=0;
        for (int setIndex = 0; setIndex <sets; setIndex++) {
            int cubesInSet = Mathf.Min(totalCount - (setIndex * 9), 9);
            GameObject cube = Instantiate(cubePrefab, transform);//Spawn central cube
            cube.transform.position = new Vector3(xOffset, yOffset,0);
            yHeight = yOffset + 1;
            yHeight = -yHeight;
            for (int cubeIndex = 0; cubeIndex < cubesInSet-1; cubeIndex++) {
                if (xOffset > 0) {
                    temp = xOffset;
                    xOffset = -xOffset;
                } else if (xOffset <= 0) {
                    temp++; xOffset = temp;
                    if (yHeight < yOffset) {
                   yHeight = yOffset + 1;
                    } else {
                        yHeight = yOffset - 1;
                    }
                }
              cube = Instantiate(cubePrefab, transform);
              cube.transform.position = new Vector3(xOffset, yHeight,0 );
            }
            yOffset += 4;//distance btw row
            xOffset = 0;
            temp = 0;
        }
    }
}
