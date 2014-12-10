﻿module viewfiles.Main

open System
open Nancy.Hosting

type DemoApp () =
    inherit Nancy.NancyModule()
    do
        let Get = base.Get
        Get.["/"] <- fun parameters -> "Hello from F#/Nancy on Dokku-Alt!" :> obj

[<EntryPoint>]
let main args =
    let env_port = Environment.GetEnvironmentVariable("PORT")
    let port = if env_port = null then "5000" else env_port
    let localUri = "http://localhost:" + port
    let productionUri = "http://mono1.do.daves.rocks:80"
    let nancy_host = new Nancy.Hosting.Self.NancyHost(Uri(localUri))
    nancy_host.Start()
    printfn "listening on %s" localUri
    while true do Console.ReadLine() |> ignore
    0
