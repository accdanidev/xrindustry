using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using static UnityEditor.Rendering.CameraUI;
//using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.XR.ARSubsystems.XRCpuImage;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;

public class CreateBoard : MonoBehaviour
{

    [SerializeField] Slider sliderWidth, sliderHeight;
    [SerializeField] int widthBoard = 10, heightBoard = 10;
    [SerializeField] OpenAI_Manager openAI;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] MapSpliter mapSpliter;
    bool sended = false;

    // Start is called before the first frame update
    void Start()
    {

        sliderWidth.onValueChanged.AddListener(
            (v) =>
            {
                widthBoard = (int)v;
                text.text = widthBoard.ToString() + " ,000";
            });
        //sliderHeight.onValueChanged.AddListener(
        //    (v) =>
        //    {
        //        heightBoard = (int)v;
        //    });
        openAI = FindObjectOfType<OpenAI_Manager>();
        mapSpliter = FindObjectOfType<MapSpliter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openAI.responseBoard != "" && sended)
        {
            mapSpliter.IncomingMessage(openAI.responseBoard);
            sended = false;
        }
        //text.text = openAI.response;
    }

    public void CreateLLMBoard()
    {
        string llm = "You are an expert in industrial plant layout optimization, with a focus on maximizing space efficiency, ensuring safety, and promoting ease of movement. Design an optimized layout for a car assembly plant covering " + widthBoard + " acres, represented as an ASCII grid where each square in the grid is equivalent to 0.5 acres. Layout Requirements: Divide the layout into three main areas: Welding Area(S) Assembly Area(E) Painting Area(P) Pathways(C): Within each area, include pathways marked as 'C' for internal access, ensuring efficient navigation and interaction across zones.Ensure all areas are interconnected by pathways, creating seamless movement between sections for materials, personnel, and emergency evacuation routes. Layout Logic: Allocate sufficient space for each area while maintaining the following order: Welding Area (S), Assembly Area (E), and then Painting Area (P).Each area should have designated pathways to facilitate efficient access and workflow. Output Format: Provide the layout as an ASCII grid using the following symbols: S for the Welding Area E for the Assembly Area P for the Painting Area C for pathways Add an 'N' at the end of each row to make parsing easier. Objective: Focus on space optimization, clear area transitions, and an overall layout ideal for car assembly efficiency. Return the final output in ASCII grid format, following the layout logic provided. And give a short description about the layou, the description will content maximun 1000 characters";


        //string llm = "Create an ASCII map of a "+ widthBoard * heightBoard +"-acre car assembly plant on a grid with " + heightBoard + " rows and " + widthBoard + " columns. Each grid cell represents 0.5 acres. Divide the plant into three sections, each representing a zone with a specific purpose: Zone 1 - Welding: Place welding machinery (represented by the letter 'S') and paths (represented by the letter 'C'). Zone 2 - Assembly: Place assembly machinery (letter 'E') and paths ('C'). Zone 3 - Painting: Place painting machinery (letter 'P') and paths ('C'). Ensure there is always path access between zones to connect all three sections. Finally, return the ASCII representation in JSON format, where each cell is labeled according to its type, path structure, or machinery. Each cell should include its grid location, its content (type of machinery or path), and its corresponding zone.";
        print(llm);
        openAI.CallModelBoard(llm);
        sended = true;

    }
}
