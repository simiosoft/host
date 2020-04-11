namespace Simiosoft.Host

open System.IO
open System.Text
open YamlDotNet.Serialization

module internal Settings =

    let configure<'T> () = 
        let parseYamlFile yamlFilePath =
            use fileStream = File.OpenRead(yamlFilePath)
            use textReader = new StreamReader(fileStream, Encoding.UTF8)
            let deserializer = new Deserializer()
            deserializer.Deserialize<'T>(textReader)
            
        match Environment.current with
        | Production -> parseYamlFile "settings.production.yml"
        | Beta       -> parseYamlFile "settings.beta.yml"
        | Local      -> parseYamlFile "settings.yml"

