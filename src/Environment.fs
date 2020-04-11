namespace Simiosoft.Host

open System

type Environment =
    | Production
    | Beta
    | Local

module internal Environment =

    [<Literal>]
    let private SIMIOSOFT_ENVIRONMENT = "SIMIOSOFT_ENVIRONMENT"
    [<Literal>]
    let private PRODUCTION = "production"
    [<Literal>]
    let private BETA = "beta"

    let current =
        let (|CaseInsensitiveEqual|_|) (blueprint:string) (input:string) =
            if blueprint.Equals(input, StringComparison.OrdinalIgnoreCase)
            then Some ()
            else None

        match System.Environment.GetEnvironmentVariable(SIMIOSOFT_ENVIRONMENT) with
        | CaseInsensitiveEqual PRODUCTION -> Production
        | CaseInsensitiveEqual BETA -> Beta
        | _ -> Local
