using Lab10.White;

namespace Lab10
{
    public class Program
    {
        public static void Main()
        {
            var simpleSerializator = new WhiteTxtFileManager("Example1");
            simpleSerializator.Serialize(new Lab9.White.White());

            simpleSerializator = new WhiteTxtFileManager("Example2", "txt");
            simpleSerializator.Serialize(new Lab9.White.White());
        }
    }
}
