using System;
using System.Collections.Generic;
using System.Text;
using dts = FightManager.Services.DiceThrowStatus;

namespace FightManager.Services
{
    public enum DiceThrowStatus
    {
        Success = 0,
        ExtraCharacters = 1,
        FormulaErrors = 2,
        UndifinedError = 3,
        EmptyInputString = 4
    };

    public class DiceThrowInfo
    {
        public dts status { get; set; }
        public string input { get; set; }
        public string straightFormula { get; set; }
        public string subresults { get; }
        public List<int> results { get; set; }
        public bool advantage { get; set; }
        public bool disadvantage { get; set; }

        public DiceThrowInfo(string input, bool advantage, bool disadvantage)
        {
            results = new List<int>();
            this.input = input;
            this.advantage = advantage;
            this.disadvantage = disadvantage;

            status = dts.UndifinedError;
        }
        public int GetResult()
        {
            if (advantage == disadvantage)
            {
                if (results.Count > 0)
                    return results[0];

                return int.MinValue;
            }
            else
            {
                if (results.Count < 2)
                    return int.MinValue;

                if (advantage)
                {
                    return Math.Max(results[0], results[1]);
                }
                else
                {
                    return Math.Min(results[0], results[1]);
                }
            }
        }
    }

    public class DiceRoller
    {
        private Random _random = new Random();
        private char[] _operations = { '+', '-', '*', '/', '^', 'd' };
        public DiceRoller() { }

        private int Roll(int count, int diceSize)
        {
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                result += _random.Next(diceSize) + 1;
            }
            return result;
        }

        /// <summary>
        /// Преобразует строку в форму, более удобную программе - удаляет пробелы, дополняет унарные операции до бинарных, меняет перфиксы костей 'к' на 'd'
        /// </summary>
        /// <param name="input">Входящая строка</param>
        /// <returns>Исправленая строка (без учета внутренних ошибок в написании арифместического выражения)</returns>
        private string Editing(string input)
        {
            string output = input;
            output = output.Replace(" ", string.Empty);     // убираем пробелы
            output = output.Replace("#", "d");
            output = output.Replace("к", "d");              // нормализуем d-операторы

            if (output != null && output != "")
            {
                output = "(" + output;                      // добавляем в начало и в конец открывающую и закрывающую скобку
                output += ")";

                output = output.Replace("(-", "(0-");       // убираем унарные минусы
                string symbols = "+-*/(^";
                for (int i = 0; i < symbols.Length; i++)    // убираем унарные d-операторы
                {
                    output = output.Replace(symbols[i] + "d", symbols[i] + "1d");
                }
                output = output.Remove(0, 1);                   // убираем вспом. скобки
                output = output.Remove(output.Length - 1, 1);
            }

            return output;
        }

        /// <summary>
        /// Проверяет корректность арифметического выражения
        /// </summary>
        /// <param name="formula">Входящая строка</param>
        /// <returns>Возвращает true, если строка является корректным арифметическим выражением. В противном случае значение false</returns>
        private dts CheckCorrection(string formula)
        {
            // проверка на содержание символов
            string symbols = "1234567890()" + new string(_operations);
            string testString = formula;
            foreach (char symbol in symbols)
            {
                testString = testString.Replace(symbol.ToString(), string.Empty);
            }

            if (testString == string.Empty) // если все символы из набора корректных символов
            {
                // проверка последовательности скобок
                int counter = 0;

                foreach (char symbol in formula)
                {
                    if (counter < 0)
                    {
                        return dts.FormulaErrors;
                    }

                    if (symbol == '(')
                        counter++;
                    else if (symbol == ')')
                        counter--;
                }

                if (counter == 0) // кол-во скобок и их порядок в норме
                {
                    testString = formula;
                    testString = testString.Replace("(", string.Empty);
                    testString = testString.Replace(")", string.Empty);
                    string[] parts = testString.Split(_operations);

                    foreach (string part in parts)
                    {
                        int buffer = 0;
                        if (!int.TryParse(part, out buffer))
                        {
                            return dts.FormulaErrors;
                        }
                    }

                    return dts.Success;
                }
            }

            return dts.ExtraCharacters;
        }

