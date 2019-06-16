using PublisherSubscriber;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();

        var numberOfSubscribers = 0;
        while (numberOfSubscribers.Equals(0))
        {
            numberOfSubscribers = GetNumberOfSubscriber();
        }

        List<Subscribers> subscribers = new List<Subscribers>();
        for(int i = 1; i <= numberOfSubscribers; i++)
        {
            Subscribers subscriber = new Subscribers
            {
                Id = i
            };
            subscribers.Add(subscriber);
        }

        if(subscribers.Count > 0)
        {
            var message = string.Empty;

            while(message.Equals(string.Empty))
            {
                message = SetPublisherMessage();
            }

            foreach(var subscriber in subscribers)
            {
                publisher.OnChange += () => publisher.ConfigureMessage(subscriber.Id, message);
            }
            publisher.Publish();
        }
        else
        {
            Console.WriteLine("No subscribers found");
        }

        Console.WriteLine("Press enter to terminate!");
        Console.ReadLine();
    }

    private static int GetNumberOfSubscriber()
    {
        Console.Write("Number of subscriber: ");
        var numberOfSubscribers = Console.ReadLine();

        int convertedNumberOfSubscriber = 0;
        if (int.TryParse(numberOfSubscribers, out convertedNumberOfSubscriber))
        {
            if(convertedNumberOfSubscriber.Equals(0))
                Console.WriteLine("Input must be greater than 0");
            
            return convertedNumberOfSubscriber;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return convertedNumberOfSubscriber;
        }
    }

    private static string SetPublisherMessage()
    {
        Console.Write("Please key-in your data:");
        var message = Console.ReadLine();

        if(string.IsNullOrEmpty(message))
        {
            Console.WriteLine("Invalid input");
        }
        return message;
    }
}