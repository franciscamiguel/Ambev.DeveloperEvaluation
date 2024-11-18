namespace Ambev.DeveloperEvaluation.MessageBroker.Common;

public interface IResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}