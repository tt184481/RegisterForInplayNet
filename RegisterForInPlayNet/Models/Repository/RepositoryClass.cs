using AccessWithData;
using RegisterForInPlayNet.Models.InformationExchange;
using RegisterForInPlayNet.Models.ProfileInfo;
using RegisterForInPlayNet.Models.UserValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RegisterForInPlayNet.Models.Repository
{
    public class RepositoryClass
    {
        registeredDbEntities entities = new registeredDbEntities();

        //Returns list of all users from base;
        public List<Profile> Get() {

            ExchangeInfo DBUser = new ExchangeInfo();
            List<Profile> resultList = new List<Profile>();
            for (int i = 0; i < entities.usersTables.ToList().Count; i++) {
                resultList.Add(DBUser.DbUserToProfile(entities.usersTables.ToList()[i]));
            }
            return resultList;
        }

        public void Add(Profile profile)
        {
            Validation valid = new Validation(profile);
            if (valid.IsValidAccount()) {
                ExchangeInfo DBUser = new ExchangeInfo();
                usersTable user = DBUser.profileToDbUser(profile);
                entities.usersTables.Add(user);
                string path = System.IO.Directory.GetCurrentDirectory() + "\\ClientLog.txt";
                using (StreamWriter writetext = new StreamWriter(path))
                {
                    writetext.WriteLine("new user " + profile.firstName + " has been registered");
                }
            }
        }

        public void Change(Profile profile)
        {
            ExchangeInfo DBUser = new ExchangeInfo();
            List<Profile> profiles = Get();
            Validation valid = new Validation(profile);
            for (int i = 0; i < profiles.Count; i++) {
                if (profiles[i].mail == profile.mail) {
                    if (valid.IsValidAccount()) {
                        entities.usersTables.Remove(DBUser.profileToDbUser(profiles[i]));
                        entities.usersTables.Add(DBUser.profileToDbUser(profile));
                        string path = System.IO.Directory.GetCurrentDirectory() + "\\ClientLog.txt";
                        using (StreamWriter writetext = new StreamWriter(path))
                        {
                            writetext.WriteLine("properties of " + profile.firstName + " has been changed");
                        }
                        break;
                    }
                }
            }
        }
    }
}