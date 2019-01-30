namespace QualifyThis
{
    public static class Console
    {
        public static void WriteLine(object o)
        {
            if (o is string)
                System.Console.WriteLine(o);
            else 
                throw new System.Exception("only strings");
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
