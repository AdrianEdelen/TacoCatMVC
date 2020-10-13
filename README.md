# TacocaT MVC
This is a port of the JavaScript challenge TacoCat demonstrating working with If/Else logic using a simple MVC design pattern

for more of my work check out my **[portfolio](https://adrianedelen.com)**
### the main Logic 
```csharp
public IActionResult Solve(string theWord, string anotherWord)
        {
            if (string.IsNullOrWhiteSpace(theWord) || string.IsNullOrWhiteSpace(anotherWord))
            {
                return View();
            }
            var result = theWord.ToLower().Replace(" ","");
            var result2 = anotherWord.ToLower().Replace(" ", "");
            var reverse = string.Join("", result.Reverse().ToArray());
            var reverse2 = string.Join("", result2.Reverse().ToArray());
            if (reverse == result && reverse2 == result2)
            {
                ViewData["BothPal"] = "Both " + result + " and " + result2 + " are palindromes";
            } else if ( reverse == result)
            {
                ViewData["FirstPal"] = result + " is a palindrome";
            } else if (reverse2 == result2)
            {
                ViewData["secondPal"] = result2 + " is a palindrome";
            } else
            {
                ViewData["NoPal"] = "Neither words are palindromes";
            }

            ViewData["ReversedWord"] = reverse;
            ViewData["reversedWordTwo"] = reverse2;
            return View();


        }
```
