using System;
using System.Collections.Generic;

public static class CalculatorConverter
{
    public static double CalculatePolandList(List<object> polandList)
    {
        var stack = new Stack<Double>();
        double num1, num2;
        foreach(object obj in polandList)
        {
            if (obj is Double)
                stack.Push((Double)obj);
            else
            {
                num2 = stack.Pop();
                num1 = stack.Pop();
                switch((Char)obj)
                {
                    case '+':
                        stack.Push(num1 + num2);
                        break;
                    case '-':
                        stack.Push(num1 - num2);
                        break;
                    case '*':
                        stack.Push(num1 * num2);
                        break;
                    case '/':
                        stack.Push(num1 / num2);
                        break;
                }
            }
        }
        return stack.Pop();
    }
    public static List<object> ListToPolandList(List<object> list)
    {
        var operators = new List<char> { '+', '-', '*', '/' };
        var operatorsPriority = new Dictionary<char, int>()
        {
            {'(', 0},
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2}
        };
        var polandList = new List<object>();
        var texas = new Stack<Char>();

        foreach (object obj in list)
        {
            if (obj is Double)
            {
                polandList.Add(obj);
                continue;
            }
            if((Char)obj == '(')
            {
                texas.Push((Char)obj);
                continue;
            }
            if ((Char)obj == ')')
            {
                while (texas.Peek() != '(')
                    polandList.Add(texas.Pop());
                texas.Pop();
                continue;
            }
            if (operators.Contains((Char)obj))
            {
                while(texas.Count > 0 && operatorsPriority[texas.Peek()] > operatorsPriority[(Char)obj])
                    polandList.Add(texas.Pop());
                texas.Push((Char)obj);
                continue;
            }
        }
        while (texas.Count > 0)
            polandList.Add(texas.Pop());
        return polandList;
    }
    public static List<object> StringToList(string str)
    {
        if (str == null)
            return null;

        var list = new List<object>();
        var readyChar = new List<char> { '+', '*', '/', '(', ')' };
        for (int i = 0; i < str.Length; i++)
        {
            if (readyChar.Contains(str[i]))
            {
                list.Add(str[i]);
                continue;
            }

            if (Char.IsDigit(str[i]))
            {
                list.Add(Double.Parse(ReadStrNum(str, ref i)));
                continue;
            }


            if (str[i] == '-')
            {
                if (i == 0)
                {
                    string d = ReadStrNum(str, ref i);
                    list.Add(Double.Parse(d));
                    continue;
                }
                if (str[i - 1] == '(')
                {
                    string d = ReadStrNum(str, ref i);
                    list.Add(Double.Parse(d));
                    continue;
                }
                list.Add(str[i]);
            }
        }
        return list;
    }
    private static string ReadStrNum(string str, ref int i)
    {
        string number = "";
        for (; i < str.Length; i++)
        {
            if (!Char.IsDigit(str[i]) && str[i] != ',')
            {
                if (number == "" && str[i] == '-')
                {
                    number += "-";
                    continue;
                }
                break;
            }
            if (str[i] == ',')
            {
                number += '.';
                continue;
            }
            number += str[i];
        }
        i--;
        return number;
    }
}
