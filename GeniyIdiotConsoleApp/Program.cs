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

static string[] GetDiagnoses(int countDiagnoses)
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

int countQuestions = 5;
string[] questions = GetQuestions(countQuestions);
int[] answers = GetAnswers(countQuestions);
string[] diagnoses = GetDiagnoses(countQuestions + 1);
Console.WriteLine("Добро пожаловать в приложение Гений-идиот!\nВведите Ваше имя: ");
string userName = Console.ReadLine();
while(true)
{
    int countRightAnswers = 0;
    var randomArray = GetRandomArray(countQuestions);
    for (int i = 0; i < countQuestions; i++)
    {
        Console.WriteLine("Вопрос №" + (i + 1));
        Console.WriteLine(questions[randomArray[i]]);
        int userAnswer = Convert.ToInt32(Console.ReadLine());
        int rightAnswer = answers[randomArray[i]];
        if (userAnswer == rightAnswer)
        {
            countRightAnswers++;
        }
    }

    Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
    Console.WriteLine($"{userName}, Ваш диагноз: {diagnoses[countRightAnswers]}");
    Console.WriteLine("Желаете пройти тест заново? Введите да/нет.");
    string userAnswerContinue = Console.ReadLine().ToLower();
    if (userAnswerContinue == "нет") break;
}

