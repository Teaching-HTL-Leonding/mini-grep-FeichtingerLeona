string path = args[0];
string directory = args[1];
string serchingWord = args[2];
int numberOfLines = 0;
int numberOfFiles = 0;
int numberOfOccurences = 0;

string[] directorys = Directory.GetFiles(path, directory);
for (int i = 0; i < directorys.Length; i++)
{
    string filePath = directorys[i];
    FindInFile(filePath, serchingWord, ref numberOfFiles, ref numberOfLines, ref numberOfOccurences);
}
PrintSummary(numberOfFiles, numberOfLines, numberOfOccurences);

void PrintSummary(int numberOfFiles, int numberOfLines, int numberOfOccurences)
{
    System.Console.WriteLine("summary:");
    System.Console.WriteLine($"     Number of found files: {numberOfFiles} ");
    System.Console.WriteLine($"     Number of found lines: {numberOfLines}");
    System.Console.WriteLine($"     Number of occurences: {numberOfOccurences}");
}

void FindInFile(string filePath, string serchingWord, ref int numberOfFiles, ref int numberOfLines, ref int numberOfOccurences)
{

    string text = File.ReadAllText(filePath);
    string[] texts = File.ReadAllLines(filePath);
    if (text.Contains(serchingWord))
    {
        numberOfFiles++;
        System.Console.WriteLine(filePath);
        for (int j = 0; j < texts.Length; j++)
        {
            if (texts[j].Contains(serchingWord))
            {
                numberOfLines++;
                //System.Console.WriteLine($"{j}: , {texts[j]}");
                printTextWithHighlitedSerchedWord(texts[j]);
                string[] singleWordsOfTexts = texts[j].Split(" ");
                for (int k = 0; k < singleWordsOfTexts.Length; k++)
                {
                    if (singleWordsOfTexts[k] == serchingWord)
                    {
                        numberOfOccurences++;
                    }
                }
            }
        }
    }

}

void printTextWithHighlitedSerchedWord(string text)
{
    System.Console.WriteLine();
    string[] singleWordsOfText = text.Split(" ");
    for (int k = 0; k < singleWordsOfText.Length; k++)
    {
        //singleWordsOfText[k].Remove('"');
        if (singleWordsOfText[k].Contains('"'))
        {
            int index = singleWordsOfText[k].LastIndexOf('"')-1;
            singleWordsOfText[k] = singleWordsOfText[k].Substring(1, index);
        }
        if (singleWordsOfText[k] == serchingWord)
        {
            string uppercaseSerchingword = singleWordsOfText[k].ToUpper();
            Console.Write($">>>{uppercaseSerchingword}<<< ");
        }
        else
        {
            Console.Write($"{singleWordsOfText[k]} ");
        }
    }
    System.Console.WriteLine();
}