        /// <summary>
        /// Возвращает приоритет операции
        /// </summary>
        /// <param name="operation">Операция</param>
        /// <returns>Приоритет. Чем больше приоритет, тем раньше должна быть обсчитана операция</returns>
        private int GetPriority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                case 'd': return 4;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Преобразует арифметическое выражение в польскую постфиксную нотацию (разделители пробелы)
        /// </summary>
        /// <param name="expression">Изначальное выражение в корректной инфиксной форме без унарных операторов</param>
        /// <returns>Выражение в постфиксной форме</returns>
        private string PostfixNotation(string expression)
        {
            string output = "";
            int layerPriority = 0;
            int maxPriority = 4;
            Stack<char> operations = new Stack<char>();
            Stack<int> priorities = new Stack<int>();
            priorities.Push(0);

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    output += expression[i];
                    continue;
                }

                if (expression[i] == '(')
                    layerPriority += maxPriority;
                else if (expression[i] == ')')
                    layerPriority -= maxPriority;
                else // какая-то из операций
                {
                    output += " ";
                    int currentPriority = GetPriority(expression[i]);

                    if (currentPriority < 0) // по идее - никогда
                        return "";

                    currentPriority += layerPriority;

                    if (currentPriority > priorities.Peek())
                    {
                        priorities.Push(currentPriority);
                        operations.Push(expression[i]);
                    }
                    else
                    {
                        while (currentPriority <= priorities.Peek())
                        {
                            priorities.Pop();
                            output += operations.Pop();
                            output += " ";
                        }
                        priorities.Push(currentPriority);
                        operations.Push(expression[i]);
                    }
                }
            }

            while (operations.Count > 0)
            {
                output += " ";
                output += operations.Pop();
            }

            return output;
        }
        private int CalculateThrow(string postfixExpression)
        {
            int result = int.MinValue;
            string tempString = "";
            Stack<int> operands = new Stack<int>();

            for (int i = 0; i < postfixExpression.Length; i++)
            {
                if (char.IsDigit(postfixExpression[i]))
                {
                    tempString += postfixExpression[i];
                }
                else if (postfixExpression[i] == ' ')
                {
                    int temp = 0;
                    if (int.TryParse(tempString, out temp))
                        operands.Push(temp);
                    tempString = "";
                }
                else
                {
                    int operand2 = operands.Pop();
                    int operand1 = operands.Pop();

                    switch (postfixExpression[i])
                    {
                        case '+':
                            operands.Push(operand1 + operand2); break;
                        case '-':
                            operands.Push(operand1 - operand2); break;
                        case '*':
                            operands.Push(operand1 * operand2); break;
                        case '/':
                            operands.Push(operand1 / operand2); break;
                        case '^':
                            operands.Push((int)Math.Pow(operand1, operand2)); break;
                        case 'd':
                            operands.Push(Roll(operand1, operand2)); break;
                        default:
                            break;
                    }
                }
            }

            result = operands.Pop();
            return result;
        }
        public DiceThrowInfo Throw(string input, bool advantage, bool disadvantage)
        {
            if (advantage == disadvantage && advantage == true)
                advantage = disadvantage = false;

            DiceThrowInfo diceThrowInfo = new DiceThrowInfo(input, advantage, disadvantage);

            string formula = Editing(input);

            diceThrowInfo.straightFormula = formula;
            if (diceThrowInfo.straightFormula == null || diceThrowInfo.straightFormula == "")
            {
                diceThrowInfo.status = dts.EmptyInputString;
                return diceThrowInfo;
            }

            diceThrowInfo.status = CheckCorrection(formula);

            if (diceThrowInfo.status == dts.Success)
            {
                formula = PostfixNotation(formula);

                if (diceThrowInfo.advantage ^ diceThrowInfo.disadvantage)
                {
                    diceThrowInfo.results.Add(CalculateThrow(formula));
                    diceThrowInfo.results.Add(CalculateThrow(formula));
                }
                else
                {
                    diceThrowInfo.results.Add(CalculateThrow(formula));
                }
            }

            return diceThrowInfo;
        }

        public List<string> Recognition(string inputString)
        {
            List<string> result = new List<string>();
            return result;
        }
    }
}
