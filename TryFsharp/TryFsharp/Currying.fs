// this example illustrates how to use function specialization also called currying
open System

// define add function    
let add x y = x + y

// define increment function using currying (function specialization)
// increment function receives one agrument and pass it as 'y' to add function where 'x' is set to 1 
let increment = add 1 

// another syntax of specializing increment function
let increment2 y = add 1 y

// showcase
printfn "Function Specialization:"
let inc = increment 5
printfn "1: Incremented value of %i is %i" 5 inc
let inc2 = increment2 10
printfn "2: Incremented value of %d is %d" 10 inc2


// using Specialized Filters
printfn "\nUsing Specialized Filters: "
// function returns the number of even values from a list
let searchEven = List.filter (fun v -> v%2 = 0)
printfn "The number of even numbers in [1..100] is %d." ([1..100] |> searchEven |> List.length)


// using swapping arguments to enable currying to substration
printfn "\nSwapping Arguments:"
// substraction function
let sub x y = x - y
// any 2 args function passed as an argument to swapargs function gets its arguments swapped
let swapargs f x y = f y x 
// substracts 10 from passed value
let decBy10 = swapargs sub 10
printfn "%d - 10 = %d" 30 (decBy10 30)

// prevent window from closure
System.Console.ReadKey() |> ignore
0 |> ignore // return an integer exit code