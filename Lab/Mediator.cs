using System;
using System.Collections.Generic;


public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
    void RegisterColleague(Colleague colleague);
}


public abstract class Colleague
{
    protected IMediator _mediator;

    public Colleague(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void ReceiveMessage(string message);
}


public class ChatMediator : IMediator
{
    private List<Colleague> _colleagues;

    public ChatMediator()
    {
        _colleagues = new List<Colleague>();
    }

    public void RegisterColleague(Colleague colleague)
    {
        _colleagues.Add(colleague);
    }

    public void SendMessage(string message, Colleague sender)
    {
        foreach (var colleague in _colleagues)
        {
            if (colleague != sender)
            {
                colleague.ReceiveMessage(message);
            }
        }
    }
}

public class User : Colleague
{
    private string _name;

    public User(IMediator mediator, string name) : base(mediator)
    {
        _name = name;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{_name} отправляет сообщение: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name} получил сообщение: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        ChatMediator chatMediator = new ChatMediator();

        
        User user1 = new User(chatMediator, "Алиса");
        User user2 = new User(chatMediator, "Боб");
        User user3 = new User(chatMediator, "Чарли");

       
        chatMediator.RegisterColleague(user1);
        chatMediator.RegisterColleague(user2);
        chatMediator.RegisterColleague(user3);

        
        user1.Send("Привет всем!");
        user2.Send("Привет, Алиса!");
        user3.Send("Всем привет!");
    }
}
