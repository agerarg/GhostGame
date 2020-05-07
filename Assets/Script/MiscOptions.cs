using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscOptions : MonoBehaviour
{
    public GameObject Instruction;
    private bool isInstructionActie = false;
    void Start()
    {
        Instruction.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowInstructions()
    {
        Instruction.SetActive(true);
        isInstructionActie = true;
    }
    public void InstructionsOff()
    {
        Instruction.SetActive(false);
        isInstructionActie = false;
        
    }
    void Update()
    {
        if(isInstructionActie)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire1"))
            {
                InstructionsOff();
            }

            
        }
    }
}
