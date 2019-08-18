using AccessWithData;
using RegisterForInPlayNet.Models.ProfileInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RegisterForInPlayNet.Models.InformationExchange
{
    public class ExchangeInfo
    {
        public usersTable profileToDbUser(Profile profile)
        {
            usersTable user = new usersTable();

            user.firstName = profile.firstName;
            user.lastName = profile.firstName;
            user.dateOfBirth = Convert.ToDateTime(profile.dateOfBirth);
            user.resident = profile.resident;
            user.privateId = Convert.ToInt64(profile.privateId);
            user.gender = profile.gender;
            user.dateOfRegistration = Convert.ToDateTime(profile.registrationDate);
            user.registrationIp = profile.registrationIp;
            user.userLanguage = profile.language;
            user.mail = profile.mail;
            user.mobile = Convert.ToInt64(profile.number);
            user.userPassword = ComputeSha256Hash(profile.Password);
            user.country = profile.address.country;
            user.regionState = profile.address.state;
            user.city = profile.address.city;
            user.addressOne = profile.address.addressOne;
            user.addressTwo = profile.address.addressTwo;
            user.postalCode = profile.address.postalCode;

            return user;
        }

        public Profile DbUserToProfile(usersTable user)
        {
            Profile profile = new Profile();

            profile.firstName = user.firstName;
            profile.lastName = user.lastName;
            profile.dateOfBirth = user.dateOfBirth.ToString();
            profile.resident = user.resident;
            profile.privateId = user.privateId.ToString();
            profile.gender = user.gender;
            profile.registrationDate = user.dateOfRegistration.ToString();
            profile.registrationIp = user.registrationIp;
            profile.language = user.userLanguage;
            profile.mail = user.mail;
            profile.number = user.mobile.ToString();
            profile.Password = user.userPassword;
            profile.address.country = user.country;
            profile.address.state = user.regionState;
            profile.address.city = user.city;
            profile.address.addressOne = user.addressOne;
            profile.address.addressTwo = user.addressTwo;
            profile.address.postalCode = user.postalCode;

            return profile;
        }

        //here starts helper method for hashing;
        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}