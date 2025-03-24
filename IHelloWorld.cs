using System.ServiceModel;

[ServiceContract]
public interface IHelloWorld
{
    [OperationContract]
    string GetHelloWorldAsString(string name);
}
