using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;


public class GroupMap : ClassMap<Group>
{
    public GroupMap()
    {
        Id(x => x.Id);
        Map(x => x.Name);
        HasManyToMany(x => x.Members)
         .Cascade.All()
         .Table("PersonGroup");
    }
}
