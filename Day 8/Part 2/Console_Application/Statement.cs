namespace Console_Application
{
    public enum StatementCompareMethod
    {
        Equal,
        NotEqual,
        BiggerThanOrEqualTo,
        BiggerThan,
        SmallerThanOrEqualTo,
        SmallerThan
    }

    public enum StatementNumberManipulationMethod
    {
        Increase,
        Decrease
    }
    
    public class Statement
    {
        public StatementCompareMethod CompareMethod;
        public StatementNumberManipulationMethod ManipulationMethod;

        public int CompareToValue;
        public int ManipulateWithValue;

        public string ChangeVariableWithName;
        public string CompareVariableWithName;
    }
}