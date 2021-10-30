grammar ExcelCalculator;

compileUnit : expression EOF;

expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	| operatorToken = NOT LPAREN expression RPAREN #NotFunctionExpr
	| expression operatorToken = (AND | OR) expression #LogicFunctionExpr
	| expression operatorToken = (EQUALLITYDIGIT | MOREDIGIT | LESSDIGIT) expression #LogicFunctorExpr
	| operatorToken = (MOD | DIV) LPAREN expression ',' expression RPAREN #ArithmeticFunctionExpr
    | expression operatorToken = (MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken = (ADD | SUBTRACT) expression #AdditiveExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
	; 

/*
LOGICALFUNCTION:
	NOT 
	| AND 
	| OR
	;

LOGICALFUNCTOR:
	EQUALLITYDIGIT 
	| MOREDIGIT
	| LESSDIGIT
	;

ARITHMETICFUNCTION:
	MOD
	|DIV
	;

MULTIPLICATIONFUNCTOR:
	MULTIPLY
	| DIVIDE
	;

ADDITIVEFUNCTOR:
	ADD
	|SUBTRACT
	;
*/



NUMBER : INT ('.' INT)?;
INT : ('0'..'9')+;

IDENTIFIER : [A-Z]+[0-9]+;

NOT : 'not';

AND : 'and';
OR : 'or';

EQUALLITYDIGIT : '=';
MOREDIGIT : '>';
LESSDIGIT : '<';

MOD : 'mod';
DIV : 'div';

MULTIPLY : '*';
DIVIDE : '/';

ADD : '+';
SUBTRACT : '-';

LPAREN : '(';
RPAREN : ')';

WS : [ \t\r\n] -> channel(HIDDEN);
