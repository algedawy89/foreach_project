// Define the grammar name
grammar Grammar;

// Parser rules
program
    : ('void'|'int' 'main') LEFT RIGHT BEGIN statement* ENDR EOF
    ;

statement
    : variableDeclaration ';'
    | assignment ';'
    | printStatement ';'
    | printLineStatement ';'
    | foreachStatement
    |doWhileStatement
    | COMMENT 
    | ifStatement
    ;



doWhileStatement
    : 'do' BEGIN statement+ ENDR 'while' LEFT condition RIGHT ';'
    ;


BEGIN
    : '{'
    ;

ENDR
    : '}'
    ;


LEFT
    : '('
    ;

RIGHT
    : ')'
    ;

ifStatement
    : 'if' LEFT condition (LOGIC condition)* RIGHT BEGIN statement+ ENDR
      (ELSE_IF LEFT condition (LOGIC condition)* RIGHT BEGIN statement+ ENDR)* // دعم else if
      (ELSE BEGIN statement+ ENDR)?                                          // دعم else
    ;


ELSE:'else';
ELSE_IF:'else if';
   condition
    : singleCondition (LOGIC singleCondition)*
    ;

singleCondition
    : expression COMPARISON_OP expression
    ;

COMPARISON_OP
    : '==' | '!=' | '<' | '>' | '<=' | '>='
    ;

LOGIC
    : 'and' | 'or' | '&&' | '||'
    ;


variableDeclaration
    : type IDENTIFIER ('=' expression)? 
    | type IDENTIFIER '[' ']' ('=' arrayLiteral)?
    ;
        
assignment
    : IDENTIFIER ('[' expression ']')? '=' expression
    ;

// x [1, 2, 3] = 5
printStatement
    : 'print' '('  expression (',' expression)* ')'
    ;

printLineStatement
    : 'print.line' '('  expression (',' expression)*')'
    ;
foreachStatement
    : 'foreach' '(' type IDENTIFIER 'in' IDENTIFIER ')' '{' statement+ '}'
    ;

arrayLiteral
    : '[' expression (',' expression)* ']'
    ;

// ec: x  y i
expression
    : INTEGER
    | STRING
    | IDENTIFIER
    | IDENTIFIER '[' expression ']'
    | expression ('+' | '-' | '*' | '/') expression
    | '(' expression ')'
    ;

type
    : 'int'
    | 'string'
    | 'bool'
    ;

// Lexer rules
INTEGER
    : [0-9]+ 
    ;

STRING
    : '"' .*? '"'
    ;

IDENTIFIER
    : [a-zA-Z_][a-zA-Z_0-9]*
    ;

COMMENT
    : ('//' ~[\r\n]* | '#' ~[\r\n]*) -> skip
    ;

WS
    : [ \t\r\n]+ -> skip
    ;
