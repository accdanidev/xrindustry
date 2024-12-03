using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;
using UnityEngine.Windows;

public class MapSpliter : MonoBehaviour
{
    [SerializeField] InstantiateObjectScript instantiateObjectScript;
    [SerializeField] List<string> information;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncomingMessage(string message)
    {
        print("===" + message);
        var match = Regex.Match(message, @"```([\s\S]*?)```");
        Vector3 positionCorrect = Vector3.zero;
        if (match.Success)
        {
            // Almacenar el texto del mapa en extractedText
            string extractedText = match.Groups[1].Value;
            print("Mapa:");
            print(extractedText);

            // Separar la explicación del mensaje original
            string explanation = message.Substring(match.Index + match.Length).Trim();

            // Almacenar la explicación en la variable global information
            information.Clear(); // Limpiar la lista antes de agregar nueva información
            information.Add(explanation);

            // Crear una lista para almacenar cada carácter individualmente
            List<string> characterList = new List<string>();

            foreach (char c in extractedText)
            {
                if (c == '\n')
                {
                    // Agregar el salto de línea como un solo elemento
                    characterList.Add("\n");
                }
                else
                {
                    // Agregar cada letra individualmente
                    characterList.Add(c.ToString());
                }
            }

            print(characterList.Count);
            float vertical = 0;
            float horizontal = 0;
            foreach (string character in characterList)
            {
                if (character == "\n")
                {
                    horizontal = 0;
                    vertical += 0.2f;
                }
                instantiateObjectScript.IsntantiateObject(character, positionCorrect, Quaternion.identity);
                positionCorrect = new Vector3(horizontal, 0, vertical);
                horizontal += 0.2f;
            }

            instantiateObjectScript.InstantiateMap(1);
            instantiateObjectScript.textToShow = information[0];
            instantiateObjectScript.InstantiateCard(new Vector3(0, 1, 0));

        }
        else
        {
            print("no fue exitoso");
        }
    }
}
