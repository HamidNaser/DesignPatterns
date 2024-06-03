using System;
/*
    ### Explanation

    1. **AbstractExpression**: The `AbstractExpression` class declares the `Interpret` method.
    2. **TerminalExpression**: The `TerminalExpression` class implements the `Interpret` method for terminal symbols.
    3. **NonTerminalExpression**: The `NonTerminalExpression` class implements the `Interpret` method for non-terminal symbols and uses other expressions to interpret the context.
    4. **Context**: The `Context` class contains global information for the interpreter, such as input and output strings.
    5. **Program**: The client code builds an abstract syntax tree (AST) using terminal and non-terminal expressions and then interprets the context using this AST.
*/
namespace InterpreterPattern
{
    // AbstractExpression class
    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // TerminalExpression class
    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Terminal Expression: Interpreting " + context.Input);
            // Here you can add logic to interpret the terminal expression
        }
    }

    // NonTerminalExpression class
    public class NonTerminalExpression : AbstractExpression
    {
        private AbstractExpression _expression1;
        private AbstractExpression _expression2;

        public NonTerminalExpression(AbstractExpression expression1, AbstractExpression expression2)
        {
            _expression1 = expression1;
            _expression2 = expression2;
        }

        public override void Interpret(Context context)
        {
            Console.WriteLine("Non-Terminal Expression: Interpreting " + context.Input);
            _expression1.Interpret(context);
            _expression2.Interpret(context);
        }
    }

    // Context class
    public class Context
    {
        public string Input { get; set; }
        public string Output { get; set; }

        public Context(string input)
        {
            Input = input;
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context("Example Input");

            // Build the abstract syntax tree
            AbstractExpression expression = new NonTerminalExpression(
                new TerminalExpression(),
                new TerminalExpression()
            );

            // Interpret the context
            expression.Interpret(context);
        }
    }
}
