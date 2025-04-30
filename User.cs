public class User
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string PIN { get; set; }
    public double Balance { get; set; }
    //public List<string> Notes { get; set; }

    public void Withdraw(User user)
    {
        Console.Write("Amount to withdraw: ");
        var amount = Convert.ToInt32(Console.ReadLine());

        if (amount <= user.Balance && amount % 500 == 0)
        {
            user.Balance -= amount;
            Console.WriteLine($"Actual Balance: {user.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount!");
        }
    }

    public void Deposit(User user)
    {
        Console.Write("Amount to deposit: ");
        var amount = Convert.ToInt32(Console.ReadLine());

        if (amount % 500 == 0)
        {
            user.Balance += amount;
            Console.WriteLine($"Actual Balance: {user.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount!");
        }
    }

    public void Transfer(User user, List<User> userList)
    {
        Console.Write("Transfer Account ID: ");
        var uId = Console.ReadLine();

        var userRecieve = userList.Where(u => u.Id == uId).FirstOrDefault();

        if (userRecieve != null)
        {
            Console.Write("Amount: ");
            var amount = Convert.ToDouble(Console.ReadLine());

            if (amount > 0 && amount <= user.Balance)
            {
                user.Balance -= amount;
                userRecieve.Balance += amount;
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }
        else
        {
            Console.Write("Account not found!");
        }
    }
}

