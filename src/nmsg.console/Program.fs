//// Receiving data sent from Edge extensions
//let msg = receive()
//MessageBox.Show(msg) |> ignore

//// Send data to Edge extensions
//send """{ "x": 100 }"""

type Data = { text: string }

while true do
  // Receiving data sent from Edge extensions
  let msg = receive()
  let json = deserialize<Data>(msg)

  // Send data to Edge extensions
  send $"""{{ "now": "{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}", "msg": "{json.text}" }}"""

