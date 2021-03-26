# Getting Started with SimpleCalculator

## Getting Started

### Introduction

its a calculator

### Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (SimpleCalculator.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8, Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

### Installation

The following section explains how to use the UNIREST library in a new project.

#### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=createProject)

#### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=setStartup)

#### 3. Add reference of the library project

In order to use the Tester library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `Tester.Tests` and click `OK`. By doing this, we have added a reference of the `Tester.Tests` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=createReference)

#### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=SimpleCalculator-CSharp&workspaceName=SimpleCalculator&projectName=UNIREST&rootNamespace=UNIREST&step=addCode)

### Initialize the API Client

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Timeout` | `TimeSpan` | Gets the http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `BasicAuthUserName` | `string` | The username to use with basic authentication |
| `BasicAuthPassword` | `string` | The password to use with basic authentication |

The API client can be initialized as follows:

```csharp
UNIREST.SimpleCalculatorClient client = new UNIREST.SimpleCalculatorClient();
```

### Authorization

This API uses `Basic Authentication`.

### Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Client Class Documentation

### SimpleCalculatorClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

#### Controllers

| Name | Description |
|  --- | --- |
| APIController | Gets APIController controller. |

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Gets the http client timeout. | `TimeSpan` |
| Environment | Gets the Current API environment. | `Environment` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the SimpleCalculatorClient using the values provided for the builder. | `Builder` |

## API Reference

### List of APIs

* [API](#api)

### API

#### Overview

##### Get instance

An instance of the `APIController` class can be accessed from the API Client.

```
APIController aPIController = client.APIController;
```

#### Calculate

```csharp
CalculateAsync(
    string operation,
    double number1,
    double number2)
```

##### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | `string` | Template, Required | The operation to be applied on the operands |
| `number1` | `double` | Query, Required | - |
| `number2` | `double` | Query, Required | - |

##### Response Type

`Task<double>`

##### Example Usage

```csharp
string operation = "operation4";
double number1 = 41.48;
double number2 = 76.02;

try
{
    double? result = await aPIController.CalculateAsync(operation, number1, number2);
}
catch (ApiException e){};
```

##### Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | operand not found | `ApiException` |

## Model Reference

### Enumerations

* [Operation](#operation)

#### Operation

##### Class Name

`OperationEnum`

##### Fields

| Name |
|  --- |
| `Multiply` |
| `Divide` |
| `Sum` |
| `Subtract` |

## Utility Classes Documentation

### ApiHelper Class

HttpRequest stores necessary information about the http request.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpMethod | The HTTP verb to use for this request. | `HttpMethod` |
| QueryUrl | The query url for the http request. | `string` |
| QueryParameters | Query parameters collection for the current http request. | `Dictionary<string, object>` |
| Headers | Headers collection for the current http request. | `Dictionary<string, string>` |
| FormParameters | Form parameters for the current http request. | `List<KeyValuePair<string, object>>` |
| Body | Optional raw string to send as request body. | `object` |
| Username | Optional username for Basic Auth. | `string` |
| Password | Optional password for Basic Auth. | `string` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `DeepCloneObject<T>(T obj)` | Creates a deep clone of an object by serializing it into a json string and then deserializing back into an object. | `T` |
| `JsonSerialize(object obj, JsonConverter converter = null)` | JSON Serialization of a given object. | `string` |
| `JsonDeserialize<T>(string json, JsonConverter converter = null)` | JSON Deserialization of the given json string. | `T` |

## Common Code Documentation

### HttpRequest Class

HttpResponse stores necessary information about the http response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| RawBody | Gets the stream of the body. | `Stream` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpRequest(HttpMethod method, string queryUrl)` | Constructor to initialize the http request object. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, body and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, form parameters and optional Basic auth params. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `AddHeaders(Dictionary<string, string> HeadersToAdd)` | Concatenate values from a Dictionary to this object. | `Dictionary<string, string>` |
| `AddQueryParameters(Dictionary<string, object> queryParamaters)` | Concatenate values from a Dictionary to query parameters dictionary. | `void` |

### HttpResponse Class

HttpResponse stores necessary information about the http response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| RawBody | Gets the stream of the body. | `Stream` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody)` | Initializes a new instance of the <see cref="HttpResponse"/> class. |

### HttpStringResponse Class

HttpStringResponse inherits from HttpResponse and has additional property of string body.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| Body | Gets the raw string body of the http response. | `string` |

#### Constructors

| Name | Description |
|  --- | --- |
| ```HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body)<br>        : base(statusCode, headers, rawBody)```<br>``` | Initializes a new instance of the <see cref="HttpStringResponse"/> class. |

### HttpContext Class

Represents the contextual information of HTTP request and response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| Request | Gets the http request in the current context. | `HttpRequest` |
| Response | Gets the http response in the current context. | `HttpResponse` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpContext(HttpRequest request, HttpResponse response)` | Initializes a new instance of the <see cref="HttpContext"/> class. |

### IAuthManager Class

IAuthManager adds the authenticaion layer to the http calls.

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `Apply(HttpRequest httpRequest)` | Add authentication information to the HTTP Request. | `HttpRequest` |
| `ApplyAsync(HttpRequest httpRequest)` | Asynchronously add authentication information to the HTTP Request. | `Task<HttpRequest>` |

### ApiException Class

This is the base class for all exceptions that represent an error response from the server.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| ResponseCode | Gets the HTTP response code from the API request. | `int` |
| HttpContext | Gets or sets the HttpContext for the request and response. | `HttpContext` |

#### Constructors

| Name | Description |
|  --- | --- |
| `ApiException(string reason, HttpContext context)` | Initializes a new instance of the <see cref="ApiException"/> class. |

