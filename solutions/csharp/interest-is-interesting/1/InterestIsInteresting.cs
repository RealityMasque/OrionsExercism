static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if(balance < 0.0m)
            return 3.213f;
        else if(balance < 1000.0m)
            return 0.5f;
        else if(balance < 5000.0m)
            return 1.621f;

        return 2.475f;
    }

    public static decimal Interest(decimal balance) => balance * (decimal)InterestRate(balance) / 100.0m;

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsBeforeDesiredBalance = 0;
        decimal currentBalance = balance;
        while(currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            ++yearsBeforeDesiredBalance;
        }
        return yearsBeforeDesiredBalance;
    }
}
