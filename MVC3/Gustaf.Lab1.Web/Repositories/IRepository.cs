using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gustaf.Lab1.Web.Repositories
{
    public interface IRepository
    {
        IList<Person> GetAllPeople();
        IList<Group> GetAllGroups();
        void NewPerson(Person p);
        void NewGroup(Group g);
        void AddPersonToGroup(int groupId, int personId);
        string ReadSHT15();
    }
}