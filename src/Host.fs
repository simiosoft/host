namespace Simiosoft.Host

module Host =

    let environment = Environment.current

    let settings<'T> = Settings.configure<'T>()
