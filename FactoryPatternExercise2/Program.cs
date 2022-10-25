namespace FactoryPatternExercise2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            bool correctInput;
            do {
                correctInput = true;
                Console.WriteLine("What database would you like to work with?");
                Console.WriteLine("Type: mongo");
                Console.WriteLine("Type: sql");
                Console.WriteLine("Type: list");
                
                userInput = Console.ReadLine().ToLower();
                

                if(userInput != "sql" && userInput != "mongo" && userInput != "list")
                {
                    correctInput = false;
                    Console.WriteLine("Bad input!");
                    Thread.Sleep(1000);
                }
            } while(!correctInput);

            Console.Clear();

            IDataAccess db = DataAccessFactory.GetDataAccess(userInput);
            var products =db.LoadData();
            db.SaveData();
            foreach(var product in products)
            {
                Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
            }
        }
    }
}
