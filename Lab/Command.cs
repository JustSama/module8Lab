using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On()
    {
        Console.WriteLine("Свет включен.");
    }

    public void Off()
    {
        Console.WriteLine("Свет выключен.");
    }
}

public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

public class Television
{
    public void On()
    {
        Console.WriteLine("Телевизор включен.");
    }

    public void Off()
    {
        Console.WriteLine("Телевизор выключен.");
    }
}

public class TelevisionOnCommand : ICommand
{
    private Television _tv;

    public TelevisionOnCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.On();
    }

    public void Undo()
    {
        _tv.Off();
    }
}

public class TelevisionOffCommand : ICommand
{
    private Television _tv;

    public TelevisionOffCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.Off();
    }

    public void Undo()
    {
        _tv.On();
    }
}

public class RemoteControl
{
    private ICommand _onCommand;
    private ICommand _offCommand;

    public void SetCommands(ICommand onCommand, ICommand offCommand)
    {
        _onCommand = onCommand;
        _offCommand = offCommand;
    }

    public void PressOnButton()
    {
        if (_onCommand != null)
            _onCommand.Execute();
        else
            Console.WriteLine("Команда включения не назначена.");
    }

    public void PressOffButton()
    {
        if (_offCommand != null)
            _offCommand.Execute();
        else
            Console.WriteLine("Команда выключения не назначена.");
    }

    public void PressUndoButton()
    {
        if (_onCommand != null)
            _onCommand.Undo();
        else
            Console.WriteLine("Команда отмены не назначена.");
    }
}

public class MacroCommand : ICommand
{
    private List<ICommand> _commands;

    public MacroCommand(List<ICommand> commands)
    {
        _commands = commands;
    }

    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        for (int i = _commands.Count - 1; i >= 0; i--)
        {
            _commands[i].Undo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Light livingRoomLight = new Light();
        Television tv = new Television();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);
        ICommand tvOn = new TelevisionOnCommand(tv);
        ICommand tvOff = new TelevisionOffCommand(tv);

        RemoteControl remote = new RemoteControl();

        remote.SetCommands(lightOn, lightOff);
        Console.WriteLine("Управление светом:");
        remote.PressOnButton();
        remote.PressOffButton();
        remote.PressUndoButton();

        remote.SetCommands(tvOn, tvOff);
        Console.WriteLine("\nУправление телевизором:");
        remote.PressOnButton();
        remote.PressOffButton();

        Console.WriteLine("\nИспользование макрокоманды:");
        List<ICommand> macroCommands = new List<ICommand> { lightOn, tvOn };
        ICommand macroCommand = new MacroCommand(macroCommands);
        macroCommand.Execute();
        macroCommand.Undo();
    }
}
