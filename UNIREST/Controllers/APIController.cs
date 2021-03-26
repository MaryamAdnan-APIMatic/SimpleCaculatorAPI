// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using UNIREST;
    using UNIREST.Authentication;
    using UNIREST.Exceptions;
    using UNIREST.Http.Client;
    using UNIREST.Http.Request;
    using UNIREST.Http.Response;
    using UNIREST.Utilities;

    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal APIController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Calculate EndPoint.
        /// </summary>
        /// <param name="operation">Required parameter: The operation to be applied on the operands.</param>
        /// <param name="number1">Required parameter: Example: 1.</param>
        /// <param name="number2">Required parameter: Example: 1.</param>
        /// <returns>Returns the double response from the API call.</returns>
        public double Calculate(
                string operation,
                double number1,
                double number2)
        {
            Task<double> t = this.CalculateAsync(operation, number1, number2);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculate EndPoint.
        /// </summary>
        /// <param name="operation">Required parameter: The operation to be applied on the operands.</param>
        /// <param name="number1">Required parameter: Example: 1.</param>
        /// <param name="number2">Required parameter: Example: 1.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the double response from the API call.</returns>
        public async Task<double> CalculateAsync(
                string operation,
                double number1,
                double number2,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{operation}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "operation", operation },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "number1", number1 },
                { "number2", number2 },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // Error handling using HTTP status codes.
            if (response.StatusCode == 400)
            {
                throw new ApiException("operand not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return double.Parse(response.Body);
        }
    }
}