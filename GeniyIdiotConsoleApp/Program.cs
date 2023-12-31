﻿var countQuestions = 5;
string[] questions = GetQuestions(countQuestions);
int[] answers = GetAnswers(countQuestions);
string[] diagnoses = GetDiagnoses();
while(true)
{
    Console.WriteLine("Добро пожаловать в приложение Гений-идиот!\nВведите Ваше имя: ");
    var userName = Console.ReadLine();
    var countRightAnswers = 0;
    var randomArray = GetRandomArray(countQuestions);
    for (var i = 0; i < countQuestions; i++)
    {
        Console.WriteLine("Вопрос №" + (i + 1));
        Console.WriteLine(questions[randomArray[i]]);
        Console.WriteLine("Введите ответ:");
        var userAnswer = GetUserAnswer();
        var rightAnswer = answers[randomArray[i]];
        if (userAnswer == rightAnswer)
        {
            countRightAnswers++;
        }
    }
    Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
    var userDiagnose = GetDiagnose(countRightAnswers);
    Console.WriteLine($"{userName}, Ваш диагноз: {userDiagnose}");
    await WriteResultToFile(userName, countRightAnswers, userDiagnose);
    var userAnswerContinue = GetUserAnswerContinue();
    if (!userAnswerContinue) break;
}

async Task WriteResultToFile(string? userName, int countRightAnswers, string userDiagnose)
{
    using (StreamWriter writer = new StreamWriter(@".\usersResult.txt", true))
    {
        await writer.WriteLineAsync($"{userName} {countRightAnswers} {userDiagnose}");
    }
}

string GetDiagnose(int countRightAnswers)
{
    var percentRightAnswers = countRightAnswers * 100 / countQuestions;
    if (percentRightAnswers >= 0 && percentRightAnswers<=10) return diagnoses[0];
    if (percentRightAnswers > 10 && percentRightAnswers <= 30) return diagnoses[1];
    if (percentRightAnswers > 30 && percentRightAnswers <= 50) return diagnoses[2];
    if (percentRightAnswers > 50 && percentRightAnswers <= 70) return diagnoses[3];
    if (percentRightAnswers > 70 && percentRightAnswers <= 90) return diagnoses[4];
    else return diagnoses[5];
}

static int GetUserAnswer()
{
    var userAnswer = 0;
    while(true)
    {
        bool success = Int32.TryParse(Console.ReadLine(), out userAnswer);
        if (success) return userAnswer;
        else Console.WriteLine("Пожалуйста, введите число!");
    }
}

static bool GetUserAnswerContinue()
{
    while (true)
    {
        Console.WriteLine("Желаете пройти тест заново? Введите да/нет.");
        var userAnswerContinue = Console.ReadLine().ToLower();
        if (userAnswerContinue == "да") return true;
        if (userAnswerContinue == "нет") return false;
    }
}

static string[] GetQuestions(int countQuestions)
{
    string[] questions = new string[countQuestions];
    questions[0] = "Сколько будет два плюс два умноженное на два?";
    questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
    questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
    questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
    questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
    return questions;
}

static int[] GetAnswers(int countAnswers)
{
    int[] answers = new int[countAnswers];
    answers[0] = 6;
    answers[1] = 9;
    answers[2] = 25;
    answers[3] = 60;
    answers[4] = 2;
    return answers;
}

static string[] GetDiagnoses()
{
    string[] diagnoses = new string[6];
    diagnoses[0] = "кретин";
    diagnoses[1] = "идиот";
    diagnoses[2] = "дурак";
    diagnoses[3] = "нормальный";
    diagnoses[4] = "талант";
    diagnoses[5] = "гений";
    return diagnoses;
}

static int[] GetRandomArray(int countQuestion)
{
    var random = new Random();
    int[] arrayRandom = Enumerable.Range(0, countQuestion).OrderBy(x => random.Next()).ToArray();
    return arrayRandom;
}
