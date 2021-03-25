using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace Infra.Repository.Mongo
{
    public class Db
    {
        private static string connectionStr = "mongodb://localhost:27017/"; //TODO: LOAD FROM ENV
        private static string dbName = "testdbgerenciamentoalunos";
        private static IMongoClient client = null;

        public static IMongoDatabase getDatabase() { //DONETODO: IMPLEMENT AS SINGLETON //TODO: FIND OUT IF SINGLETON IS OK HERE

            if (client == null){

                //TODO: ENCAPSULATE IN ANOTHER METHOD
                var pack = new ConventionPack(); //new StringIdStoredAsObjectIdConvention()
                pack.Add(new StringIdConvention()); //TO MOVE THE DEPENDENCY AWAY FROM THE DOMAIN
                pack.Add(new StringIdStoredAsObjectIdConvention()); //TO KEEP THE ID STORED THE SAME WAY MONGODB WOULD NORMALLY DO. //TODO: IS IT REALLY NECESSARY?
                ConventionRegistry.Register("MyConventions", pack, _ => true );

                client = new MongoClient(connectionStr); //TODO: READ ABOUT THE MOST APPROPRIATE WAY OF DOING THIS. POOLING?
                
            }
            
            return client.GetDatabase(dbName);

        }

        public static bool insertDocument<T>(string collection, object document) {
            
            getDatabase().GetCollection<T>(collection).InsertOne((T) document);
            return true;

        }

        public void retrieveDocument() {
            //IMPORTANT: NECESSARY TO CONVERT ID TO A STRING WHEN READING
        }

        public void retrieveCollection() {
        }

        public void deleteDocument() {
        
        }

        private class StringIdConvention : ConventionBase, IPostProcessingConvention {


            public void PostProcess(BsonClassMap classMap)
            {
                //To keep our POCO clean
                var idMap = classMap.IdMemberMap;
                if (idMap != null && idMap.MemberName == "Id" && idMap.MemberType == typeof(string)) {
                    idMap.SetIdGenerator(StringObjectIdGenerator.Instance); //(new StringObjectIdGenerator());//(CombGuidGenerator.Instance);
                }
            }
        }

    }
}
