
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_MINUSMINUS          =  4, // '--'
        SYMBOL_EXCLAMEQ            =  5, // '!='
        SYMBOL_LPAREN              =  6, // '('
        SYMBOL_RPAREN              =  7, // ')'
        SYMBOL_TIMES               =  8, // '*'
        SYMBOL_COMMA               =  9, // ','
        SYMBOL_DIV                 = 10, // '/'
        SYMBOL_SEMI                = 11, // ';'
        SYMBOL_LBRACE              = 12, // '{'
        SYMBOL_RBRACE              = 13, // '}'
        SYMBOL_PLUS                = 14, // '+'
        SYMBOL_PLUSPLUS            = 15, // '++'
        SYMBOL_LT                  = 16, // '<'
        SYMBOL_LTEQ                = 17, // '<='
        SYMBOL_EQ                  = 18, // '='
        SYMBOL_EQEQ                = 19, // '=='
        SYMBOL_GT                  = 20, // '>'
        SYMBOL_GTEQ                = 21, // '>='
        SYMBOL_CHAR                = 22, // char
        SYMBOL_CHARLITERAL         = 23, // CharLiteral
        SYMBOL_DOUBLE              = 24, // double
        SYMBOL_ELSE                = 25, // else
        SYMBOL_FLOAT               = 26, // float
        SYMBOL_FLOATLITERAL        = 27, // FloatLiteral
        SYMBOL_FOR                 = 28, // for
        SYMBOL_IDENTIFIER          = 29, // Identifier
        SYMBOL_IF                  = 30, // if
        SYMBOL_INT                 = 31, // int
        SYMBOL_INTEGER             = 32, // Integer
        SYMBOL_INTEGERLITERAL      = 33, // IntegerLiteral
        SYMBOL_RETURN              = 34, // return
        SYMBOL_STRINGLITERAL       = 35, // StringLiteral
        SYMBOL_VOID                = 36, // void
        SYMBOL_WHILE               = 37, // while
        SYMBOL_ADDEXPRESSION       = 38, // <AddExpression>
        SYMBOL_ASSIGNMENT          = 39, // <Assignment>
        SYMBOL_ELSECLAUSE          = 40, // <ElseClause>
        SYMBOL_EXPRESSION          = 41, // <Expression>
        SYMBOL_FORINIT             = 42, // <ForInit>
        SYMBOL_FORSTATEMENT        = 43, // <ForStatement>
        SYMBOL_FORUPDATE           = 44, // <ForUpdate>
        SYMBOL_FUNCTIONDECLARATION = 45, // <FunctionDeclaration>
        SYMBOL_IFSTATEMENT         = 46, // <IfStatement>
        SYMBOL_MULEXPRESSION       = 47, // <MulExpression>
        SYMBOL_PARAMETER           = 48, // <Parameter>
        SYMBOL_PARAMETERLIST       = 49, // <ParameterList>
        SYMBOL_PRIMARYEXPRESSION   = 50, // <PrimaryExpression>
        SYMBOL_PROGRAM             = 51, // <Program>
        SYMBOL_RETURNSTATEMENT     = 52, // <ReturnStatement>
        SYMBOL_STATEMENT           = 53, // <Statement>
        SYMBOL_STATEMENTBLOCK      = 54, // <StatementBlock>
        SYMBOL_STATEMENTLIST       = 55, // <StatementList>
        SYMBOL_TYPE                = 56, // <Type>
        SYMBOL_UNARYEXPRESSION     = 57, // <UnaryExpression>
        SYMBOL_VARIABLEDECLARATION = 58, // <VariableDeclaration>
        SYMBOL_WHILESTATEMENT      = 59  // <WhileStatement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                      =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                                =  1, // <StatementList> ::= 
        RULE_STATEMENTLIST2                               =  2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENTLIST3                               =  3, // <StatementList> ::= <Statement>
        RULE_STATEMENT_SEMI                               =  4, // <Statement> ::= <VariableDeclaration> ';'
        RULE_STATEMENT_SEMI2                              =  5, // <Statement> ::= <Assignment> ';'
        RULE_STATEMENT                                    =  6, // <Statement> ::= <IfStatement>
        RULE_STATEMENT2                                   =  7, // <Statement> ::= <WhileStatement>
        RULE_STATEMENT3                                   =  8, // <Statement> ::= <ForStatement>
        RULE_STATEMENT_SEMI3                              =  9, // <Statement> ::= <ReturnStatement> ';'
        RULE_STATEMENT4                                   = 10, // <Statement> ::= <FunctionDeclaration>
        RULE_VARIABLEDECLARATION_IDENTIFIER               = 11, // <VariableDeclaration> ::= <Type> Identifier
        RULE_VARIABLEDECLARATION_IDENTIFIER_EQ            = 12, // <VariableDeclaration> ::= <Type> Identifier '=' <Expression>
        RULE_TYPE_INT                                     = 13, // <Type> ::= int
        RULE_TYPE_FLOAT                                   = 14, // <Type> ::= float
        RULE_TYPE_DOUBLE                                  = 15, // <Type> ::= double
        RULE_TYPE_CHAR                                    = 16, // <Type> ::= char
        RULE_TYPE_VOID                                    = 17, // <Type> ::= void
        RULE_ASSIGNMENT_IDENTIFIER_EQ                     = 18, // <Assignment> ::= Identifier '=' <Expression>
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN                 = 19, // <IfStatement> ::= if '(' <Expression> ')' <StatementBlock> <ElseClause>
        RULE_ELSECLAUSE                                   = 20, // <ElseClause> ::= 
        RULE_ELSECLAUSE_ELSE                              = 21, // <ElseClause> ::= else <StatementBlock>
        RULE_WHILESTATEMENT_WHILE_LPAREN_RPAREN           = 22, // <WhileStatement> ::= while '(' <Expression> ')' <StatementBlock>
        RULE_FORSTATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN     = 23, // <ForStatement> ::= for '(' <ForInit> ';' <Expression> ';' <ForUpdate> ')' <StatementBlock>
        RULE_FORINIT                                      = 24, // <ForInit> ::= 
        RULE_FORINIT2                                     = 25, // <ForInit> ::= <VariableDeclaration>
        RULE_FORINIT3                                     = 26, // <ForInit> ::= <Assignment>
        RULE_FORUPDATE                                    = 27, // <ForUpdate> ::= 
        RULE_FORUPDATE_IDENTIFIER_PLUSPLUS                = 28, // <ForUpdate> ::= Identifier '++'
        RULE_FORUPDATE_IDENTIFIER_MINUSMINUS              = 29, // <ForUpdate> ::= Identifier '--'
        RULE_FORUPDATE2                                   = 30, // <ForUpdate> ::= <Assignment>
        RULE_RETURNSTATEMENT_RETURN                       = 31, // <ReturnStatement> ::= return <Expression>
        RULE_FUNCTIONDECLARATION_IDENTIFIER_LPAREN_RPAREN = 32, // <FunctionDeclaration> ::= <Type> Identifier '(' <ParameterList> ')' <StatementBlock>
        RULE_PARAMETERLIST                                = 33, // <ParameterList> ::= 
        RULE_PARAMETERLIST2                               = 34, // <ParameterList> ::= <Parameter>
        RULE_PARAMETERLIST_COMMA                          = 35, // <ParameterList> ::= <ParameterList> ',' <Parameter>
        RULE_PARAMETER_IDENTIFIER                         = 36, // <Parameter> ::= <Type> Identifier
        RULE_STATEMENTBLOCK_LBRACE_RBRACE                 = 37, // <StatementBlock> ::= '{' <StatementList> '}'
        RULE_EXPRESSION_EQEQ                              = 38, // <Expression> ::= <Expression> '==' <AddExpression>
        RULE_EXPRESSION_EXCLAMEQ                          = 39, // <Expression> ::= <Expression> '!=' <AddExpression>
        RULE_EXPRESSION_LT                                = 40, // <Expression> ::= <Expression> '<' <AddExpression>
        RULE_EXPRESSION_GT                                = 41, // <Expression> ::= <Expression> '>' <AddExpression>
        RULE_EXPRESSION_LTEQ                              = 42, // <Expression> ::= <Expression> '<=' <AddExpression>
        RULE_EXPRESSION_GTEQ                              = 43, // <Expression> ::= <Expression> '>=' <AddExpression>
        RULE_EXPRESSION                                   = 44, // <Expression> ::= <AddExpression>
        RULE_ADDEXPRESSION_PLUS                           = 45, // <AddExpression> ::= <AddExpression> '+' <MulExpression>
        RULE_ADDEXPRESSION_MINUS                          = 46, // <AddExpression> ::= <AddExpression> '-' <MulExpression>
        RULE_ADDEXPRESSION                                = 47, // <AddExpression> ::= <MulExpression>
        RULE_MULEXPRESSION_TIMES                          = 48, // <MulExpression> ::= <MulExpression> '*' <UnaryExpression>
        RULE_MULEXPRESSION_DIV                            = 49, // <MulExpression> ::= <MulExpression> '/' <UnaryExpression>
        RULE_MULEXPRESSION                                = 50, // <MulExpression> ::= <UnaryExpression>
        RULE_UNARYEXPRESSION_MINUS                        = 51, // <UnaryExpression> ::= '-' <PrimaryExpression>
        RULE_UNARYEXPRESSION_PLUS                         = 52, // <UnaryExpression> ::= '+' <PrimaryExpression>
        RULE_UNARYEXPRESSION                              = 53, // <UnaryExpression> ::= <PrimaryExpression>
        RULE_PRIMARYEXPRESSION_IDENTIFIER                 = 54, // <PrimaryExpression> ::= Identifier
        RULE_PRIMARYEXPRESSION_INTEGERLITERAL             = 55, // <PrimaryExpression> ::= IntegerLiteral
        RULE_PRIMARYEXPRESSION_FLOATLITERAL               = 56, // <PrimaryExpression> ::= FloatLiteral
        RULE_PRIMARYEXPRESSION_CHARLITERAL                = 57, // <PrimaryExpression> ::= CharLiteral
        RULE_PRIMARYEXPRESSION_STRINGLITERAL              = 58, // <PrimaryExpression> ::= StringLiteral
        RULE_PRIMARYEXPRESSION_LPAREN_RPAREN              = 59  // <PrimaryExpression> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;

        public MyParser(string filename,ListBox lst, ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOATLITERAL :
                //FloatLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGERLITERAL :
                //IntegerLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXPRESSION :
                //<AddExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSECLAUSE :
                //<ElseClause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORINIT :
                //<ForInit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTATEMENT :
                //<ForStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORUPDATE :
                //<ForUpdate>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDECLARATION :
                //<FunctionDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULEXPRESSION :
                //<MulExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<Parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERLIST :
                //<ParameterList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYEXPRESSION :
                //<PrimaryExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<ReturnStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTBLOCK :
                //<StatementBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXPRESSION :
                //<UnaryExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILESTATEMENT :
                //<WhileStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <StatementList> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST3 :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<Statement> ::= <VariableDeclaration> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI2 :
                //<Statement> ::= <Assignment> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <WhileStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <ForStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI3 :
                //<Statement> ::= <ReturnStatement> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <FunctionDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER :
                //<VariableDeclaration> ::= <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_EQ :
                //<VariableDeclaration> ::= <Type> Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<Type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_DOUBLE :
                //<Type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_CHAR :
                //<Type> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_VOID :
                //<Type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ :
                //<Assignment> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN :
                //<IfStatement> ::= if '(' <Expression> ')' <StatementBlock> <ElseClause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSECLAUSE :
                //<ElseClause> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSECLAUSE_ELSE :
                //<ElseClause> ::= else <StatementBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_WHILE_LPAREN_RPAREN :
                //<WhileStatement> ::= while '(' <Expression> ')' <StatementBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<ForStatement> ::= for '(' <ForInit> ';' <Expression> ';' <ForUpdate> ')' <StatementBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINIT :
                //<ForInit> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINIT2 :
                //<ForInit> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINIT3 :
                //<ForInit> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORUPDATE :
                //<ForUpdate> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORUPDATE_IDENTIFIER_PLUSPLUS :
                //<ForUpdate> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORUPDATE_IDENTIFIER_MINUSMINUS :
                //<ForUpdate> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORUPDATE2 :
                //<ForUpdate> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN :
                //<ReturnStatement> ::= return <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_IDENTIFIER_LPAREN_RPAREN :
                //<FunctionDeclaration> ::= <Type> Identifier '(' <ParameterList> ')' <StatementBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST :
                //<ParameterList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST2 :
                //<ParameterList> ::= <Parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_COMMA :
                //<ParameterList> ::= <ParameterList> ',' <Parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_IDENTIFIER :
                //<Parameter> ::= <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTBLOCK_LBRACE_RBRACE :
                //<StatementBlock> ::= '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ :
                //<Expression> ::= <Expression> '!=' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <AddExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXPRESSION_PLUS :
                //<AddExpression> ::= <AddExpression> '+' <MulExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXPRESSION_MINUS :
                //<AddExpression> ::= <AddExpression> '-' <MulExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXPRESSION :
                //<AddExpression> ::= <MulExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULEXPRESSION_TIMES :
                //<MulExpression> ::= <MulExpression> '*' <UnaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULEXPRESSION_DIV :
                //<MulExpression> ::= <MulExpression> '/' <UnaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULEXPRESSION :
                //<MulExpression> ::= <UnaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_MINUS :
                //<UnaryExpression> ::= '-' <PrimaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_PLUS :
                //<UnaryExpression> ::= '+' <PrimaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION :
                //<UnaryExpression> ::= <PrimaryExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_IDENTIFIER :
                //<PrimaryExpression> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_INTEGERLITERAL :
                //<PrimaryExpression> ::= IntegerLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_FLOATLITERAL :
                //<PrimaryExpression> ::= FloatLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_CHARLITERAL :
                //<PrimaryExpression> ::= CharLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_STRINGLITERAL :
                //<PrimaryExpression> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_LPAREN_RPAREN :
                //<PrimaryExpression> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+" in line: "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2=args.ExpectedTokens.ToString();
            lst.Items.Add(m2);

        }
        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "\t \t " +(SymbolConstants) args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
