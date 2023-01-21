using System.Collections.Generic;

public static class CardMap
{
    public static readonly List<CardStats> Cards = new()
    {
        // new CardStats(1,0,0,0, "Легкая\nхилка", "", "catbomber"),
        // new CardStats(1,0,0,0, "Легкая\nхилка", "", "catbomber"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "catbomber"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "catbomber"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "catbomber"),
        new CardStats(2,0,0,0, "Хилка", "", "catbomber"),
        new CardStats(2,0,0,0, "Хилка", "", "catbomber"),
        // new CardStats(2,0,0,0, "Хилка", "", "catbomber"),
        new CardStats(3,0,0,0, "Сильная\nхилка", "", "catbomber"),
        
        new CardStats(0,1,0,0, "Слабый\nудар", "", "catbomber"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "catbomber"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "catbomber"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "catbomber"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "catbomber"),
        new CardStats(0,2,0,0, "Удар", "", "catbomber"),
        new CardStats(0,2,0,0, "Удар", "", "catbomber"),
        new CardStats(0,2,0,0, "Удар", "", "catbomber"),
        new CardStats(0,3,0,0, "Сильный\nудар", "", "catbomber"),
        
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "catbomber"),
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "catbomber"),
        new CardStats(0,0,1,0, "Тонкая\nзащита", "", "catbomber"),
        new CardStats(0,0,1,0, "Тонкая\nзащита", "", "catbomber"),
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "catbomber"),
        // new CardStats(0,0,2,0, "Защита", "", "catbomber"),
        new CardStats(0,0,2,0, "Защита", "", "catbomber"),
        // new CardStats(0,0,2,0, "Защита", "", "catbomber"),
        // new CardStats(0,0,3,0, "Крепкая\nзащита", "", "catbomber"),
        
        new CardStats(0,0,0,2, "Пара карт", "", "catbomber"),
        new CardStats(0,0,0,2, "Пара карт", "", "catbomber"),
        // new CardStats(0,0,0,2, "Пара карт", "", "catbomber"),
        new CardStats(0,0,0,3, "Стопка карт", "", "catbomber")
    };
}