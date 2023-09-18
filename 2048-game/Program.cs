// kto legenda kto chempion
internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");


    }

    public static int RandomNumber()
    {
        Random random = new Random();
        int rand = random.Next(0,100);

        if(rand < 90)
            return 2;
        else
            return 4;
    }
}