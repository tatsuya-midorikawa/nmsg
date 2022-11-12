open System.Windows.Forms

// Receiving data sent from Edge extensions
let msg = receive()
MessageBox.Show(msg) |> ignore

// Send data to Edge extensions
send """{ "x": 100 }"""
