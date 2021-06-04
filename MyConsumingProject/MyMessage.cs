namespace MyConsumingProject
{
    public class MyMessage
    {
        private readonly string _name;
        public MyMessage(string name)
        {
            _name = name;
        }

        public string GetHelloMessage()
        {
            return $"{Messages.SayHello()} {_name}";
        }
    }
}
