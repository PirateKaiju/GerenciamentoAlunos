using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
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

        //TODO: USE ASYNC METHODS?

        public static bool insertDocument<T>(string collection, object document) {
            
            getDatabase().GetCollection<T>(collection).InsertOne((T) document);
            return true;

        }

        public static T retrieveDocumentById<T>(string collection, string id) {
            //IMPORTANT: NECESSARY TO CONVERT ID TO A STRING WHEN READING

            ObjectId objectId = ObjectId.Parse(id);

            var filter = Builders<T>.Filter.Eq("_id", objectId);

            T result = getDatabase().GetCollection<T>(collection).Find(filter).FirstOrDefault();
            return result;
        }

        public static T retrieveDocumentByAttribute<T>(string collection, string attribute, string attribValue)
        {
            //IMPORTANT: NECESSARY TO CONVERT ID TO A STRING WHEN READING

            var filter = Builders<T>.Filter.Eq(attribute, attribValue);

            T result = getDatabase().GetCollection<T>(collection).Find(filter).FirstOrDefault(); //TODO: HANDLE ERRORS AND NOT FOUND
            return result;
        }

        public static List<T> retrieveCollectionAsList<T>(string collection) {//IS IT NECESSARY?

            return getDatabase().GetCollection<T>(collection).Find(_ => true).ToList();

        }

        public static bool deleteDocument<T>(string collection, string id) {

            ObjectId objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);

            getDatabase().GetCollection<T>(collection).DeleteOne(filter);

            return true;
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
