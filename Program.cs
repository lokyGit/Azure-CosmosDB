﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Azure.Documents;
using System.Net;
using Microsoft.Azure.Documents.Client;

namespace ConnectingCosmosDB
{
    class JasonData
    {
        public int id { get; set; }
            public string name { get; set; }
        public string Class { get; set; }
        public string subject { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string EndpointUrl = @"https://lucosmosdemo.documents.azure.com:443/";
            const string PrimaryKey = @"88wILG5ApDXMdPhBwGtzmF8CdfouuYl5xk4ahA4IKbAJar5XQI3Ptys5y1h0IxqoiAnzVs4VBK1ayfU0M3qA7A==";
            DocumentClient client;
            client = new DocumentClient( new Uri(EndpointUrl), PrimaryKey);
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<JasonData> familyQuery = client.CreateDocumentQuery<JasonData>(

              UriFactory.CreateDocumentCollectionUri("lucosmosdemo","ConnectCosmosDBColl"), queryOptions);

            foreach (var x in familyQuery)
            {
                Console.WriteLine("\tDBValues {0}", x.id +  " " + x.name + " " + x.Class + " " + x.subject);
            }
            Console.Read();


        }
    }
}
