namespace TryFsharp
    module FunctionComposition = 
        
        let showcaseFunctionComposition = 

            let add n x = x + n
            let multiply n x = x * n
            let square x = x * x

            let x = 5
            // composition
            let add1multiply3 = add 1 >> multiply 3
            let multiply5add2 = multiply 5 >> add 2
            // reverse composition
            let multiply3add1 = add 1 << multiply 3   
            let squareadd10 = add 10 << square         

            printfn "forward: (1 + %d) * 3 = %d" x (add1multiply3 x)
            printfn "forward: 5 * %d + 2 = %d" x (multiply5add2 x)
            printfn "backward: 3 * %d + 1 = %d" x (multiply3add1 x)
            printfn "backward: %d^2 + 10 = %d\n" x (squareadd10 x)

            // another example

            // straight composition
            let myList = []
            if not (myList |> List.isEmpty |> not) then
                printfn "myList |> List.isEmpty |> not: returns False"
            
            // reverse composition
            if not (myList |> (not << List.isEmpty)) then 
                printfn "myList |> (not << List.isEmpty): returns False"