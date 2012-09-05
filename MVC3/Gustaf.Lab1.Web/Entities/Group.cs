using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Group : EntityBase
{   
    public virtual string Name { get; set; }
    public virtual IList<Person> Members { get; set; }

    public Group()
    {
        Members = new List<Person>();
    }
    public virtual void AddMember(Person person)
    {
        person.MemberOfGroups.Add(this);
        Members.Add(person);
    }
}
