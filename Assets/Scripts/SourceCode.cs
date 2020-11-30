using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceCode
{
    // public const Int32 BUFFER_SIZE = 512; // Unmodifiable
    // public static String FILE_NAME = "Output.txt"; // Modifiable
    // public static readonly String CODE_PREFIX = "US-"; // Unmodifiable

    ////////////__PLAYER__\\\\\\\\\\\\
    public static float walkSpeed = 6f;
    public static float lifePoints = 100;
    public static int playerLevel = 1;
    public static int playerExp = 0;
    public static int playerGold = 0;

    //Basic Attack Information\\
    public static float basicAttackDMG = 10;
    public static float basicAttackCD = 1f;
    public static float basicAttackTimer = 0f;

    //Strong Attack Information\\
    public static float strongAttackDMG = 20;
    public static float strongAttackCD = 3f;
    public static float strongAttackTimer = 0f;

    //Shield Defense Information\\
    public static float percentageDefense;
    public static float shieldCD = 2f;
    public static float shieldDefenseTimer = 0f;

    //Recieve damage\\
    //Public Hit Information\\
    //public float hitCd;
    //public float hitTimer = 0.3f;


    ////////////__ARCHER__\\\\\\\\\\\\
    //Behavior\\
    public static float archerSpeed = 3f;
    public static float archerStoppingDistance = 6f;
    public static float archerRetreaDistance = 4f;
    public static float archerVisionDistance = 8f;

    //Details of Enemy\\
    public static float archerLife = 20;
    public static float projectileDamage = 10;
    public static float archerGold;
    public static float archerExp;
    public static float archerLevel;

    //Control of shots\\
    public static float timeBtwShots = 2f;
    public static float startTimeBtwShots = 1f;

    ////////////__SOLDIER__\\\\\\\\\\\\
    //Behavior
    public static float soldierSpeed = 3f;
    public static float soldierStoppingDistance = 2f;
    public static float soldierRunDistance = 4f;
    public static float soldierVisionDistance = 4f;

    //Control of shots
    public static float timeBtwAttacks = 4f;
    public static float startTimeBtwAttacks = 2f;

    //Details of Enemy
    public static float soldierLife = 10;
    public static float soldierCollisionDamage = 2f;
    public static float soldierDamage;
    public static int soldierGold;
    public static int soldierExp;
    public static int soldierLevel;



    ////////////__FINAL_BOSS__\\\\\\\\\\\\
    public static float finalBossSpeed = 2f;

    //Control of Attacks
    public static float finalBossTimeBtwAttacks = 1f;
    public static float finalBossStartTimeBtwAttacks = 2f;

    //Details of Enemy
    public static float finalBossLife = 40F;
    public static float finalBossTouchDamage = 2f;
    public static float finalBossAttackDamage = 10f;
    public static float finalBossGold = 0f;
    public static float finalBossEXP = 0f;

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
