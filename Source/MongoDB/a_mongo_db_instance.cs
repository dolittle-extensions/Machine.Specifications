/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mongo2Go;
using MongoDB.Driver;
using Machine.Specifications;
using MongoDB.Bson.Serialization;

namespace Dolittle.Machine.Specifications.MongoDB
{
    /// <summary>
    /// A base spec for specs against MongoDB
    /// Based on Mongo2Go
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

        /// <summary>
        /// Exports the contents of a collection to a file
        /// </summary>
        /// <param name="fileName">Filename and path of the output file</param>
        /// <param name="collectionName">Collection to export</param>
        /// <typeparam name="T">Document type</typeparam>
        protected static void Export<T>(string fileName, string collectionName = null)
        {
            var collection = collectionName ?? typeof(T).FullName;
            runner.Export(database_name,collection,fileName);
        }

        /// <summary>
        /// Imports the contents of a file to a collection, dropping the existing collection if it exists
        /// </summary>
        /// <param name="fileName">File to read for input</param>
        /// <param name="collectionName">Name of the collection to populate</param>
        /// <typeparam name="T">Type of the document</typeparam>
        protected static void Import<T>(string fileName, string collectionName = null)
        {
            var collection = collectionName ?? typeof(T).FullName;
            runner.Import(database_name,collection,fileName, true);
        }

        /// <summary>
        /// Reads and parses a bson file to the specified type
        /// </summary>
        /// <param name="fileName">File to read</param>
        /// <typeparam name="T">Document type</typeparam>
        /// <returns>An enumerable of documents</returns>
        protected static IEnumerable<T> ParseFile<T>(string fileName)
        {
            var content = File.ReadAllLines(fileName);
            return content.Select(s => BsonSerializer.Deserialize<T>(s)).ToList();
        }
    }
}