using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // WARNING: None of this code is real. Do not attempt to run any of it.

    public gameObject player;
    public gameObject[] enemies;

    // I don't how HP will work for this game, so this will likely be changed
    public sumEnemyHP;

    private gameObject[] battlers;
    private gameObject turnIndex = 0;

    void Start()
    {
        // Receive list of desired enemies from InfoBank, then generate new gameObjects for each one
        sumEnemyHP = sum([enemy.HP for enemy in enemies]);
        battlers = [player, *enemies];
    }

    void Update() {
        // This code will run over several frames, so it might not belong in Update()

        while (player.HP > 0 || sumEnemyHP > 0) {
            // This runs a single turn, then measures HP and increments the turn index
            Turn(battlers[turnIndex]);
            sumEnemyHP = sum([enemy.HP for enemy in enemies])
            turnIndex = (turnIndex+1)%battlers.length;
        }
        // End battle here
    }

    void Turn(gameObject battler) {
        // Given any battler (player or enemy), run a turn for them, allowing them to attack their opponent
        if (gameObject.tag == "player") {
            // Let the player choose their attack, then have them use it against an enemy
        }
        else {
            // Have the enemy attack the player
        }
    }
}
