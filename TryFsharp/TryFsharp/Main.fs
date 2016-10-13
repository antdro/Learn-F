namespace TryFsharp
    module Main = 
        open System
        open Currying
        open OperatorDefinitionAndOverloading
        open ActivePatterns

        [<EntryPoint>]
        let main args = 
            
            // Currying.printCurrying
            // OperatorDefinitionAndOverloading.printOperatorDefinition
            
            // display operator overloading
            // let p1, p2 = new Point(1., 2.), new Point(2., 3.)
            // let p3 = p1 + p2
            // let x, y = p3.X, p3.Y
            // Console.WriteLine ("Point's coordinates: X = {0}, Y = {1}", x, y)           

            doActivePatterns



            // prevent window from closure
            System.Console.ReadKey() |> ignore
            0 // return an integer exit code

