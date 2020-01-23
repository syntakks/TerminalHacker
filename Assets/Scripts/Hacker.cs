using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen
    {
        MainMenu,
        Password,
        Win,
        None
    }
    Screen currentScreen; 
    int level = 0;
    //TODO need list of passwords. 
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "edwardsnowden", "verizonwireless", "bigbrother", "wannacry" };
    string currentPassword; 

    void Start()
    {
        Terminal.WriteLine("Hello Steve");
    }

    void OnUserInput(string input)
    {
        // Input that is always available. 
        switch (input)
        {
            case "menu":
                ShowMainMenu();
                return;
            case "007":
                Terminal.ClearScreen();
                Terminal.WriteLine("We meet again Mr. Bond");
                return;
            case "clear":
                currentScreen = Screen.None; 
                Terminal.ClearScreen();
                return; 
        } 
        switch (currentScreen)
        {
            case Screen.MainMenu:
                OnMenuInput(input); 
                break;
            case Screen.Password:
                OnPasswordInput(input); 
                break;
            case Screen.Win:
                OnWinInput(input); 
                break; 
        }
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu; 
        Terminal.ClearScreen(); 
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police department");
        Terminal.WriteLine("Press 3 for the NSA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:"); 
    }

    private void OnMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                level = 1; 
                break;
            case "2":
                level = 2; 
                break;
            case "3":
                level = 3; 
                break;
            default:
                Terminal.WriteLine("Invalid input. Please Select a level"); 
                return; 
        }
        Terminal.WriteLine("You have chosen level " + level);
        SetPassword(level); 
        AskForPassword(); 
    }

    private void OnPasswordInput(string input)
    {
        CheckPassword(input); 
    }

    private void OnWinInput(string input)
    {

    }

    private void SetPassword(int level)
    {
        switch (level)
        {
            case 1:
                currentPassword = level1Passwords[Random.Range(0, level1Passwords.Length)]; 
                break;
            case 2:
                currentPassword = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                currentPassword = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Hint: " + currentPassword.Anagram());
        Terminal.WriteLine("Enter your password"); 
    }

    private void CheckPassword(string password)
    {
        if (password == currentPassword)
        {
            // User Wins
            Terminal.WriteLine("ACCESS GRANTED");
            DisplayWinScreen(); 
        } else
        {
            // User loses 
            Terminal.WriteLine("ACCESS DENIED");
            AskForPassword(); 
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward(); 
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /     //
  /     //
 /_____//
(_____(/
                "); 
                break;
            case 2:
                Terminal.WriteLine("You found the key!");
                Terminal.WriteLine(@"
              ______
 ___^/\^/\___/      \
/__________          |
\____________        |
             \______/  
                ");
                break;
            case 3:
                Terminal.WriteLine("Is this Snowden?!"); 
                break;
        }
    }
}

