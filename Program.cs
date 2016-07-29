using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orient.Client;

namespace OrientTest
{
    public class Program
    {
        static void Main(string[] args)
        {

            //drop any previously exsisting db
            try
            {
                OrientConnection.DropDatabase();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            //create the test database
            OrientConnection.CreateDatabase();

            //establish connection with the db
            OrientConnection.CreatePool();
            var database = new ODatabase(OrientConnection.GlobalDatabaseAlias);

            //create the schema
            database.Create.Class(typeof(TestModel).Name).Extends<OVertex>().Run();

            //model to save
            var testModel = new TestModel();
            testModel.DecimalTest = decimal.Parse("189.5");
            testModel.DecimalDictionaryTest.Add("key", decimal.Parse("189.5"));
            testModel.DecimalListTest.Add(decimal.Parse("189.5"));
            
            //save the test model
            database.Insert<TestModel>(testModel).Run();

            //get the saved data
            var selectQuery = new OSqlSelect()
                .Select()
                .From(typeof(TestModel).Name)
                .ToString();
            var testModelDocuments = database.Query(selectQuery);

            //convert it to the c# model
            var testModels = testModelDocuments.Select(document => document.To<TestModel>()).ToList();

        }
    }
}
