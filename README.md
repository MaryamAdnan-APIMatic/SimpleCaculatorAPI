# Getting Started with SimpleCalculator

## Getting Started

### Introduction

its a calculator

### Building

The generated code uses a few Maven dependencies e.g., Jackson, OkHttp,
and Apache HttpClient. The reference to these dependencies is already
added in the pom.xml file will be installed automatically. Therefore,
you will need internet access for a successful build.

* In order to open the client library in Eclipse click on `File -> Import`.

![Importing SDK into Eclipse - Step 1](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=import0)

* In the import dialog, select `Existing Java Project` and click `Next`.

![Importing SDK into Eclipse - Step 2](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=import1)

* Browse to locate the folder containing the source code. Select the detected location of the project and click `Finish`.

![Importing SDK into Eclipse - Step 3](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=import2)

* Upon successful import, the project will be automatically built by Eclipse after automatically resolving the dependencies.

![Importing SDK into Eclipse - Step 4](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=import3)

### Installation

The following section explains how to use the SimpleCalculatorLib library in a new project.

#### 1. Starting a new project

For starting a new project, click the menu command `File > New > Project`.

![Add a new project in Eclipse](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=createNewProject0)

Next, choose `Maven > Maven Project` and click `Next`.

![Create a new Maven Project - Step 1](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=createNewProject1)

Here, make sure to use the current workspace by choosing `Use default Workspace location`, as shown in the picture below and click `Next`.

![Create a new Maven Project - Step 2](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=createNewProject2)

Following this, select the *quick start* project type to create a simple project with an existing class and a `main` method. To do this, choose `maven-archetype-quickstart` item from the list and click `Next`.

![Create a new Maven Project - Step 3](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=createNewProject3)

In the last step, provide a `Group Id` and `Artifact Id` as shown in the picture below and click `Finish`.

![Create a new Maven Project - Step 4](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=createNewProject4)

#### 2. Add reference of the library project

The created Maven project manages its dependencies using its `pom.xml` file. In order to add a dependency on the *SimpleCalculatorLib* client library, double click on the `pom.xml` file in the `Package Explorer`. Opening the `pom.xml` file will render a graphical view on the canvas. Here, switch to the `Dependencies` tab and click the `Add` button as shown in the picture below.

![Adding dependency to the client library - Step 1](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=testProject0)

Clicking the `Add` button will open a dialog where you need to specify SimpleCalculatorLib in `Group Id`, simple-calculator-lib in `Artifact Id` and 1.0.0 in the `Version` fields. Once added click `OK`. Save the `pom.xml` file.

![Adding dependency to the client library - Step 2](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=testProject1)

