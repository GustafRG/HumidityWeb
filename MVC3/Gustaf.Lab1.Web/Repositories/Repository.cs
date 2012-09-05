using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Logging;
using NHibernate;
using System.Net;
using System.IO;
using System.Text;

namespace Gustaf.Lab1.Web.Repositories
{
    public class Repository : IRepository
    {
        private readonly ISession session;
        //
        //log4net through Castle.Core.Logging
        public ILogger Logger { get; set; }


        public Repository(ISession session)
		{
			this.session = session;
		}

        public IList<Person> GetAllPeople()
        {
            return session.QueryOver<Person>().List<Person>();
        }

        public IList<Group> GetAllGroups()
        {
            return session.QueryOver<Group>().List<Group>();
        }

        public void NewPerson(Person p)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
                Logger.Debug("Persisted Person: " + p.FirstName + " " + p.LastName);

            }
        }

        public void NewGroup(Group g)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                session.Save(g);
                transaction.Commit();
                Logger.Debug("Persisted Group: " + g.Name);

            }
        }

        public void AddPersonToGroup(int groupId, int personId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var personToAdd = GetAllPeople().First<Person>(p => p.Id == personId);
                var groupToAddTo = GetAllGroups().First<Group>(g => g.Id == groupId);


                groupToAddTo.AddMember(personToAdd);
                session.Update(groupToAddTo);
                transaction.Commit();
                Logger.Debug("Persisted Updated Group, added " + personToAdd.FirstName +" "+ personToAdd.LastName + " to Group" + groupToAddTo.Name);

            }
        }
        public string ReadSHT15()
        {
			//string result = null;
			//try
			//{
			//    WebRequest request = WebRequest.Create("http://10.53.31.137/readsht15/");
			//    // execute the request
			//    WebResponse response = (WebResponse)
			//        request.GetResponse();

			//    // we will read data via the response stream

			//    Stream resStream = response.GetResponseStream();

			//    // used to build entire input
			//    StringBuilder sb = new StringBuilder();

			//    // used on each read operation
			//    byte[] buf = new byte[8192];

			//    string tempString = null;
			//    int count = 0;

			//    do
			//    {
			//        // fill the buffer with data
			//        count = resStream.Read(buf, 0, buf.Length);

			//        // make sure we read some data
			//        if (count != 0)
			//        {
			//            // translate from bytes to ASCII text
			//            tempString = Encoding.ASCII.GetString(buf, 0, count);

			//            // continue building the string
			//            sb.Append(tempString);
			//        }
			//    }
			//    while (count > 0); // any more data to read?
			//    result = tempString;

			//}
			//catch (Exception)
			//{
			//    result = "20.0000;40.00000";
			//}
			var temperature = (new Random().NextDouble()) * 20 + 20;
			var humidity = (new Random().NextDouble()) * 5 + 35;
			return temperature.ToString() + ";" + humidity;

        }
    }
}