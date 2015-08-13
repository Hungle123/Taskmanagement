using System;
using System.Globalization;

namespace ManagerUse
{
   public class SearchUsers : UserRepository
    {
        public string Search(string user)
        {
            var uRepository = new UserRepository();
            string textString = uRepository.ReadText();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            user = textInfo.ToLower(user);
            user = textInfo.ToTitleCase(user);
            if (System.Text.RegularExpressions.Regex.IsMatch(textString, user,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

    }
}
