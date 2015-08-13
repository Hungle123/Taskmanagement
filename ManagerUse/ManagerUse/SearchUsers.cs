using System;
namespace ManagerUse
{
    class SearchUsers : UserRepository
    {
        public void Search()
        {
            var uRepository = new UserRepository();
            string textString = uRepository.ReadText();
            Console.WriteLine("Enter Name user: ");
            var user = Convert.ToString(Console.ReadLine());
            if (System.Text.RegularExpressions.Regex.IsMatch(textString, user,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                Console.WriteLine(" Match for : '{0}' found !", user);
            }
            else
            {
                Console.WriteLine("Username not found !");
            }
        }

    }
}
