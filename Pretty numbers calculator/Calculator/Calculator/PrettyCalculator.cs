
namespace Calculator;
public class PrettyCalculator
{
    public long PrettyNumbersCount(int numLength, int numBase)
    {
        if (!CorrectNumber(numLength, numBase))
            return 0;

        //находим максимальную возможную сумму чисел
        int half = numLength / 2;
        Console.WriteLine("half = " + half);

        //находим количество цифр в половине
        int maxSum = half * (numBase - 1);
        Console.WriteLine("max sum = " + maxSum);

        //вычисляем количество комбинаций чисел для каждой возможной суммы
        long count = 0;
        for (int i = 0; i <= maxSum; i++)
        {
            var k = CalculateSumCount(half, i, numBase);
            Console.WriteLine("N(" + i + ") = " + k);
            count += k*k;
        }

        //вычисление центрального числа
        int koeff = (numLength % 2 == 0) ? 1 : numBase;

        return koeff*count;

    }

    //Функция расчета количества комбинаций для суммы
    private long CalculateSumCount(int length, int sum, int numBase)
    {
        if (length == 1)
            return (sum < numBase && sum >= 0) ? 1 : 0;

        long count = 0;

        for(int i = 0; i < numBase; i++)
        {
            var k = CalculateSumCount(length - 1, sum - i, numBase);
            count += k;
        }

        return count;
    }

    //Проверка числа на корректность
    private bool CorrectNumber(int numLength, int numBase)
    {
        if (numLength < 2)
        {
            Console.WriteLine("Количество цифр должно быть больше или равно 2");
            return false;
        }

        if(numBase < 2)
        {
            Console.WriteLine("Система счисления должна быть большей или равной 2");
            return false;
        }

        return true;
    }
}
