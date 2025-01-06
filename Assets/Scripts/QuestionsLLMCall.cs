using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class QuestionsLLMCall : MonoBehaviour
{
    [SerializeField]
    OpenAI_Manager openAI;
    [SerializeField]
    InstantiateObjectScript instantiateOS;
    [SerializeField]
    MapSpliter mapSpliter;
    [SerializeField]
    int valueOfData;
    [SerializeField]
    TextMeshProUGUI textProduction, textEfficiency;
    bool sended;
    [SerializeField]
    GameObject animationLoading;
    [SerializeField]
    TextMeshProUGUI sizeMap, sizeMap2;

    void Start()
    {
        print("buscando");
        openAI = FindObjectOfType<OpenAI_Manager>();
        instantiateOS = FindObjectOfType<InstantiateObjectScript>();
        mapSpliter = FindObjectOfType<MapSpliter>();
        sizeMap.text = mapSpliter.sizeMap.ToString() + ", 000";
        sizeMap2.text = mapSpliter.sizeMap.ToString() + ", 000";
    }

    // Update is called once per frame
    void Update()
    {
        if (openAI.responseBoard != "" && sended)
        {
            print("enviando corotuitne");
            string text = openAI.responseBoard;
            openAI.responseBoard = "";
            mapSpliter.IncomingMessage(text);
            sended = false;
            animationLoading.SetActive(false);
        }
    }

    public void SendLLMOptimization()
    {
        valueOfData = int.Parse(textProduction.text);
        string llm = "Based on the map you provided, optimize the layout to increase car production by" + valueOfData + "per day while maintaining the same size, represented as an ASCII grid where each square equals 0.5 acres.Design requirements: divide the layout into three main areas: Welding Area(S), Assembly Area(E), and Painting Area(P).Pathways(C): within each area, include pathways marked as 'C' to ensure efficient internal access, facilitating navigation and interaction between zones.Ensure that all areas are interconnected by pathways, allowing smooth movement between sections for materials, personnel, and emergency evacuation routes. Layout logic: allocate sufficient space for each area while maintaining the following order: Welding Area (S), Assembly Area (E), and then Painting Area (P). Each area must have designated pathways to facilitate access and workflow.Output format: provide the layout as an ASCII grid using the following symbols: S for the Welding Area, E for the Assembly Area, P for the Painting Area, and C for pathways.Add an 'N' at the end of each row to facilitate analysis. befor the map add #===# and when the map ends add #===#Objective: focus on space optimization, clear transitions between areas, and an overall design ideal for car assembly efficiency.Return the final output in ASCII grid format following the provided layout logic, and include a brief description of the design with a maximum of 700 characters. omit the nomenclature (S , E, P, C) from the description.";


        //string llm = "Create an ASCII map of a "+ widthBoard * heightBoard +"-acre car assembly plant on a grid with " + heightBoard + " rows and " + widthBoard + " columns. Each grid cell represents 0.5 acres. Divide the plant into three sections, each representing a zone with a specific purpose: Zone 1 - Welding: Place welding machinery (represented by the letter 'S') and paths (represented by the letter 'C'). Zone 2 - Assembly: Place assembly machinery (letter 'E') and paths ('C'). Zone 3 - Painting: Place painting machinery (letter 'P') and paths ('C'). Ensure there is always path access between zones to connect all three sections. Finally, return the ASCII representation in JSON format, where each cell is labeled according to its type, path structure, or machinery. Each cell should include its grid location, its content (type of machinery or path), and its corresponding zone.";
        print(llm);
        instantiateOS.DeleteOldMap();

        openAI.CallModelBoard(llm);
        sended = true;
        animationLoading.SetActive(true);
    }

    public void SendLLMEfficiency()
    {
        valueOfData = int.Parse(textProduction.text);
        string llm = "Based on the map you provided, optimize the layout to increase the efficiency to create cars by" + valueOfData + "% per day while maintaining the same size, represented as an ASCII grid where each square equals 0.5 acres.Design requirements: divide the layout into three main areas: Welding Area(S), Assembly Area(E), and Painting Area(P).Pathways(C): within each area, include pathways marked as 'C' to ensure efficient internal access, facilitating navigation and interaction between zones.Ensure that all areas are interconnected by pathways, allowing smooth movement between sections for materials, personnel, and emergency evacuation routes. Layout logic: allocate sufficient space for each area while maintaining the following order: Welding Area (S), Assembly Area (E), and then Painting Area (P). Each area must have designated pathways to facilitate access and workflow.Output format: provide the layout as an ASCII grid using the following symbols: S for the Welding Area, E for the Assembly Area, P for the Painting Area, and C for pathways.Add an 'N' at the end of each row to facilitate analysis. befor the map add #===# and when the map ends add #===# .Objective: focus on space optimization, clear transitions between areas, and an overall design ideal for car assembly efficiency.Return the final output in ASCII grid format following the provided layout logic, and include a brief description of the design with a maximum of 700 characters. omit the nomenclature (S , E, P, C) from the description.";


        //string llm = "Create an ASCII map of a "+ widthBoard * heightBoard +"-acre car assembly plant on a grid with " + heightBoard + " rows and " + widthBoard + " columns. Each grid cell represents 0.5 acres. Divide the plant into three sections, each representing a zone with a specific purpose: Zone 1 - Welding: Place welding machinery (represented by the letter 'S') and paths (represented by the letter 'C'). Zone 2 - Assembly: Place assembly machinery (letter 'E') and paths ('C'). Zone 3 - Painting: Place painting machinery (letter 'P') and paths ('C'). Ensure there is always path access between zones to connect all three sections. Finally, return the ASCII representation in JSON format, where each cell is labeled according to its type, path structure, or machinery. Each cell should include its grid location, its content (type of machinery or path), and its corresponding zone.";
        print(llm);
        instantiateOS.DeleteOldMap();

        openAI.CallModelBoard(llm);
        sended = true;
        animationLoading.SetActive(true);
    }

    public void DeleteAllMap()
    {

    }

}
