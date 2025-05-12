using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Word = "after";
    public int LivesCount = 10;
    public TextMeshProUGUI MainWord;
    public TextMeshProUGUI OurInput;
    public TextMeshProUGUI SubmittedImput;
    public TMP_InputField InputField;
    // Start is called before the first frame update
    void Start()
    {
        MainWord.text = Word;
        OurInput.text = $"Zostało prób: {LivesCount}."; 
    }

    public void OnInputChanged(string input)
    {
        //OurInput.text = input;
    }

    public void OnClick()
    {
        Debug.Log("Przycisk został kliknięty.");
        LivesCount = LivesCount - 1;
        OurInput.text = $"Zostało prób: {LivesCount}.";

        if (Word == InputField.text)
        {
            Debug.Log($"Corect guess");
            return;
        }
        if(Word.Length != InputField.text.Length)
        {
            SubmittedImput.text = $"Długość się nie zgadza";
            return;
        }

        int bullsCount = CountBulls();
        int cowsCount = CountCows();

        SubmittedImput.text = $"Bulls: {bullsCount} and Cows:{cowsCount}";

    }

    private int CountCows()
    {
        int result = 0;

        for (int i = 0; i < Word.Length; i++)
        {
            if (Word[i] != InputField.text[i] && Word.Contains(InputField.text[i]))
            {
                result++;
            }

            return result;
    }
    public int CountBulls()
    {
        int result = 0;

        for (int i = 0; i < Word.Length; i++)
        {
            if(Word[i] == InputField.text[i])
                {
                  result++;
                }
        }
        return result;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
