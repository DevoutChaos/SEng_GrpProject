﻿using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{

    //Declarations
    [Header("Abilties Obtained (Do Not Edit In Unity)")]
    //Change to Array?
    public string[] abilityNames = new string[7];

    [Header("Ability Ranks (Do Not Edit In Unity)")]
    //Change to Array?
    public int[] abRanks = new int[7] {0, 0, 0, 0, 0, 0, 0};

    public int[] levelReq = new int[60];

    [Header("Abilties Equipped (Do Not Edit In Unity)")]
    public string equip1 = "";
    public string equip2 = "";
    public string equip3 = "";

    [Header("Players Experience (Do Not Edit In Unity)")]
    public int playerExp = 0;
    public int playerLvl = 2;

    [Header("Players Score (Do Not Edit In Unity)")]
    public int playerScore = 0;

    [Header("Players Class (Do Not Edit In Unity)")]
    public string playerClass = "";

    [Header("Players Possible Specs (Do Not Edit In Unity)")]
    public string spec1 = "";
    public string spec2 = "";

    [Header("Players Spec Levels (Do Not Edit In Unity)")]
    public int spec1Lvl = 1;
    public int spec2Lvl = 1;

    [Header("Players Equipped Spec (Do Not Edit In Unity)")]
    public string setSpec = "";

    [Header("Highest Stage Reached (Do Not Edit In Unity)")]
    public int stageNo = 1;

    // Use this for initialization
    void Start()
    {
        fillLevelReq();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "MainMenu")
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        /****Updates available apecs based on class****/
        if (playerClass == "Mage")
        {
            spec1 = "Pyromancer";
            spec2 = "Nethermancer";
        }
        else if (playerClass == "Warrior")
        {
            spec1 = "Bloodthirster";
            spec2 = "Guardian";
        }
        else if (playerClass == "Ranger")
        {
            spec1 = "Archer";
            spec2 = "Bandit";
            //setSpec = "Archer";
        }

        /****Updates available abilities based on spec****/
        if (setSpec == "Pyromancer")
        {
            abilityNames = new string[] {"Fireball", "Inferno", "Blazing Radiance", "Spontaneous Combustion", "Ignition", "Flame Armour"};
            PyroUpdate();
        }
        else if (setSpec == "Nethermancer")
        {
            abilityNames = new string[] { "Arcane Mark", "Arcane Tempest", "Nether Bomb", "Blink Burst", "Nether Fury", "Mage Armour" };
            NetherUpdate();
        }
        else if (setSpec == "Bloodthirster")
        {
            abilityNames = new string[] { "Bloodthirsty", "Swinging Strike", "Seek the Weak", "Long Strike", "Cleaving Strike", "Quenched Thirst" };
            BTUpdate();
        }
        else if (setSpec == "Bandit")
        {
            abilityNames = new string[] { "Backstab", "Bloodlust", "Afterimage", "Poisoned Blade", "Conceal", "Frenzy", "Kiss of Death" };
            BanditUpdate();
        }
        else if (setSpec == "Archer")
        {
            abilityNames = new string[] { "Powershot", "Sharp Eye", "Corkscrew", "Double Shot", "Explosive Shot", "Arrow Rain" };
            ArcherUpdate();
        }
        else if (setSpec == "Guradian")
        {
            abilityNames = new string[] { "Energy Sap", "Seismic Smash", "Soul Shield", "Vigorous Revenge", "Unbreakable Resolve", "Spiteful Smack" };
            GuardianUpdate();
        }

        /****Sets the players level according to their experience****/
        playerLevel();
    }
    public void MageSelect()
    {
        playerClass = "Mage";
		playerExp = 500;
		Application.LoadLevel("levelUpMenu");
    }

    public void RangerSelect()
    {
        playerClass = "Ranger";
        /****Temporary code for TESTING ONLY****/
        playerExp = 500;
        Application.LoadLevel("levelUpMenu");
        /****End of temporary code****/
        //Application.LoadLevel("TutorialStage");
    }

    public void WarriorSelect()
    {
        playerClass = "Warrior";
		playerExp = 500;
		Application.LoadLevel("levelUpMenu");;
    }

    void fillLevelReq()
    {
        int expReq = 0;
        for (int i = 0; i < 60; i++)
        {
            expReq += 100;            
            levelReq[i] = expReq;
        }
    }

    void playerLevel()
    {
        for (int i = 59; i > 0; i--)
        {
            if (playerExp >= levelReq[i])
            {
                playerLvl = (i + 1);
                break;
            }
        }
    }

    //Mage Spec 1
    void PyroUpdate()
    {
        switch (spec1Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;
        }
    }

    //Mage Spec 2
    void NetherUpdate()
    {
        switch (spec2Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;
        }

    }

    //Warrior Spec 1
    void BTUpdate()
    {
        switch (spec1Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;
        }
    }

    //Warrior Spec 2
    void GuardianUpdate()
    {
        switch (spec2Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;
        }
    }

    //Ranger Spec 1
    void ArcherUpdate()
    {
        switch (spec1Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 5;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 5;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                break;
        }
    }

    //Ranger Spec 2
    void BanditUpdate()
    {
        switch (spec2Lvl)
        {
            case 30:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 5;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 29:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 5;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 28:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 5;
                abRanks[4] = 4;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 27:
                abRanks[0] = 5;
                abRanks[1] = 5;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 26:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 4;
                abRanks[5] = 5;
                break;

            case 25:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 4;
                abRanks[4] = 3;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 24:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 4;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 23:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                abRanks[6] = 1;
                break;

            case 22:
                abRanks[0] = 5;
                abRanks[1] = 4;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                abRanks[6] = 0;
                break;

            case 21:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 4;
                abRanks[6] = 0;
                break;

            case 20:
                abRanks[0] = 5;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                abRanks[6] = 0;
                break;

            case 19:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 3;
                abRanks[5] = 3;
                abRanks[6] = 0;
                break;

            case 18:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 3;
                abRanks[4] = 2;
                abRanks[5] = 3;
                abRanks[6] = 0;
                break;

            case 17:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 3;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                abRanks[6] = 0;
                break;

            case 16:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 3;
                abRanks[6] = 0;
                break;

            case 15:
                abRanks[0] = 4;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 14:
                abRanks[0] = 3;
                abRanks[1] = 3;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 13:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 2;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 12:
                abRanks[0] = 3;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 11:
                abRanks[0] = 2;
                abRanks[1] = 2;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 10:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 2;
                abRanks[4] = 1;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 9:
                abRanks[0] = 2;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 8:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 2;
                abRanks[6] = 0;
                break;

            case 7:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 1;
                abRanks[4] = 1;
                abRanks[5] = 1;
                abRanks[6] = 0;
                break;

            case 6:
                abRanks[0] = 1;
                abRanks[1] = 1;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                abRanks[6] = 0;
                break;

            case 5:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 2;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                abRanks[6] = 0;
                break;

            case 4:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 1;
                abRanks[6] = 0;
                break;

            case 3:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 1;
                abRanks[5] = 0;
                abRanks[6] = 0;
                break;

            case 2:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 1;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                abRanks[6] = 0;
                break;

            case 1:
                abRanks[0] = 1;
                abRanks[1] = 0;
                abRanks[2] = 0;
                abRanks[3] = 0;
                abRanks[4] = 0;
                abRanks[5] = 0;
                abRanks[6] = 0;
                break;
        }
    }
}
