using System.Collections.Generic;

public static class CardMap
{
    public static readonly List<CardStats> Cards = new()
    {
        // new CardStats(1,0,0,0, "Легкая\nхилка", "", "Cards/DefaultCardImage"),
        // new CardStats(1,0,0,0, "Легкая\nхилка", "", "Cards/DefaultCardImage"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "Cards/DefaultCardImage"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "Cards/DefaultCardImage"),
        new CardStats(1,0,0,0, "Легкая\nхилка", "", "Cards/DefaultCardImage"),
        new CardStats(2,0,0,0, "Хилка", "", "Cards/DefaultCardImage"),
        new CardStats(2,0,0,0, "Хилка", "", "Cards/DefaultCardImage"),
        // new CardStats(2,0,0,0, "Хилка", "", "Cards/DefaultCardImage"),
        new CardStats(3,0,0,0, "Сильная\nхилка", "", "Cards/DefaultCardImage"),
        
        new CardStats(0,1,0,0, "Слабый\nудар", "", "Cards/DefaultCardImage"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "Cards/DefaultCardImage"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "Cards/DefaultCardImage"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "Cards/DefaultCardImage"),
        new CardStats(0,1,0,0, "Слабый\nудар", "", "Cards/DefaultCardImage"),
        new CardStats(0,2,0,0, "Удар", "", "Cards/DefaultCardImage"),
        new CardStats(0,2,0,0, "Удар", "", "Cards/DefaultCardImage"),
        new CardStats(0,2,0,0, "Удар", "", "Cards/DefaultCardImage"),
        new CardStats(0,3,0,0, "Сильный\nудар", "", "Cards/DefaultCardImage"),
        
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "Cards/DefaultCardImage"),
        new CardStats(0,0,1,0, "Тонкая\nзащита", "", "Cards/DefaultCardImage"),
        new CardStats(0,0,1,0, "Тонкая\nзащита", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,1,0, "Тонкая\nзащита", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,2,0, "Защита", "", "Cards/DefaultCardImage"),
        new CardStats(0,0,2,0, "Защита", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,2,0, "Защита", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,3,0, "Крепкая\nзащита", "", "Cards/DefaultCardImage"),
        
        new CardStats(0,0,0,2, "Пара карт", "", "Cards/DefaultCardImage"),
        new CardStats(0,0,0,2, "Пара карт", "", "Cards/DefaultCardImage"),
        // new CardStats(0,0,0,2, "Пара карт", "", "Cards/DefaultCardImage"),
        new CardStats(0,0,0,3, "Стопка карт", "", "Cards/DefaultCardImage")
    };
}