namespace jp.midoliy.nmsg

type public json = string

[<AutoOpen>]
[<CompiledName("Nmsg")>]
module Core =

  open System
  open System.IO
  open System.Text

  [<CompiledName("Receive")>]
  let inline public receive () =
    // Native messaging protocol
    //  ---------------------------------------------------------------------
    // | JSON data size (32bit) |             UTF-8 encoded JSON             |
    //  ---------------------------------------------------------------------

    // Connect to standard input stream
    use stdin = Console.OpenStandardInput()

    // Read JSON data size
    let size = Array.zeroCreate 4
    let read_size = stdin.Read(size, 0, 4)
    let length = if read_size = 0 then 0 else BitConverter.ToInt32(size, 0);

    // Read UTF-8 encoded JSON
    let buffer = Array.zeroCreate length
    use reader = new StreamReader(stdin)
    while 0 <= reader.Peek() do
      reader.Read(buffer, 0, buffer.Length) |> ignore

    // Convert to string value
    string buffer
    
  [<CompiledName("Send")>]
  let inline public send (msg: json) =
    // Native messaging protocol
    //  ---------------------------------------------------------------------
    // | JSON data size (32bit) |             UTF-8 encoded JSON             |
    //  ---------------------------------------------------------------------
  
    // Connect to standard output stream
    use stdout = Console.OpenStandardOutput()

    // Get bytes from json string
    let bytes = Encoding.UTF8.GetBytes(msg)

    // Write JSON data size
    stdout.WriteByte((bytes.Length >>> 0) &&& 0xFF |> byte)
    stdout.WriteByte((bytes.Length >>> 8) &&& 0xFF |> byte)
    stdout.WriteByte((bytes.Length >>> 16) &&& 0xFF |> byte)
    stdout.WriteByte((bytes.Length >>> 24) &&& 0xFF |> byte)

    // Write UTF-8 encoded JSON
    stdout.Write(bytes, 0, bytes.Length)
    stdout.Flush()
