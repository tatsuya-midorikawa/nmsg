# nmsg
![icon](https://raw.githubusercontent.com/tatsuya-midorikawa/nmsg/main/assets/msg.png)

## Introduction

'nmsg' is a library that helps develop apps for Edge / Chrome extensions that use Native messaging.

## Overview

### 1. receive() / Nmsg.Receive()
receive() / Nmsg.Receive() is used to receive messages from the extensions.

```fsharp
let msg = receive()
```

```csharp
var msg = Nmsg.Receive()
```

### 2. send(json) / Nmsg.Send(json)
Sends a JSON message to the extension using send(json) / Nmsg.Send(json).

```fsharp
send """{ "x": 100 }"""
```

```csharp
Nmsg.Send("{ \"x\": 100 }")
```