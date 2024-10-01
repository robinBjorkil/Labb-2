﻿

using System.Security.Cryptography.X509Certificates;

public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public abstract void Update()
    {

    }
}

// lägger till funktionalitet som är specifik för fiender.

// Även Enemy är abstrakt, då vi inte vill att man ska kunna instansiera ospecifika “fiender”.

// Alla riktiga fiender ärver av denna klass. Enemy ska ha properties för namn
// (t.ex snake/rat), hälsa (HP),
//
// samt AttackDice och DefenceDice av typen Dice
// (mer om detta längre ner). Den ska även ha en abstrakt Update-metod,
// som alltså inte implementeras i denna klass, men som kräver att alla som ärver av klassen
// implementerar den. Vi vill alltså kunna anropa Update-metoden på alla fiender och
// sedan sköter de olika subklasserna hur de uppdateras (till exempel olika förflyttningsmönster).