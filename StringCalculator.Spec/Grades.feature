Feature: Grades
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Calculate Grade
	Given That the student with '21341276' account number
	And These are the following grades
	| AccountNumber | ClassName    | GradeValue | UV |
	| 21341276      | Analisis1    | 88    | 4  |
	| 21341276      | Lenguajes    | 56    | 4  |
	| 21341276      | DisenoLogico | 100   | 3  |
	When I calculate the average grade 
	Then the average grade should be 79.64 on the screen
	And Don't send an email to the parents

	Scenario: When the student fails the class send an email to the parents
	Given That the student with '21341276' account number
	And These are the following grades
	| AccountNumber | ClassName    | GradeValue | UV |
	| 21341276      | Analisis1    | 52    | 1  |
	| 21341276      | Lenguajes    | 56    | 1  |
	| 21341276      | DisenoLogico | 60   | 1  |
	When I calculate the average grade 
	Then the average grade should be 56 on the screen
	And Send an email to the parents
