using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTest
{
    public class EmployeePayroll
    {
        public int id { get; set; }

        public string name { get; set; }

        public string salary { get; set; }

    }

    [TestClass]
    public class UnitTest1
    {
        RestClient restClient;

        /// <summary>
        /// Creates Client and by passing root URL, establishes connection with the server
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            restClient = new RestClient("http://localhost:3000");
        }

        /// <summary>
        /// TC1 Retrieves All employee details by GET method
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeeData()
        {
            IRestResponse response = GetEmployeeDetails();

            List<EmployeePayroll> records = JsonConvert.DeserializeObject<List<EmployeePayroll>>(response.Content);

            Assert.AreEqual(12, records.Count);

            foreach (EmployeePayroll employee in records)
            {
                Console.WriteLine("EmployeeID: " + employee.id + ", EmployeeName: " + employee.name + ", Salary: " + employee.salary);
            }
        }

        public IRestResponse GetEmployeeDetails()
        {
            //Creates GET request for accessing "/employees", for sending the request to the server
            RestRequest request = new RestRequest("/employees", Method.GET);

            //Sends the request to the server and in return gets the response which is collected by IRestResponse 
            IRestResponse response = restClient.Execute(request);

            return response;
        }

        /// <summary>
        /// TC2 Add a new Employee data into JSON server
        /// </summary>
        //[TestMethod]

    }
}