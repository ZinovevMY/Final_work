//Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше или равна 3 символам.

int Prompt(string message)
{
    System.Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

string[] GenerateArray(int length)
{
    string[] answer = new string[length];
    for (int i = 0; i < answer.Length; i++)
    {
        answer[i] = StringGenerate();
    }
    return answer;
}

string StringGenerate()
{
    Random rand = new Random();
    int stringlen = rand.Next(1, 10);
    int randValue = 0;
    string str = "";
    char letter;
    for (int i = 0; i < stringlen; i++)
    {
        randValue = rand.Next(0, 26);
        letter = Convert.ToChar(randValue + 65);
        str = str + letter;
    }
    return str;
}

int ShortWordsCount(string[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= 3)
        {
            count++;
        }
    }
    if (count == 0) return 0;
    return count;
}

int[] ShortWordIndexes(string[] array, int count)
{
    int[] answer = new int[count];
    for (int i = 0; i < answer.Length;)
    {
        for (int j = 0; j < array.Length; j++)
        {
            if (array[j].Length <= 3)
            {
                answer[i] = j;
                i++;
            }
        }
    }
    return answer;
}


void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write(array[i]+ "\t");
    }
    System.Console.WriteLine();
}

int arrlength = Prompt("Введите длину массива строк: ");
string[] stringArray = GenerateArray(arrlength);
int resarrlength = ShortWordsCount(stringArray);
if (resarrlength > 0)
{
    string[] resultArray = GenerateArray(resarrlength);
    int[] indexArray = ShortWordIndexes(stringArray, resarrlength);
    for (int i = 0; i < resultArray.Length; i++)
    {
        resultArray[i] = stringArray[indexArray[i]];
    }
    PrintArray(stringArray);
    PrintArray(resultArray);
}
else
{
    System.Console.WriteLine("В массиве нет слов короче 3 букв!");
}
