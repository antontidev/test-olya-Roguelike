using System.Collections.Generic;

public static class EnemyMap
{
    public static readonly List<CharacterStats> Enemies = new()
    {
        new CharacterStats(5, 1, 0, "Sprites/Goblin Sprite"),
        new CharacterStats(3, 1, 2, "Sprites/Scelet Sprite")
    };
}