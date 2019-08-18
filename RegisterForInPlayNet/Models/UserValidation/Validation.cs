using AccessWithData;
using RegisterForInPlayNet.Models.ProfileInfo;
using RegisterForInPlayNet.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RegisterForInPlayNet.Models.UserValidation
{
    public class Validation
    {
        private Profile profile = new Profile();
        private RepositoryClass rep = new RepositoryClass();

        public bool IsValidAccount()
        {
            if (uniqueMail() && uniqueId() && uniqueNum() && validMail() && validAge() && validFirstName() && validId()
                && validLastName() && validPassword() && validPhoneNum())
            {
                return true;
            }
            else return false;
        }

        private bool uniqueMail()
        {
            int counter = 0;
            registeredDbEntities entities = new registeredDbEntities();
            List<Profile> profiles = rep.Get();

            for (int i = 0; i < profiles.Count; i++)
            {
                if (profile.mail != profiles[i].mail)
                {
                    counter++;
                }
                else return false; //for not continuing working in for cycle;
            }
            if (counter == profiles.Count)
            {
                return true;
            }
            else return false;

        }
         

        private bool uniqueId()
        {

            int counter = 0;
            registeredDbEntities entities = new registeredDbEntities();
            List<Profile> profiles = rep.Get();

            for (int i = 0; i < profiles.Count; i++)
            {
                if (profile.privateId != profiles[i].privateId)
                {
                    counter++;
                }
                else return false; //for not continuing working in for cycle;
            }
            if (counter == profiles.Count)
            {
                return true;
            }
            else return false;

        }

        private bool uniqueNum()
        {

            int counter = 0;
            registeredDbEntities entities = new registeredDbEntities();
            List<Profile> profiles = rep.Get();

            for (int i = 0; i < profiles.Count; i++)
            {
                if (profile.number != profiles[i].number)
                {
                    counter++;
                }
                else {
                    return false; //for not continuing working in for cycle;
                }
            }
            if (counter == profiles.Count)
            {
                return true;
            }
            else return false;

        }


        public Validation(Profile profile)
        {
            this.profile = profile;
        }

        //checks mail is valid or not;
        private bool validMail()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(profile.mail);
        }

        //checks age is valid or not;
        private bool validAge()
        {
            int age = DateTime.Now.Year - Convert.ToDateTime(profile.dateOfBirth).Year;

            if (age >= 16)
            {
                return true;
            }
            else return false;
        }

        //checks firstName is valid or not;
        private bool validFirstName()
        {
            if (profile.firstName.Length >= 2 && isAllLetters(profile.firstName))
            {
                return true;
            }
            else return false;
        }

        //checks ID is valid or not;
        private bool validId()
        {
            if ((profile.address.country.Equals("Georgia") && profile.privateId.Length == 11 && 
                isAllNumbers(profile.privateId)) || (profile.address.country.Equals("German") && 
                profile.privateId.Length == 6 && isAllNumbers(profile.privateId)))
            {
                return true;
            }
            else return false;
        }

        //checks lastname is valid or not;
        private bool validLastName()
        {
            if (profile.lastName.Length >= 2 && isAllLetters(profile.lastName))
            {
                return true;
            }
            else return false;
        }

        //checks password is valid or not;
        private bool validPassword()
        {
            bool containsInt = profile.Password.Any(char.IsDigit);
            bool containsSmallChar = profile.Password.Any(char.IsLower);
            bool containsUpperChar = profile.Password.Any(char.IsUpper);

            if (containsInt && containsSmallChar && containsUpperChar)
            {
                return true;
            }
            else return false;

        }

        //checks phonenum is valid or not;
        private bool validPhoneNum()
        {
            if ((profile.address.country.Equals("Georgia") && profile.number.Substring(0, 3).Equals("995")) ||
                (profile.address.country.Equals("German") && profile.number.Substring(0, 3).Equals("+49")))
            {
                return true;
            }
            else return false;
        }




        //Helper private methods for getting validation's method easier to read;


        //this method checks weather text contain all letters or not;
        private bool isAllLetters(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        //this method checks weather text contain all numbers or not;
        private bool isAllNumbers(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}