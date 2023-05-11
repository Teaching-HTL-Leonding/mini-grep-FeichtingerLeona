[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/2OKjtBuX)
# GREP

## Introduction

In this exercise, you have to implement a simplified version of the Linux [grep](https://www.geeksforgeeks.org/grep-command-in-unixlinux/) command.

**Note** that you can find a [ZIP file with files](./test_data.zip) together with this sample. Running your program should print the sample output as shown below. The order in which the files are printed on the screen does *not* matter.

## Requirements - Level 1

Write a command-line tool.

The command-line tool accepts three command-line arguments:

1. The path in which you have to search (e.g. `C:\TEMP`)
2. A file name pattern (e.g. `*.txt`)
3. A search text (e.g. `Hello`)

Your tool must use a method of the [`Directory` class](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory) (e.g. [`Directory.GetFiles`](vhttps://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles)) to get all files in the given path (first argument) that match the given file name pattern (second argument).

Next, your program has to open one file after the other, read the text in it, and check if the file content contains the given search text (third argument). If it does, you have to print the full path of the file on the screen (e.g. `C:\TEMP\greeting.txt`). If it does not contain the given search text, ignore the file.

Sample output:

```txt
dotnet run -- C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
C:\TEMP\hello.txt
C:\TEMP\world.txt
```

## Requirements - Level 2

In addition to the full path of the file, your program has to print the line number and the line content where the given search text was found. Note that a file can contain the search text multiple times.

Sample output:

```txt
dotnet run -- C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
    5: When Eve saw Adam, she said: "Hello"
C:\TEMP\hello.txt
    3: Use the word "Hello" to great people in English.
    17: Programmers often call simple apps 'Hello World' programs.
C:\TEMP\world.txt
    6: Hello to all the girld! Hello to all the boys!
```

## Requirements - Level 3

At the end of the output, you have to print a summary consisting of:

* Total number of files that contain the given search text at least once.
* Total number of lines that contain the given search text at least once.
* Total number of occurences of the given search text in all files.

```txt
dotnet run -- C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
    5: When Eve saw Adam, she said: "Hello"
C:\TEMP\hello.txt
    3: Use the word "Hello" to great people in English.
    17: Programmers often call simple apps 'Hello World' programs.
C:\TEMP\world.txt
    6: Hello to all the girld! Hello to all the boys!
SUMMARY:
    Number of found files: 3
    Number of found lines: 4
    Number of occurences: 5
```

## Requirements - Level 4

Your program must highlight the search text by enclosing it in `>>>` and `<<<`. It must also print the search text in uppercase letters.

```txt
dotnet run -- C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
    5: When Eve saw Adam, she said: ">>>HELLO<<<"
C:\TEMP\hello.txt
    3: Use the word ">>>HELLO<<<" to great people in English.
    17: Programmers often call simple apps '>>>HELLO<<< World' programs.
C:\TEMP\world.txt
    6: >>>HELLO<<< to all the girld! >>>HELLO<<< to all the boys!
SUMMARY:
    Number of found files: 3
    Number of found lines: 4
    Number of occurences: 5
```

## Requirements - Level 5

The arguments can contain the optional parameter `-i`. It stands for *case-insensitive search*. The `-i` argument can appear anywhere in the list of arguments. Therefore, all of the following command lines are valid:

* `dotnet run -- C:\TEMP *.txt Hello`
* `dotnet run -- -i C:\TEMP *.txt Hello`
* `dotnet run -- C:\TEMP -i *.txt Hello`
* `dotnet run -- C:\TEMP *.txt -i Hello`
* `dotnet run -- C:\TEMP *.txt Hello -i`

If the user specifies `-i`, casing is ignored. **Tip:** Use your favorite search engine or AI assistant to find out how to compare case insensitive.

```txt
dotnet run -- -i C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
    5: When Eve saw Adam, she said: ">>>HELLO<<<"
    6: Adam answered with : "Oh, >>>HELLO<<< Eve, nice to see you."
C:\TEMP\hello.txt
    3: Use the word ">>>HELLO<<<" to great people in English.
    17: Programmers often call simple apps '>>>HELLO<<< World' programs.
    18: Such '>>>HELLO<<< world' programs are often used as exercises.
C:\TEMP\world.txt
    6: >>>HELLO<<< to all the girld! >>>HELLO<<< to all the boys!
SUMMARY:
    Number of found files: 3
    Number of found lines: 6
    Number of occurences: 7
```

## Requirements - Level 6 (hard)

If the user specifies `-R` (for *recursive*), you have to search through all files in the given folder **and** in all subfolders. Note that `-R` can be optionally combined with `-i` to `-iR` or `-Ri`. However, both option can be specified separately, too.

 **Tip:** Use your favorite search engine or AI assistant to find out how to get files recursively.

```txt
dotnet run -- -iR C:\TEMP *.txt Hello
C:\TEMP\greeting.txt
    5: When Eve saw Adam, she said: ">>>HELLO<<<"
    6: Adam answered with : "Oh, >>>HELLO<<< Eve, nice to see you."
C:\TEMP\Subfolder\words.txt
    3: >>>HELLO<<<, >>>HELLO<<<
C:\TEMP\hello.txt
    3: Use the word ">>>HELLO<<<" to great people in English.
    17: Programmers often call simple apps '>>>HELLO<<< World' programs.
    18: Such '>>>HELLO<<< world' programs are often used as exercises.
C:\TEMP\world.txt
    6: >>>HELLO<<< to all the girld! >>>HELLO<<< to all the boys!
SUMMARY:
    Number of found files: 4
    Number of found lines: 7
    Number of occurences: 9
```
