// Translated from C# by ChatGPT (This file exists only for protocol)
type Solution() =
    static member GetSumOfCommonPriorities(input: string) =
        let lines = input.Split([| Environment.NewLine |], StringSplitOptions.TrimEntries)
        let result = 0

        for line in lines do
            let compartmentOne = line.Substring(0, line.Length / 2)
            let compartmentTwo = line.Substring(line.Length / 2, line.Length / 2)
            let common = compartmentOne.Intersect(compartmentTwo).FirstOrDefault()
            result <- result + (if common > 96 then common - 96 else common - 38)

        result
