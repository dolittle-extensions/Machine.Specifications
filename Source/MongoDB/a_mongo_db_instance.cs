/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/
using System;
using Mongo2Go;
using MongoDB.Driver;
using Machine.Specifications;

namespace Dolittle.Machine.Specifications.MongoDB
{
    /// <summary>
    /// A base spec for specs against MongoDB
    /// </summary>
    public class a_mongo_db_instance
    {
        /// <summary>
        /// The Mongo2Go runner
        /// </summary>
        protected static MongoDbRunner runner;
        /// <summary>
        /// A generated db name
        /// </summary>
        protected static string database_name;
        /// <summary>
        /// the connection string for the mongo server
        /// </summary>
        protected static string connection_string;
        /// <summary>
        /// An instance of the database
        /// </summary>
        protected static IMongoDatabase database;
        /// <summary>
        /// An instance of the MongoClient
        /// </summary>
        protected static MongoClient client;
        

        Establish context = () => 
        {
            CreateDBConnection(Guid.NewGuid().ToString());
        };

        
        Cleanup the_database = () => 
        {
            runner.Dispose();
        };

        /// <summary>
        /// Creates the MongoDB connection with the specified database name and whether to use a single node replica set
        /// </summary>
        /// <param name="dbName">Name of the database</param>
        /// <param name="replSet">Use a single node replicate set. Defaults to false</param>
        protected static void CreateDBConnection(string dbName, bool replSet = false)
        {
            database_name = dbName;
            runner = MongoDbRunner.Start(singleNodeReplSet: replSet);
            connection_string = runner.ConnectionString; 
            client = new MongoClient(connection_string);
            database = client.GetDatabase(database_name);
        }
    }
}