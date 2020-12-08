using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceCode
{
    // public const Int32 BUFFER_SIZE = 512; // Unmodifiable
    // public static String FILE_NAME = "Output.txt"; // Modifiable
    // public static readonly String CODE_PREFIX = "US-"; // Unmodifiable

    ////////////////////////__PLAYER__\\\\\\\\\\\\\\\\\\\\\\\\
    public static float walkSpeed = 6f;
    public static int lifePoints = 100;
    public static int maxLifePoints = 100;
    public static int playerLevel = 1;
    public static int playerExp = 0;
    public static int playerExpToNextLevel = 0;
    public static int playerGold = 0;

    //Basic Attack Information\\
    public static int basicAttackDMG = 5;
    public static float basicAttackCD = 1f;
    public static float basicAttackTimer = 0f;

    //Strong Attack Information\\
    public static int strongAttackDMG = 10;
    public static float strongAttackCD = 5f;
    public static float strongAttackTimer = 0f;
    

    //Shield Defense Information\\
    public static float percentageDefense = 0;
    public static float shieldCD = 0f;
    public static float shieldDefenseTimer = 0f;
    public static bool blockInstantiate = false;

    //Recieve damage\\
    //Public Hit Information\\
    //public float hitCd;
    //public float hitTimer = 0.3f;


    ////////////////////////__ARCHER__\\\\\\\\\\\\\\\\\\\\\\\\
    //Behavior\\
    public static float archerSpeed = 2f;
    public static float archerStoppingDistance = 6f;
    public static float archerRetreaDistance = 4f;
    public static float archerVisionDistance = 8f;

    //Details of Enemy\\
    public static float archerLife = 20;
    public static int projectileDamage = 10;
    public static int archerGold = 10;
    public static int archerExp = 10;
    public static int archerLevel;

    //Control of shots\\
    public static float timeBtwShots = 2f;
    public static float startTimeBtwShots = 1f;


    ////////////////////////__SOLDIER__\\\\\\\\\\\\\\\\\\\\\\\\
    //Behavior
    public static float soldierSpeed = 3f;
    public static float soldierStoppingDistance = 2f;
    public static float soldierRunDistance = 4f;
    public static float soldierVisionDistance = 4f;

    //Control of shots
    public static float timeBtwAttacks = 4f;
    public static float startTimeBtwAttacks = 2f;

    //Details of Enemy
    public static int soldierLife = 10;
    public static int soldierCollisionDamage = 2;
    public static int soldierDamage = 10;
    public static int soldierGold = 10;
    public static int soldierExp = 5;
    public static int soldierLevel;

    ////////////////////////__SLIME_KING__\\\\\\\\\\\\\\\\\\\\\\\\

    ////////////////////////__ARCHER_KING__\\\\\\\\\\\\\\\\\\\\\\\\

    ////////////////////////__FINAL_BOSS__\\\\\\\\\\\\\\\\\\\\\\\\
    public static float finalBossSpeed = 2f;

    //Control of Attacks
    public static float finalBossTimeBtwAttacks = 1f;
    public static float finalBossStartTimeBtwAttacks = 2f;

    //Details of Enemy
    public static int finalBossLife = 40;
    public static int finalBossTouchDamage = 2;
    public static int finalBossAttackDamage = 10;
    public static int finalBossGold = 9;
    public static int finalBossEXP = 20;

    /*
      ⣾⣿⠿⠿⠶⠿⢿⣿⣿⣿⣿⣦⣤⣄⢀⡅⢠⣾⣛⡉⠄⠄⠄⠸⢀⣿⠄
      ⢀⡋⣡⣴⣶⣶⡀⠄⠄⠙⢿⣿⣿⣿⣿⣿⣴⣿⣿⣿⢃⣤⣄⣀⣥⣿⣿⠄
      ⢸⣇⠻⣿⣿⣿⣧⣀⢀⣠⡌⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠿⣿⣿⣿⠄
      ⢸⣿⣷⣤⣤⣤⣬⣙⣛⢿⣿⣿⣿⣿⣿⣿⡿⣿⣿⡍⠄⠄⢀⣤⣄⠉⠋⣰
      ⣖⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⢇⣿⣿⡷⠶⠶⢿⣿⣿⠇⢀⣤
      ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⡇⣿⣿⣿⣿⣿⣿⣷⣶⣥⣴⣿⡗
      ⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠄
      ⣦⣌⣛⣻⣿⣿⣧⠙⠛⠛⡭⠅⠒⠦⠭⣭⡻⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠄
      ⣿⣿⣿⣿⣿⣿⣿⡆⠄⠄⠄⠄⠄⠄⠄⠄⠹⠈⢋⣽⣿⣿⣿⣿⣵⣾⠃⠄
      ⣿⣿⣿⣿⣿⣿⣿⣿⠄⣴⣿⣶⣄⠄⣴⣶⠄⢀⣾⣿⣿⣿⣿⣿⣿⠃⠄⠄
      ⠈⠻⣿⣿⣿⣿⣿⣿⡄⢻⣿⣿⣿⠄⣿⣿⡀⣾⣿⣿⣿⣿⣛⠛⠁⠄⠄⠄
      ⠄⠄⠈⠛⢿⣿⣿⣿⠁⠞⢿⣿⣿⡄⢿⣿⡇⣸⣿⣿⠿⠛⠁⠄⠄⠄⠄⠄
      ⠄⠄⠄⠄⠄⠉⠻⣿⣿⣾⣦⡙⠻⣷⣾⣿⠃⠿⠋⠁⠄⠄⠄⠄⠄⢀⣠⣴
      ⣿⣶⣶⣮⣥⣒⠲⢮⣝⡿⣿⣿⡆⣿⡿⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣠
      It works senpai
  */
}
