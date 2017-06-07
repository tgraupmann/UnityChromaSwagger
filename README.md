# ChromaSDK - the Unity C# library for the Chroma Rest API

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: 0.0.1
- SDK version: 1.0.0
- Build package: io.swagger.codegen.languages.CSharpClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- Unity 3.5.7 or later
- Windows Editor / Standalone

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

<a name="packaging"></a>
## Packaging

Import [UnityChromaSDK.unitypackage](https://github.com/tgraupmann/UnityChromaSwagger/releases/tag/UnityChromaSDK) into your project.

<a name="getting-started"></a>
## Getting Started

1 Open the example scene [Assets/ChromaSDK/Examples/Scenes/Example01.unity](Assets/ChromaSDK/Examples/Scenes/Example01.unity)

2 Customize the example script [Assets/ChromaSDK/Examples/Scripts/ChromaExample01.cs](Assets/ChromaSDK/Examples/Scripts/ChromaExample01.cs)

![image_1](images/image_1.png)

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

* The [RazerApi](Assets/ChromaSDK/SDK/Swagger/razer/README.md) endpoint creates the Chroma session.
* The [ChromaApi](Assets/ChromaSDK/SDK/Swagger/chroma/README.md) endpoint controls Chroma lighting.

<a name="examples"></a>
## Examples

Add the `Chroma` namespace.

```charp
// Access to Chroma data structures
using ChromaSDK.ChromaPackage.Model;

// Access to the Chroma API
using ChromaSDK.Api;

// Access to the Session data structures
using RazerSDK.ChromaPackage.Model;

// Access to the Session API
using RazerSDK.Api;
```

Calls to the `Chroma` API should be done in a separate thread to avoid blocking the main thread and to avoid reducing the rendering frame rate.

```charp
ChromaUtils.RunOnThread(() =>
{
    // Make calls to the Chroma API in a separate thread to avoid blocking the main thread
    Initialize();
});
```

### `Chroma` Initialization

Create an instance of the `RazerAPI` which will be used to create the `Chroma` session.
 
```csharp
 // use the Razer API to get the session
_mApiRazerInstance = new RazerApi();
```

Populate the input to initialize the `Chroma` session.

```csharp
var input = new ChromaSdkInput();
input.Title = "UnityPlugin";
input.Description = "This is a REST interface Unity client";
input.Author = new ChromaSdkInputAuthor();
input.Author.Name = "Chroma Developer";
input.Author.Contact = "www.razerzone.com";
input.DeviceSupported = new List<string>
{
    "keyboard",
    "mouse",
    "headset",
    "mousepad",
    "keypad",
    "chromalink",
};
input.Category = "application";
```

`PostChromaSdk` creates a `Chroma` session which is used to control the `Chroma` lighting.

```csharp
// create the Chroma session, the result contains the session and base uri for the Chroma API
PostChromaSdkResponse result = _mApiRazerInstance.PostChromaSdk(input);
```

Use the response from creating the `Chroma` session to create an instance of the `Chroma` API.

```charp
// setup the api instance with the session uri
_mApiChromaInstance = new ChromaApi(result.Uri);
```

### `Chroma` Heartbeat

After the `Chroma` instance has been created, repeatedly call `Heartbeat` to keep the `Chroma` session alive.

```csharp
while (true)
{
    // The Chroma API uses a heartbeat every 1 second
    _mApiChromaInstance.Heartbeat();

    // Wait for a sec
    Thread.Sleep(1000);
}
```

### Destroy the `Chroma` session

Destroy the `Chroma` session from `OnDisable` and `OnApplicationQuit` to return lighting control to the system.

```csharp
// destroy the Chroma session
DeleteChromaSdkResponse result = _mApiChromaInstance.DeleteChromaSdk();

// clear the references
_mApiRazerInstance = null;
_mApiChromaInstance = null;
```

### `PUT` vs `POST`

In the `Chroma` API there are two kinds of methods.
`PUT` applies the lighting effect immediately.
`POST` creates an `Effect` identifier that can be reused instead of applying the lighting effect. 

### `PUT` Effect

`PutEffect` activates an effect or effects. An effect is a string identifier. The `EffectIdentifierInput` constructor takes a single effect string or a list of effect strings.

```charp
// use a string effect
var input = new EffectIdentifierInput(effect, null);

// use a list of string effects
var input = new EffectIdentifierInput(null, effects);

// activate the effect or effects
EffectIdentifierResponse result = _mApiChromaInstance.PutEffect(input);
```

### `REMOVE` Effect

`RemoveEffect` takes the same `EffectIdentifierInput` as `PutEffect`. Effects can be deleted for a string effect or a list of string effects.

```charp
// use a string effect
var input = new EffectIdentifierInput(effect, null);

// use a list of string effects
var input = new EffectIdentifierInput(null, effects);

// Remove the effect or effects
EffectIdentifierResponse result = _mApiChromaInstance.RemoveEffect(input);
```

### `PUT` `CHROMA_NONE` Effect

Set the `CHROMA_NONE` effect to clear the device lighting effects.

**ChromaLink**

```charp
EffectResponse result = _mApiChromaInstance.PutChromaLinkNone();
```

**Headset**

```charp
EffectResponse result = _mApiChromaInstance.PutHeadsetNone();
```

**Keyboard**

```charp
EffectResponse result = _mApiChromaInstance.PutKeyboardNone();
```

**Keypad**

```charp
EffectResponse result = _mApiChromaInstance.PutKeypadNone();
```

**Mouse**

```charp
EffectResponse result = _mApiChromaInstance.PutMouseNone();
```

**Mousepad**

```charp
EffectResponse result = _mApiChromaInstance.PutMousepadNone();
```

### `POST` `CHROMA_NONE` Effect

Create an effect identifier with the `CHROMA_NONE` effect to clear the device lighting effects.

**ChromaLink**

```charp
EffectResponseId result = _mApiChromaInstance.PostChromaLinkNone();
```

**Headset**

```charp
EffectResponse result = _mApiChromaInstance.PostHeadsetNone();
```

**Keyboard**

```charp
EffectResponse result = _mApiChromaInstance.PostKeyboardNone();
```

**Keypad**

```charp
EffectResponse result = _mApiChromaInstance.PostKeypadNone();
```

**Mouse**

```charp
EffectResponse result = _mApiChromaInstance.PostMouseNone();
```

**Mousepad**

```charp
EffectResponse result = _mApiChromaInstance.PostMousepadNone();
```
