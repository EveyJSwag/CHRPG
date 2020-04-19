using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagerS : MonoBehaviour
{
    // *** BATTLE STATES ***
    public enum BattleState { DECIDETURN, PLAYERPARTYTURNSTART, PLAYERPARTYTURN,PARTYSELECTACTION, PARTYSELECTENEMY, PARTYATTACKSTART,PARTYATTACKEND,ENEMYPARTYTURN, ENEMYSELECTACTION, ENEMYATTACKSTART,ENEMYATTACKEND,WON, LOST}
    public BattleState state;
    private float moveSpeed = 30f;

    // **** PLAYER AND ENEMY GAME OBJECTS ****
    // *** PLAYER ***
    public GameObject player;
    private BattleChar player_properties;
    // *** ENEMY ***
    public GameObject enemy;
    private SpanEnemies enemy_properties;
    private GameObject enemyChosen;
    private BattleEnemy enemyChosen_properties;
    private int enemyChosenIndex = 0;

    // *** TURN QUEUE ***
    private GameObject[] turnQueue = new GameObject[6];
    private int turnQueueLength = 0;
    private int turnIndex;

    // *** UI OBJECTS *** //
    public GameObject UIController;
    UIController UI_properties;
    public GameObject damageDisplayer;
    DamageSpawner floating_damage_number;
    public GameObject victoryScreen;
    VictoryScreen victoryScreen_properties;
    private Vector3 end_text_location;
    
    GameObject cursor;
    GameObject abilityList;

    // UI OBJECTS, BUT USED FOR THE LOCATION OF CERTAIN BUTTONS
    private Text playerName;
    private Vector3 attackButton;
    private Vector3 abilitiesButton;
    private Vector3 itemsButton;
    private Vector3[] buttonArr;
    private int buttonSelectIndex;

    // **** MOVEMENT VARIABLES ****
    // *** PLAYER/PARTY ***
    private Vector3 player_original_position;
    private Vector3 travel_to;
    private float player_initial_start_time;
    private float player_travel_length;
    // ***     ENEMY    ***
    private Vector3 enemy_attack_pos;
    private GameObject currentEnemy;
    BattleEnemy currentEnemy_properties;
    private Vector3 enemy_original_position;
    private float enemy_initial_start_time;
    private float enemy_travel_length;

    //////////////////////////////////
    // EXP GAINED THROUGHOUT BATTLE //
    //////////////////////////////////
    private int battle_exp = 0;

    void Start()
    {
        // *** INITIALIZING PLAYER OBJECT ***
        player_properties = player.GetComponent<BattleChar>();

        // *** INITIALIZING ENEMY OBJECT[S]***
        enemy_properties = enemy.GetComponent<SpanEnemies>();

        // *** INITIALIZING UI OBJECTS[S]***
        UI_properties = UIController.GetComponent<UIController>();
        
        

        // *** THIS IS THE LOCATION OF THE PLAYER'S NAME... ***
        // *** WILL NEED SOMETHING FOR OTHER PARTY MEMBERS... ***
        //playerName = UIController.GetComponent<UIController>().charName;
        playerName = UI_properties.charName;

        // *** THIS IS USED THE MOVE FUNCTION ***
        // *** WILL PROBABLY NEED ONE FOR EACH PARTY MEMEBER ***
        player_original_position = player.transform.position;
        
        // *** THIS INDEX IS USED FOR WHAT BUTTON THE CURSOR SHOULD MOVE TO ***
        buttonSelectIndex = 0;

        // *** THIS FUNCTION WILL SPAWN BETWEEN 1-3 ENEMIES FOR THE PLAYER TO FIGHT ***
        enemy_properties.Spawn();
        
        /// **** THIS INITIALIZES THE 'TURN QUEUE' BASED ON THE SPEED OF THE GAME OBJECT ****
        /* ***HOW THIS FUNCTION WORKS***
         * initTurnQueue creates an array of game objects...
         * It sorts each object by their speed stat.
         * Fastest first, slowest last.
         */
        initTurnQueue();
        
        // *** THIS GETS THE LENGTH OF THE 'TURN QUEUE'... IT SHOULD PROBABLY BE IT'S OWN FUNCTION... ***
        for (int i = 0; i < turnQueue.Length; i++)
        {
            if (turnQueue[i] != null)
            {
                turnQueueLength++;
            }
        }

        // ***THIS CODE BLOCK FIGURES OUT WHO GOES FIRST***
        if (turnQueue[0].name == "JerryBattle")
        {
            state = BattleState.PLAYERPARTYTURNSTART;
        }
        else
        {
            state = BattleState.ENEMYPARTYTURN;
        }
        // ***THIS IS FOR THE DAMAGE NUMBERS THAT POP-UP***
        floating_damage_number = damageDisplayer.GetComponent<DamageSpawner>();

    }

    // *** MAIN GAME LOOP... NOTICE THERE'S ONLY ONE FUNCTION IN IT ***
    // *** GOD PROGRAMMER = ME ***
    // *** JK, I FUCKING SUCK AND HATE MYSELF ;) ***
    void Update()
    {
        turnManager();  
    }
    // JERRY NEEDS TO GO UP
    // ENEMY GO DOWN
    public void initTurnQueue() {
        //Place holder for when other party memebers are added
        int queueIndex = 0;
        int [] speedArray = new int[turnQueue.Length];
        for (int i = 0; i < enemy_properties.getSize(); i++) {
            turnQueue[i] = enemy_properties.getEnemy(i);
            speedArray[i] = (int)enemy_properties.getEnemy(i).GetComponent<BattleEnemy>().getEnemySpeed();
            queueIndex++;
        }
        turnQueue[queueIndex] = player;
        speedArray[queueIndex] = (int)player_properties.getPlayerSpeed();
        /// YES, THIS IS FUCKING BUBBLE SORT, DO NOT FUCKING ROAST ME
        /// FUCK
        for (int i = 0; i < queueIndex+1; i++) {
            for (int j = i; j < queueIndex; j++) {
                if (speedArray[i] < speedArray[j+1]) {
                    int temp = speedArray[j+1];
                    GameObject tempG = turnQueue[j+1];
                    speedArray[j + 1] = speedArray[i];
                    turnQueue[j + 1] = turnQueue[i];
                    speedArray[i] = temp;
                    turnQueue[i] = tempG;
                }
            }
        }
    }

    public void turnManager() {
        if (turnIndex >= turnQueueLength) {
            turnIndex = 0;
            Debug.Log("Enemies Left " + enemy_properties.getSize());
        }

        /////////////////
        // VICTORY !!! //
        /////////////////
        if (state == BattleState.WON) {
            //////////////////////////////////////////
            // Configure the victory screen here... //
            //////////////////////////////////////////
            Debug.Log(victoryScreen.transform.position);
            
        }

        /// *** THIS BLOCK WILL DECIDE WHO WILL GO NEXT... ***
        /// *** THIS WILL CHANGE LATER ONCE OTHER PARTY MEMBERS ARE ADDED ***
        if (state == BattleState.DECIDETURN)
        {
            if (turnQueue[turnIndex].name == "JerryBattle")
                state = BattleState.PLAYERPARTYTURNSTART;
            else
                state = BattleState.ENEMYPARTYTURN;
            if (enemy_properties.getSize() < 1)
            {
                state = BattleState.WON;
                Vector3 victoryScreenPos = new Vector3(player.transform.position.x + 13f, player.transform.position.y-4f);
                
                victoryScreen = Instantiate(victoryScreen, victoryScreenPos, Quaternion.identity);
                victoryScreen_properties = victoryScreen.GetComponent<VictoryScreen>();
                configureVictoryScreen();
            }
        }

        /*************************************************** 
        *******************#PLAYER TURN#********************
        ****************************************************/
        else if (state == BattleState.PLAYERPARTYTURNSTART)
        {
            Vector3 playerNamePos = new Vector3(playerName.transform.position.x + 3f, playerName.transform.position.y, 0f);
            cursor = UI_properties.insCursor(playerNamePos);
            state = BattleState.PLAYERPARTYTURN;
        }
        else if (state == BattleState.PLAYERPARTYTURN)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                Vector3 abilityListPos = new Vector3(playerName.transform.position.x + 5.8f, playerName.transform.position.y - 1.38f, 0f);
                abilityList = UI_properties.insAbilityMenu(abilityListPos);
                cursor.transform.position = initButtons()[0];
                state = BattleState.PARTYSELECTACTION;
                buttonArr = initButtons();
            }
        }
        else if (state == BattleState.PARTYSELECTACTION)
        {
            changeActionSelection(cursor, buttonArr, initEnemyArray()[0]);
        }
        else if (state == BattleState.PARTYSELECTENEMY)
        {
            changeEnemySelection(cursor, initEnemyArray(), BattleState.PARTYATTACKSTART);
            player_initial_start_time = Time.time;
            player_travel_length = Vector3.Distance(player.transform.position, initEnemyArray()[buttonSelectIndex]);

        }
        else if (state == BattleState.PARTYATTACKSTART)
        {
            // ***PLAYER MOVES TOWARDS THE ENEMY***
            move(player, player_original_position, travel_to, player_initial_start_time, player_travel_length);
            if (player.transform.position == travel_to)
            {
                state = BattleState.PARTYATTACKEND;
                enemyChosen_properties.takeDamage(player_properties.getAttack());
                floating_damage_number.insDam(enemyChosen, enemyChosen_properties.getDamageTaken());
                if (enemyChosen_properties.getHealth() <= 0)
                {
                    killEnemy(enemyChosen);
                }
                player_initial_start_time = Time.time;
            }
        }
        else if (state == BattleState.PARTYATTACKEND)
        {
            // ***PLAYER MOVES BACK TO ORIGINAL SPOT***
            move(player, travel_to, player_original_position, player_initial_start_time, player_travel_length);
            if (player.transform.position == player_original_position)
            {
                state = BattleState.DECIDETURN;
                turnIndex++;
            }
        }
        
        /*************************************************** 
        ****************************************************
        ****************************************************/

        /*************************************************** 
         *******************#ENEMY TURN#********************
         ***************************************************/
        else if (state == BattleState.ENEMYPARTYTURN)
        {
            currentEnemy = turnQueue[turnIndex];
            currentEnemy_properties = currentEnemy.GetComponent<BattleEnemy>();
            enemy_original_position = currentEnemy.transform.position;
            enemy_travel_length = Vector3.Distance(currentEnemy.transform.position, player.transform.position);
            state = BattleState.ENEMYSELECTACTION;
        }
        else if (state == BattleState.ENEMYSELECTACTION)
        {
            // **I'll put enemy abilites here later... but for now...**
            state = BattleState.ENEMYATTACKSTART;
            Vector3 modPlayerPos = player.transform.position;
            enemy_attack_pos = new Vector3(modPlayerPos.x + 0.2f, modPlayerPos.y - 2.8f);
            enemy_initial_start_time = Time.time;
        }
        else if (state == BattleState.ENEMYATTACKSTART)
        {
            move(currentEnemy, enemy_original_position, enemy_attack_pos, enemy_initial_start_time, enemy_travel_length);
            if (currentEnemy.transform.position == enemy_attack_pos)
            {
                player_properties.takeDamage(currentEnemy_properties.getAttack());
                floating_damage_number.insDam(player, player_properties.getDamageTaken());
                state = BattleState.ENEMYATTACKEND;
                enemy_initial_start_time = Time.time;
            }
        }
        else if (state == BattleState.ENEMYATTACKEND)
        {
            move(currentEnemy, enemy_attack_pos, enemy_original_position, enemy_initial_start_time, enemy_travel_length);
            if (currentEnemy.transform.position == enemy_original_position)
            {
                state = BattleState.DECIDETURN;
                turnIndex++;
            }
        }
        /*************************************************** 
        ****************************************************
        ****************************************************/
    }

    private void move(GameObject mover, Vector3 from, Vector3 to, float startTime, float distance) {
        /// THIS FUNCTION WILL MOVE ONE OBJECT TO ANOTHER...
        /// I USED THIS TO 'STREAMLINE' USING LERP
        float distanceTravled = (Time.time - startTime) * moveSpeed;
        mover.transform.position = Vector3.Lerp(from, to, distanceTravled / distance);
    }

    private void changeActionSelection(GameObject cursor, Vector3[] positionArr, Vector3 enemyLocation) {
        /// THIS FUNCTION IS FOR CHANGING THE POSITION OF THE CURSOR THAT SELECTS THE PLAYER'S ACTION...
        /// THE CURSOR IS JUST FOR SHOW, BUT THE UP AND DOWN ARROWS CHANGE THE ACTION THAT IS SELECTED.
        
        //// ** BUTTON SELECT INDEX GUIDE **
        //   ATTACK = 0
        //   ABILITY = 1
        //   ITEMS = 2
        //// *******************************

        /// MOVE CURSOR UP OR DOWN //////
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            buttonSelectIndex--;
            if (buttonSelectIndex < 0)
                buttonSelectIndex = positionArr.Length - 1;
            cursor.transform.position = positionArr[buttonSelectIndex];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            buttonSelectIndex++;
            if (buttonSelectIndex == positionArr.Length)
                buttonSelectIndex = 0;
            cursor.transform.position = positionArr[buttonSelectIndex];
        }
        ////////////////////////////////
        
        /// ONCE ENTER IS PRESSED THE CURSOR WILL CHANGE POSITION
        //  *(NEED TO ADD SOMETHING FOR ABILITIES AND ITEMS AS WELL)* 
        else if (Input.GetKeyUp(KeyCode.Return) && buttonSelectIndex == 0) {
            state = BattleState.PARTYSELECTENEMY;
            cursor.transform.position = enemyLocation;
            buttonSelectIndex = 0;
        }
        /////////////////////////////////////////////////////////
    }
    private void changeEnemySelection(GameObject cursor, Vector3[] positionArr, BattleState stateToChangeTo) {
        /// THIS FUNCTION IS FOR CHANGING THE POSITION OF THE CURSOR THAT SELECTS THE ENEMY TO ATTACK...
        /// THE CURSOR IS JUST FOR SHOW, BUT THE UP AND DOWN ARROWS CHANGE THE ACTION THAT IS SELECTED.

        /// MOVE CURSOR UP OR DOWN //////
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            buttonSelectIndex--;
            if (buttonSelectIndex < 0)
                buttonSelectIndex = positionArr.Length - 1;
            cursor.transform.position = positionArr[buttonSelectIndex];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            buttonSelectIndex++;
            if (buttonSelectIndex == positionArr.Length)
                buttonSelectIndex = 0;
            cursor.transform.position = positionArr[buttonSelectIndex];
        }
        ////////////////////////////////
        /// ONCE ENTER IS PRESSED THE CURSOR WILL BE DESTROYED AND THE ENEMY WILL BE SELECTED
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            state = stateToChangeTo;
            enemyChosen = enemy.GetComponent<SpanEnemies>().getEnemy(buttonSelectIndex);
            enemyChosen_properties = enemyChosen.GetComponent<BattleEnemy>();
            travel_to = enemyChosen.transform.position;
            travel_to = new Vector3(travel_to.x, travel_to.y+2.5f);
            enemyChosenIndex = buttonSelectIndex;
            Debug.Log("enemyChosen: " + buttonSelectIndex);
            buttonSelectIndex = 0;
            Destroy(cursor);
            Destroy(abilityList);
        }
        /////////////////////////////////////////////////////////
    }
    private Vector3[] initButtons() {
        // *** POORLY NAMED FUNCTION... ***
        // *** THIS RETURNS AN ARRAY OF VECTOR3's FOR THE CURSOR TO POINT TO ***
        
        // ** THESE ARE THE ACTUAL BUTTONS AND THEIR 'UNMODIFIED' POSITIONS... **
        attackButton = abilityList.transform.GetChild(0).GetChild(0).position;
        abilitiesButton = abilityList.transform.GetChild(0).GetChild(1).position;
        itemsButton = abilityList.transform.GetChild(0).GetChild(2).position;

        // ** THESE ARE 'MODIFIED' POSITIONS BECAUSE THE ORIGINAL POSITIONS ARE KINDA WONKY... **
        Vector3 modAttackButton = new Vector3 (attackButton.x+2f, attackButton.y, attackButton.z);
        Vector3 modAbilitiesButton = new Vector3(abilitiesButton.x+2f, abilitiesButton.y, abilitiesButton.z);
        Vector3 modItemsButton = new Vector3(itemsButton.x+2f, itemsButton.y, itemsButton.z);

        Vector3 [] positionArr = new Vector3[]  {modAttackButton, modAbilitiesButton, modItemsButton};

        return positionArr;
    }
    private Vector3[] initEnemyArray () {
        // ***ESSENTIALLY DOES THE SAME THING AS ABOVE EXCEPT WITH ENEMIES***
        int enemy_amount = enemy.GetComponent<SpanEnemies>().getSize();
        SpanEnemies enemy_x = enemy.GetComponent<SpanEnemies>();
        Vector3[] enemyPosArr = new Vector3[enemy_amount];
        for (int i = 0; i < enemy_amount; i++) {
            enemyPosArr[i] = enemy_x.getEnemy(i).transform.position;
        }
        return enemyPosArr;
    }

    public void killEnemy(GameObject enemyToKill) {
        
        SpanEnemies enemyToKill_properties = enemyToKill.GetComponent<SpanEnemies>();
        int enemyToKill_speed = (int)enemy_properties.getEnemy(enemyChosenIndex).GetComponent<BattleEnemy>().getEnemySpeed();

        /////////////
        // Get EXP //
        /////////////
        int enemyToKill_exp = enemy_properties.getEnemy(enemyChosenIndex).GetComponent<BattleEnemy>().getExpDroped();
        player_properties.gainExp(enemyToKill_exp);
        battle_exp += enemyToKill_exp;
        
        ///////////////////////////////////////
        // Remove enemy and reset turn queue //
        ///////////////////////////////////////
        enemy_properties.removeEnemy(enemyChosenIndex);
        turnQueue = new GameObject[enemy_properties.getSize()+1];
        turnQueueLength--;

        /////////////////////////////////////////////////////////////////
        // This is done if the enemy's speed is high than the player's //
        /////////////////////////////////////////////////////////////////
        if (enemyToKill_speed > player_properties.getPlayerSpeed())
            turnIndex--;
        initTurnQueue();
        Debug.Log(turnIndex);
        Destroy(enemyToKill);
    }

    private void configureVictoryScreen()
    {
        /////////////////////////////////////////
        // Fill in text for who is leveling up //
        /////////////////////////////////////////
        victoryScreen_properties.set_exp_text("Jerry: ");
        victoryScreen_properties.set_exp_text_int(battle_exp);
        ////////////////////////////////
        // If the player levels up... //
        ////////////////////////////////
        if (player_properties.level < player_properties.calculateLevel())
        {
            victoryScreen_properties.set_lvl_text(player_properties.level, player_properties.calculateLevel());
            player_properties.level = player_properties.calculateLevel();
        }
        ///////////////////////////////////////////////////////////////////////////
        // Spawn the cursor to the end button so player can go back to overworld //
        ///////////////////////////////////////////////////////////////////////////
        end_text_location = victoryScreen.transform.GetChild(0).transform.GetChild(4).transform.position;
        end_text_location = new Vector3(end_text_location.x + 1f, end_text_location.y);
        cursor = UI_properties.insCursor(end_text_location);
        


    }
}