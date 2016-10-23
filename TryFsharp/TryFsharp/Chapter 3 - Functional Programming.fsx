module FunctionValues =
    // lambda function example
    let list = [1..10]
    printfn "list: %A\nnegative list: %A" list (List.map (fun i -> -i) list)

    // partion application 
    //***********************************************************************
    
    // append to Log.txt
    open System.IO

    let appendFile (filename: string) (text: string) =
        use file = new StreamWriter(filename, true)
        file.WriteLine(text)
        file.Close()
    
    let sourceDirectory = __SOURCE_DIRECTORY__
    let fileName = sourceDirectory + "\Log.txt"
    let appendLogFile = appendFile fileName
    appendLogFile "File checking have beem completed"

    // print numbers, use printfn as a base for partial function application
    let printNumbers = printfn "number: %d"
    printNumbers 5

    
    // functions returning functions
    //***********************************************************************
    
    let funcPowerOfBase (baseToRaise:float) = (fun exponent -> baseToRaise**exponent)
    let powerOfTwo = funcPowerOfBase 2.0
    let powerOfThree = funcPowerOfBase 3.0

    let power = 8.0
    printfn "2^%.0f = %.0f" power (powerOfTwo power)
    printfn "3^%.0f = %.0f" power (powerOfThree power)

    

