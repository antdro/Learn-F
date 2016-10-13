// illustrates pattern search
namespace TryFsharp
    module ActivePatterns = 
        
        // print found elements in line with pattern specified
        let doActivePatterns = 
            
            let input = [ (1., 2., 0.); (2., 1., 1.); (3., 0., 1.) ]
            
            // define recursive function
            let rec search lst =
              //define match pattern  
              match lst with
              // split list into first element and the remainder
              // check if a list element match a triple with first element being 1.0, bind last
              // element in that triple to name z
              | (1., _, z) :: tail -> 
                  printfn "found x=1. and z=%f" z; search tail
              // split list into first element and the remainder
              // check if a list element match a triple with first element being 2.0
              | (2., _, _) :: tail -> 
                  printfn "found x=2."; search tail
              // for all other cases go to list remainder
              | _ :: tail -> search tail
              // remainder list is empty -> exit rec function
              | [] -> printfn "done."
            
            // function showcase
            search input

