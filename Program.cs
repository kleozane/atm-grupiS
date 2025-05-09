var userList = new List<User>(); // -> lista me users e regjistruar
                                // fillimisht do te kete 0 usera

int invalidAttempts = 0;

//** Cdo hap dhe cdo menu ka nevoje per nje strukture perserite te pafundme
// Ne menyre qe te shkojme para dhe pas ne cdo menu

while (true) // stukture perseritese e faqes kryesore
{
    Console.WriteLine("Wilkommen Sie!");
    Console.WriteLine("1.Sign up    2.Login");
    var input = Console.ReadLine();

    //Nese shtypim 1 do shkojme tek faqja e regjistrimit
    if (input == "1")
    {
        Console.Clear(); //fshij menune paraardhese
        while (true) //hyjme brenda struktures perseritese 
        {
            Console.WriteLine("Welcome to sign up page!");

            Console.Write("Full Name: ");
            string signUpFullName = Console.ReadLine();

            if (signUpFullName == "") //nese emri eshte bosh kthehu tek menuja paraardhese 
            {
                Console.Clear();
                break;
            }

            Console.Write("ID: ");
            string signUpId = Console.ReadLine();

            Console.Write("PIN: ");
            string signUpPin = Console.ReadLine();

            var userExisting = userList.Where(u => u.Id == signUpId).FirstOrDefault();

            if (userExisting == null)
            {
                //Krijojme perdoruesin e ri
                var newUser = new User()
                {
                    Id = signUpId,
                    PIN = signUpPin,
                    FullName = signUpFullName,
                    Balance = 0
                };

                //e shtojme tek lista jone me usera
                userList.Add(newUser);

                //Fshijme konsolen
                Console.Clear();
                Console.WriteLine($"User {signUpFullName} added successfully!");

                //Dalim nga faqja e regjistrimit per te shkuar tek menuja paraardhese
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("This account already exists!");
            }

        }
    } 
    else if(input == "2") //nese duam te logohemi
    {
        if (userList.Count() > 0)
        {
            //Fshij konsolen
            Console.Clear();

            while (true) // -> stuktura perserite e loginit
            {
                if (invalidAttempts == 3) //nese kemi 3 tentativa te deshtuara
                {
                    break; //beji break aplikacionit
                }

                //shkojme tek faqja e loginit
                //vendosim kredencialet
                Console.WriteLine("Login Page");

                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("PIN: ");
                string pin = Console.ReadLine();

                //marrim perdoruesin ne liste i cili permbush kriteret perkatese
                var userAttemptToLogin = userList.Where(u => u.Id == id && u.PIN == pin).First();

                // nese useri gjendet ne liste atehere logohemi
                if (userAttemptToLogin != null)
                {
                    while (true) //-> home page
                    {
                        //Console.Clear();
                        Console.WriteLine($"Hello {userAttemptToLogin.FullName}, welcome back!");
                        Console.WriteLine();
                        Console.WriteLine("1. Withdraw  2.Deposit  3.Balance  4.Logout   5. Delete Account   6. Transfer");
                        string userInput = Console.ReadLine();

                        if (userInput == "4")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (userInput == "1")
                        {
                            userAttemptToLogin.Withdraw(userAttemptToLogin);
                        }
                        else if (userInput == "2")
                        {
                            userAttemptToLogin.Deposit(userAttemptToLogin);
                        }
                        else if (userInput == "5")
                        {
                            Console.WriteLine("Are you sure? y/n");
                            var sureInput = Console.ReadLine();

                            Console.Clear();

                            if (sureInput == "y")
                            {
                                userList.Remove(userAttemptToLogin);
                                Console.WriteLine("Account deleted successfully!");
                                break;
                            }
                            else if (sureInput == "n")
                            {
                                Console.WriteLine("Account not deleted!");
                            }
                        }
                        else if (userInput == "6")
                        {
                            userAttemptToLogin.Transfer(userAttemptToLogin, userList);
                        }
                    }
                }
                else //ne te kundert do te thote qe useri ose nuk eshte regjistruar ose kredencialet jane gabim
                {
                    invalidAttempts++;
                    Console.Clear();
                    Console.WriteLine("Invalid credentials");
                }

            }
        }
        else
        {
            //Fshij konsolen
            Console.Clear();

            Console.WriteLine("No accounts exist!");
            break;
        }
        
    }
}



Console.WriteLine("Login attempts reached, please try again later!");


// ja shtuam per efekt merge3
