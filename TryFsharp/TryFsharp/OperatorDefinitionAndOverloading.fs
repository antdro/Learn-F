namespace TryFsharp
    module OperatorDefinitionAndOverloading =
        open System.Text.RegularExpressions
        
        // showcase of operator definition
        let printOperatorDefinition = 
            
            // strings
            let str = "The current version is 7.0"
            let test = @"([\d\.]+)"

            // operators definition
            let (^?) a b = Regex.IsMatch(a, b)  // is match found
            let (^!) a b = Regex.Match(a, b)    // what was found
            let (!@) (a: Match) = a.Groups.Count - 1 // number of matches found
            let (^@) (a: Match) (b: int) = a.Groups.[b].Value //get the value of b's match group
            
            // check if str has test and print number of matches and corresponding match value
            if str ^? test then
                let found = str ^! test
                printfn "%d groups found and the value is %s" !@found (found ^@ 1)

        
        // showcase of operator overloading
        // type definition
        type Point (x: float, y:float) = 
            member this.X = x
            member this.Y = y
            
            // + operator overloading
            static member (+) (p1: Point, p2: Point) = 
                new Point(p1.X + p2.X, p1.Y + p2.Y)
         