![Adding sample code](https://apidocs.io/illustration/java?workspaceFolder=SimpleCalculator-Java&workspaceName=SimpleCalculator&projectName=SimpleCalculatorLib&rootNamespace=io.apimatic.examples&groupId=SimpleCalculatorLib&artifactId=simple-calculator-lib&version=1.0.0&step=testProject2)

#### 3. Write sample code

Once the `SimpleConsoleApp` is created, a file named `App.java` will be visible in the *Package Explorer* with a `main` method. This is the entry point for the execution of the created project.
Here, you can add code to initialize the client library and instantiate a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

### Initialize the API Client

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `timeout` | `long` | The timeout to use for making HTTP requests.<br>*Default*: `0L` |
| `httpClientConfig` | `ReadonlyHttpClientConfiguration` | Http Client Configuration instance. |
| `basicAuthUserName` | `String` | The username to use with basic authentication |
| `basicAuthPassword` | `String` | The password to use with basic authentication |

The API client can be initialized as follows:

```java
SimpleCalculatorClient client = new SimpleCalculatorClient.Builder()
    .basicAuthCredentials("BasicAuthUserName", "BasicAuthPassword")
    .build();
```

### Authorization

This API uses `Basic Authentication`.

### Test the SDK

The generated code and the server can be tested using automatically generated test cases.
JUnit is used as the testing framework and test runner.

In Eclipse, for running the tests do the following:

1. Select the project SimpleCalculatorLib from the package explorer.
2. Select `Run -> Run as -> JUnit Test` or use `Alt + Shift + X` followed by `T` to run the Tests.

## Client Class Documentation

### SimpleCalculatorClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

#### Controllers

| Name | Description | Return Type |
|  --- | --- | --- |
| `getAPIController()` | Provides access to Client controller. | `APIController` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `shutdown()` | Shutdown the underlying HttpClient instance. | `void` |
| `getEnvironment()` | Current API environment. | `Environment` |
| `getHttpClient()` | The HTTP Client instance to use for making HTTP requests. | `HttpClient` |
| `getTimeout()` | The timeout to use for making HTTP requests. | `long` |
| `getHttpClientConfig()` | Http Client Configuration instance. | `ReadonlyHttpClientConfiguration` |
| `getBaseUri(Server server)` | Get base URI by current environment | `String` |
| `getBaseUri()` | Get base URI by current environment | `String` |

## API Reference

### List of APIs

* [API](#api)

### API

#### Overview

##### Get instance

An instance of the `APIController` class can be accessed from the API Client.

```
APIController aPIController = client.getAPIController();
```

#### Calculate

```java
CompletableFuture<Double> calculateAsync(
    final String operation,
    final double number1,
    final double number2)
```

##### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | `String` | Template, Required | The operation to be applied on the operands |
| `number1` | `double` | Query, Required | - |
| `number2` | `double` | Query, Required | - |

##### Server

`Server.ENUM_DEFAULT`

##### Response Type

`double`

##### Example Usage

```java
String operation = "operation4";
double number1 = 41.48;
double number2 = 76.02;

aPIController.calculateAsync(operation, number1, number2).thenAccept(result -> {
    // TODO success callback handler
}).exceptionally(exception -> {
    // TODO failure callback handler
    return null;
});
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

This is a Helper class with commonly used utilities for the SDK.

#### Fields

| Name | Description | Type |
|  --- | --- | --- |
| mapper | Deserialization of Json data. | `ObjectMapper` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `serialize(Object obj)` | Json Serialization of a given object. | `String` |
| `deserialize(String json)` | Json deserialization of the given Json string. | `LinkedHashMap<String, Object>` |
| `deserialize(String json, Class<T> clazz)` | Json deserialization of the given Json string. | `<T extends Object> T` |
| `deserialize(String json, TypeReference<T> typeReference)` | JSON Deserialization of the given json string. | `<T extends Object> T` |
| `deserializeArray(String json, Class<T[]> classArray)` | JSON Deserialization of the given json string. | `<T extends Object> List<T>` |

### FileWrapper Class

Class to wrap file and contentType to be sent as part of a HTTP request.

#### Constructors

| Name | Description |
|  --- | --- |
| `FileWrapper(File file)` | Initialization constructor. |
| `FileWrapper(File file, String contentType)` | Initialization constructor. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getFile()` | File instance. | `File` |
| `getContentType()` | Content type of the file. | `String` |

## Common Code Documentation

### HttpRequest Class

Class for creating and managing HTTP Requests.

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpRequest(HttpMethod method, StringBuilder queryUrlBuilder, Headers headers, Map<String, Object> queryParameters, List< SimpleEntry < String, Object >> parameters)` | Initializes a simple http request. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getHttpMethod()` | HttpMethod for the http request. | `HttpMethod` |
| `getHeaders()` | Headers for the http request. | `Headers` |
| `getQueryUrl()` | Query url for the http request. | `String` |
| `getParameters()` | Parameters for the http request. | `List<SimpleEntry<String, Object>>` |
| `getQueryParameters()` | Query parameters for the http request. | `Map<String, Object>` |
| `addQueryParameter(String key, Object value)` | Add Query parameter in http request. | `void` |

### HttpResponse Class

Class to hold HTTP Response.

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpResponse(int code, Headers headers, InputStream rawBody)` | Constructor for HttpResponse. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getStatusCode()` | HTTP Status code of the http response.. | `int` |
| `getHeaders()` | Headers of the http response. | `Headers` |
| `getRawBody()` | Raw body of the http response. | `InputStream` |

### HttpStringResponse Class

Class to hold response body as string.

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpStringResponse(int code, Headers headers, InputStream rawBody, String body)` | Constructor for HttpStringResponse. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getStatusCode()` | HTTP Status code of the http response. | `int` |
| `getHeaders()` | Headers of the http response. | `Headers` |
| `getBody()` | String body of the http response. | `String` |

### HttpContext Class

Class to wrap the request sent to the server and the response received from the server.

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpContext(HttpRequest request, HttpResponse response)` | Constructor for HttpContext. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getRequest()` | Getter for the Http Request. | `HttpRequest` |
| `getHttpContext()` | Getter for the Http Response. | `HttpContext` |

### HttpBodyRequest Class

HTTP Request with an explicit body.

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpBodyRequest(HttpMethod method, StringBuilder queryUrlBuilder, Headers headers, Map<String, Object> queryParams, Object body)` | Create a request with explicit body. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getBody()` | Body for the http request. | `Object` |

### HttpCallback Interface

Callback to be called before and after the HTTP call for an endpoint is made.

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `onBeforeRequest(HttpRequest request)` | Callback called just before the HTTP request is sent. | `void` |
| `onAfterResponse(HttpContext context)` | Callback called just after the HTTP response is received. | `void` |

### Headers Class

Class for creating and managing HTTP Headers.

#### Constructors

| Name | Description |
|  --- | --- |
| `Headers()` | Default constructor. |
| `Headers(Map<String, List<String>> headers)` | Constructor that creates a new instance using a given Map. |
| `Headers(Headers h)` | Copy Constructor. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `has(String headerName)` | Use to check if the given name is present in headers. | `boolean` |
| `names()` | Returns a Set containing all header names. | `Set<String>` |
| `value(String headerName)` | Returns the first value associated with a given header name, or null if the header name is not found. | `String` |
| `values(String headerName)` | Returns a List of all values associated with a given header name, or null if the header name is not found. | `List<String>` |
| `asSimpleMap()` | Returns a Map of the headers, giving only one value for each header name. | `Map<String, String>` |
| `asMultimap()` | Returns a simulated MultiMap of the headers. | `Map<String, List<String>>` |
| `cloneHeaderMap(Map<String, List<String>> headerMap)` | Clones a header map. | `Map<String, List<String>>` |
| `add(String headerName, String value)` | Adds a value for a header name to this object. | `void` |
| `add(String headerName, List<String> values)` | Adds a List of values for a header name to this object. | `void` |
| `addAllFromMap(Map<String, String> headers)` | Adds values from a Map to this object. | `void` |
| `addAllFromMultiMap(Map<String, List<String>> headers)` | Adds values from a simulated Multi-Map to this object. | `void` |
| `addAll(Headers headers)` | Adds all the entries in a Headers object to this object. | `void` |
| `remove(String headerName)` | Removes the mapping for a header name if it is present. | `List<String>` |

### ApiException Class

This is the base class for all exceptions that represent an error response from the server.

#### Constructors

| Name | Description |
|  --- | --- |
| `ApiException(String reason)` | Initialization constructor. |
| `ApiException(String reason, HttpContext context)` | Initialization constructor. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getResponseCode()` | The HTTP response code from the API request | `int` |
| `getHeaders()` | The HTTP response body from the API request. | `Headers` |

### Configuration Interface

This is the base class for all exceptions that represent an error response from the server.

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `getEnvironment()` | Current API environment. | `Environment` |
| `getTimeout()` | The timeout to use for making HTTP requests. | `long` |
| `getHttpClientConfig()` | Http Client Configuration instance. | `ReadonlyHttpClientConfiguration` |
| `getBaseUri(Server server)` | Get base URI by current environment. | `String` |
| `getBaseUri()` | Get base URI by current environment. | `String` |

