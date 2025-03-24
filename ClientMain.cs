using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

class HelloWorldClient
{
    static void Main(string[] args)
    {
        string serviceUrl = "http://localhost:8080/HelloWorldService";

        ChannelFactory<IHelloWorld> factory = new ChannelFactory<IHelloWorld>(
            new BasicHttpBinding(),
            new EndpointAddress(serviceUrl));

        IHelloWorld proxy = factory.CreateChannel();
        string input;
        while (true) {
            Console.Write("Input: ");
            input = Console.ReadLine();

            string response = proxy.GetHelloWorldAsString(input);
            Console.WriteLine(response);
        }
        
        ((IClientChannel)proxy).Close();
        factory.Close();
    }
}