using AnemicDomainModel.Domain;

namespace AnemicDomainModel
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client(1, "John Doe", "john.doe@example.com");

            Console.WriteLine(client.Id);
            Console.WriteLine(client.Name);
            Console.WriteLine(client.Email);


            client.UpdateInfos(2, "Jane Doe", "jane.doe@example.com");

            Console.WriteLine(client.Id);
            Console.WriteLine(client.Name);
            Console.WriteLine(client.Email);

            // client.UpdateInfos(3, "", "");
            /* Console.WriteLine(client.Id);
            Console.WriteLine(client.Name);
            Console.WriteLine(client.Email); */
        }
    }
}