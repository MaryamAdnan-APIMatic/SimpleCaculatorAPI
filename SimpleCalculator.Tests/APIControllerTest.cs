// <copyright file="APIControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using UNIREST;
    using UNIREST.Controllers;
    using UNIREST.Exceptions;
    using UNIREST.Helpers;
    using UNIREST.Http.Client;
    using UNIREST.Http.Response;
    using UNIREST.Utilities;

    /// <summary>
    /// APIControllerTest.
    /// </summary>
    [TestFixture]
    public class APIControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private APIController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.APIController;
        }

        /// <summary>
        /// TestBasicSumTest.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestBasicSumTest()
        {
            // Parameters for the API call
            string operation = "sum";
            double number1 = 1;
            double number2 = 2;

            // Perform API call
            double result = 0;
            try
            {
                result = await this.controller.CalculateAsync(operation, number1, number2);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// TestBasicMultiplyTest.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestBasicMultiplyTest()
        {
            // Parameters for the API call
            string operation = "multiply";
            double number1 = 4;
            double number2 = 3;

            // Perform API call
            double result = 0;
            try
            {
                result = await this.controller.CalculateAsync(operation, number1, number2);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual("12", TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody), "Response body should match exactly (string literal match)");
        }
    }
}