using System;
using System.ServiceModel;

class HelloWorldClient
{
    static void Main(string[] args)
    {
        string serviceUrl = "http://localhost:8080/HelloWorldService";

        ChannelFactory<IHelloWorld> factory = new ChannelFactory<IHelloWorld>(
            new BasicHttpBinding(),
            new EndpointAddress(serviceUrl));

        IHelloWorld proxy = factory.CreateChannel();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        string response = proxy.GetHelloWorldAsString(name);
        Console.WriteLine("Server Response: " + response);

        ((IClientChannel)proxy).Close();
        factory.Close();
    }
}