namespace Vitec.UserEvent
{
    public interface IProCodeExample
    {
        int ExampleMethod();
    }

    public class ProCodeExample: IProCodeExample
    {
        public int ExampleMethod()
        {
            return 2 * 10;
        }
    }
}
