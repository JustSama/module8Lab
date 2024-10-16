using System;

public abstract class Beverage
{
    
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    
    private void BoilWater()
    {
        Console.WriteLine("Кипячение воды...");
    }

    
    private void PourInCup()
    {
        Console.WriteLine("Наливание в чашку...");
    }

    
    protected abstract void Brew();
    protected abstract void AddCondiments();
}

public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание чая...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление лимона...");
    }
}

public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание кофе...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление сахара и молока...");
    }
}

public class HotChocolate : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание горячего шоколада...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление взбитых сливок...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Beverage tea = new Tea();
        Console.WriteLine("Приготовление чая:");
        tea.PrepareRecipe();

        Console.WriteLine();

        
        Beverage coffee = new Coffee();
        Console.WriteLine("Приготовление кофе:");
        coffee.PrepareRecipe();

        Console.WriteLine();

        
        Beverage hotChocolate = new HotChocolate();
        Console.WriteLine("Приготовление горячего шоколада:");
        hotChocolate.PrepareRecipe();
    }
}
