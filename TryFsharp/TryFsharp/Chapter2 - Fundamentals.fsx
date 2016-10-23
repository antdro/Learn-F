// CORE TYPES

// Unit
//****************************************************************************
// unit is a representation of void
let x = ();

// in F# any function must return a value
// if function does not return anything by its definition, it returns unit value
printfn "printfn function returns unit value"

// use ignore function to swallow a value and return unit value
let add x y = x + y
add 5 7 |> ignore

// Tuple
//****************************************************************************
// tuple's declaration
let twoNumbers = (1,2)
let nested = ((1,2), (3,4))
let languages = ("F sharp", "Python", "Scala")

// usage of fst and snd functions
printfn "Fist element of tuple nested: %A" (fst nested)
printfn "Second element of tuple nested: %A" (snd nested)

// extracting more than two elements into new names
let first, second, third = languages
printfn "Languages tuple consist of: %s, %s, %s" first second third

// passing parameters vs. passing parameters in the tupled form
let addParams x y = x + y
let addTupledParams (x,y) = x + y
addParams 3 5
addTupledParams(3,5)

// List
//****************************************************************************

// list's declaration
let numbers = [1;2;3;4;5]
let numbers2 = [10;11;12;13]

// using cons operator
// cons adds element to a head of the list
let zeroContainingList = 0 :: numbers 
printfn "cons added 0 to numbers resulting into: %A" zeroContainingList

// using @ operator, @ joins lists
printfn "Extended list is: %A" (numbers @ numbers2)

// List ranges
//****************************************************************************

// .. declares the list range
// if only lower and upper bounds are given, then each element is separated by 1
let list1 = [1 .. 10]

// an option step example, with step = 2
let list2 = [1..2..10]
let list3 = [10..-2..2]
printfn "odd numebrs: %A\neven numbers: %A" list2 list3

// List comprehensions
//****************************************************************************

// list gets made of elements returned via yeild keyword
// list comprehension is a code surrounded by []
// list fully generated in memory

// example with function defined within a comprehension list
let negateEvens list = 
    [   let negate x = -x
        for i in list do
            if i%2 = 0 then
                yield negate i
            else 
                yield i
    ]
let list = [1..6]
printfn "input list: %A\noutput list: %A" list (negateEvens list)

// use -> instead of do yield in a for loop
// print first five powers of given number
// exponential operation works only with floating-point type
let number = 3.0
let firstFivePowers (x:float) = [for i in 1.0..5.0 -> x**i]
printfn "input number: %.1f\npowered list: %A" number (firstFivePowers number)

// find all prime numbers between 1 and given number
// not efficient way of finding primes, for showcase of usage of list comprehs
let listOfPrimesUpToN max =
    [
        for n in 1..max do
            let listOfFactors = 
                [
                for j in 1..n do 
                    if n % j = 0 then
                        yield j 
                ]
            if List.length listOfFactors = 2 then 
                yield n 
    ]

let max = 30
printfn "list of all primes not greater than %d\n%A" max (listOfPrimesUpToN max)

// List module functions
//****************************************************************************

let coord_x = [1;2;3;4;5]
let coord_y = [10;11;12;13;14]

// zip function example
// given x and y coordinates -> build a list of points
printfn "x values: %A\ny values: %A\npoints: %A" coord_x coord_y (List.zip coord_x coord_y)

// partition function example
let isMultipleOf3 x = (x % 3 = 0) 
let multOf3, nonMultOf3 = List.partition isMultipleOf3 coord_y
printfn "\nlist of values: %A\nmultuples of 3: %A\nnot multiples of 3: %A"
    coord_y multOf3 nonMultOf3

// length, head, tail, rev functions
printfn "\ncoord_x list: %A\nits length: %d\nits first element: %A
its tail: %A\nlist in reverse order: %A" 
    coord_x (List.length coord_x) (List.head coord_x) (List.tail coord_x)
    (List.rev coord_x)

// exist function
let l1 = [for i in 1..10 -> i+i*3]
let searchFor = 8
let isEqualSearchFor x = (x = searchFor)

if List.exists isEqualSearchFor l1 then
    printfn "%d is in a list: %A" searchFor l1
else 
    printfn "%d is not in a list: %A" searchFor l1

// filter function
let isGreater30 x = (x > 30)
printfn "elements greater than 30: %A" (List.filter isGreater30 l1)


// Aggregate operators
//****************************************************************************

//List.map
//****************************************************************************
// ('a -> 'b) -> 'a list -> 'b list
let power x = x**3.0
let list4 = [1.0..5.00]
printfn "list: %A\npowered list: %A" list4 (List.map power list4)

//List.fold
//****************************************************************************
// there are two types of folds: list.reduce and list.fold

// List.reduce 
// iterates through each element of a list and builds an accumulator value
// accumulator value - summary of the processing done on the list so far
// type ('a -> 'a -> 'a) -> 'a list -> 'a

// building summation expression from a list of numbers
let sumOfTwoNumbers x y = x + "+" + y
let listOfNumbers = ["1";"33";"21";"56";"9";"10"]

printfn "list of values: %A\nexpression: %A" 
    listOfNumbers (List.reduce sumOfTwoNumbers listOfNumbers)

// List.fold
// allows to build a custom accumulator type
// ('acc -> 'b -> 'acc) -> 'acc -> 'b list -> 'acc

// count vowels in a string
let str = "Fargo is one of the best mvoies I have ever watched"
let countVowels (str:string) =    
    let charList = List.ofSeq str
    let funAcc (As, Es, Is, Os, Us) letter =
        match letter with
        | 'a' -> (As + 1, Es, Is, Os, Us)
        | 'e' -> (As, Es + 1, Is, Os, Us)
        | 'i' -> (As, Es, Is + 1, Os, Us)
        | 'o' -> (As, Es, Is, Os + 1, Us)
        | 'u' -> (As, Es, Is, Os, Us + 1)
        |  _  -> (As, Es, Is, Os, Us)
    List.fold funAcc (0,0,0,0,0) charList

printfn "string: %s\nvowels count: %A" str (countVowels str)


// List.iter
//****************************************************************************
// usually used to handle side effects
// ('a -> unit) -> 'a list -> unit

// print numbers from a list
let printNumbers x = printfn "printing %d" x
let list5 = [1..6]

List.iter printNumbers list5



// Option
//****************************************************************************
// option type is used to represent a value that may or may not exist
// has only two values: Some('a) and None

// retrieve the value of an option type
// print negative values from a list
let list6 = [for i in -10..10 -> i + 3 ]
let isNegative x = (x < 0)
let containsNegative list = 
    let filteredList = List.filter isNegative list
    if List.length filteredList > 0 
    then Some(filteredList)
    else None

if Option.isSome (containsNegative list6) then
    printfn "list: %A\nnegative values: %A"
        list6 (Option.get (containsNegative list6))
else printfn "no negative values were found"
    

//Printfn
//****************************************************************************

//printf
// writes to the screen without adding a line continuation
printf "printf: Hi, this text will not end up with a line continuation, "
printf "printf: \\n will be added with new printf statement\n"

//printfn
// writes to the screen with adding a line continuation
printfn "printfn: Hi, this text will end up with a line continuation"
printfn "printfn: New statement is on a new line as printfn ends with \\n"

//sprintf
// returns string, but not unit type
let s = sprintf "sprintf: this statement will be put in a string s"
printfn "printfn: '%s'" s


// ANATOMY OF AN F# PROGRAM
// F# programs do not require an entry point like 'main function' in C++
// however, code needs to be devided into ogranisation units: modules and namespaces 

