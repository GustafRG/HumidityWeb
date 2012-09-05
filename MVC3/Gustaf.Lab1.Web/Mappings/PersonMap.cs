using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

public class PersonMap : ClassMap<Person>
{
    public PersonMap()
    {
        Id(x => x.Id);
        Map(x => x.FirstName)
            .Length(25)
            .Nullable();
        Map(x => x.LastName)
           .Length(25)
           .Nullable();
        HasManyToMany(x => x.MemberOfGroups)
              .Cascade.All()
              .Inverse()
              .Table("PersonGroup");
    }
}
