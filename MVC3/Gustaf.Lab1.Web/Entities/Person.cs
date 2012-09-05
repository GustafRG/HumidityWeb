using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Person : EntityBase
{
    public virtual String FirstName { get; set; }
    public virtual String LastName { get; set; }
    public virtual IList<Group> MemberOfGroups { get; set; }

    public Person()
    {
        MemberOfGroups = new List<Group>();
    }
}
