namespace AbstractFactory
{
    public interface ILogger
    {
        void WriteToConsole(IProduct selected_product);
        void WriteToConsole(string text);
        void WriteToLogFile(IProduct selected_product);
    }
}