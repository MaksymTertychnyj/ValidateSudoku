using ValidateSudoku;

int[,] data =
{
    { 7,8,4,1,5,9,3,2,6 },
    { 5,3,9,6,7,2,8,4,1 },
    { 6,1,2,4,3,8,7,5,9 },
    { 9,2,8,7,1,5,4,6,3 },
    { 3,5,7,8,4,6,1,9,2 },
    { 4,6,1,9,2,3,5,8,7 },
    { 8,7,6,3,9,4,2,1,5 },
    { 2,4,3,5,6,1,9,7,8 },
    { 1,9,5,2,8,7,6,3,4 }
};

var validator = new ValidatorSudoku(data);

try
{
    validator.ToValidateSudoku();
    Console.WriteLine("data is valid");
}
catch (NotValidSudoku ex)
{
    Console.WriteLine(ex.Message);
}