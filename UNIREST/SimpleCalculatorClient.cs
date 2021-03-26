// <copyright file="SimpleCalculatorClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using UNIREST.Authentication;
    using UNIREST.Controllers;
    using UNIREST.Http.Client;
    using UNIREST.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class SimpleCalculatorClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "http://examples.apimatic.io/apps/calculator" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly BasicAuthManager basicAuthManager;

        private readonly Lazy<APIController> client;

        private SimpleCalculatorClient(
            TimeSpan timeout,
            Environment environment,
            string basicAuthUserName,
            string basicAuthPassword,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Timeout = timeout;
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.client = new Lazy<APIController>(
                () => new APIController(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                this.basicAuthManager = (BasicAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.BasicAuthCredentials.Equals(basicAuthUserName, basicAuthPassword))
            {
                this.basicAuthManager = new BasicAuthManager(basicAuthUserName, basicAuthPassword);
                this.authManagers["global"] = this.basicAuthManager;
            }
        }

        /// <summary>
        /// Gets APIController controller.
        /// </summary>
        public APIController APIController => this.client.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets the credentials to use with BasicAuth.
        /// </summary>
        public IBasicAuthCredentials BasicAuthCredentials => this.basicAuthManager;

        /// <summary>
        /// Gets Timeout.
        /// Gets the http client timeout.
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Gets Environment.
        /// Gets the Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the SimpleCalculatorClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(this.Timeout)
                .Environment(this.Environment)
                .BasicAuthCredentials(this.basicAuthManager.BasicAuthUserName, this.basicAuthManager.BasicAuthPassword)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers);

            return builder;
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SimpleCalculatorClient.</returns>
        internal static SimpleCalculatorClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("UNIREST_TIMEOUT");
            string environment = System.Environment.GetEnvironmentVariable("UNIREST_ENVIRONMENT");
            string basicAuthUserName = System.Environment.GetEnvironmentVariable("UNIREST_BASIC_AUTH_USER_NAME");
            string basicAuthPassword = System.Environment.GetEnvironmentVariable("UNIREST_BASIC_AUTH_PASSWORD");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (basicAuthUserName != null && basicAuthPassword != null)
            {
                builder.BasicAuthCredentials(basicAuthUserName, basicAuthPassword);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        public override string ToString()
        {
            return
                $"Environment = {Environment}, " +
                $"HttpClientConfiguration = {HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(100);
            private Environment environment = UNIREST.Environment.Production;
            private string basicAuthUserName = "TODO: Replace";
            private string basicAuthPassword = "TODO: Replace";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private bool createCustomHttpClient = false;
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for BasicAuth.
            /// </summary>
            /// <param name="basicAuthUserName">BasicAuthUserName.</param>
            /// <param name="basicAuthPassword">BasicAuthPassword.</param>
            /// <returns>Builder.</returns>
            public Builder BasicAuthCredentials(string basicAuthUserName, string basicAuthPassword)
            {
                this.basicAuthUserName = basicAuthUserName ?? throw new ArgumentNullException(nameof(basicAuthUserName));
                this.basicAuthPassword = basicAuthPassword ?? throw new ArgumentNullException(nameof(basicAuthPassword));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets Timeout.
            /// </summary>
            /// <param name="timeout"> Timeout. </param>
            /// <returns> Builder. </returns>
            public Builder Timeout(TimeSpan timeout)
            {
                this.httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(100) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            /// <summary>
            /// Creates an object of the SimpleCalculatorClient using the values provided for the builder.
            /// </summary>
            /// <returns>SimpleCalculatorClient.</returns>
            public SimpleCalculatorClient Build()
            {
                if (this.createCustomHttpClient)
                {
                    this.httpClient = new HttpClientWrapper(this.httpClientConfig);
                }
                else
                {
                    this.httpClient = new HttpClientWrapper();
                }

                return new SimpleCalculatorClient(
                    this.timeout,
                    this.environment,
                    this.basicAuthUserName,
                    this.basicAuthPassword,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.httpClientConfig);
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }
        }
    }
}
