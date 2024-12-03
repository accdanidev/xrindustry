using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSelectionAsign : MonoBehaviour
{
    [SerializeField] InstantiateObjectScript instantiateMap;
    // Start is called before the first frame update
    void Start()
    {
        instantiateMap = FindObjectOfType<InstantiateObjectScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteMapFunction(int number)
    {
        instantiateMap.InstantiateMap(number);
    }

}
