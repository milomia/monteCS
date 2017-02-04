// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

class mess
{
public:
	int getlen()
	{
		return strlen(str);
	}
	char *getstring()
	{
		return str;
	}
	mess(char *s)
	{
		str = new char[strlen(s) + 1];
		memcpy(str, s,strlen(s)+1);
	}
private:
	char *str;
};

class str
{
public:
	str(mess m)
	{
		s = new char[m.getlen() + 1];
		memcpy(s, m.getstring(),m.getlen()+1);
	}
	char* display()
	{
		return s;
	}

private:
	int t;
	char *s;
	
};


str f(mess t)
{
	return str(t);
}

int main()
{
	char cff[5][5] = {{ 'a','b','c','d','e' }, { 'a','b','c','d','e' }, { 'a', 'b', 'c', 'd', 'e' } ,{ 'a','b','c','d','e' },{ 'a', 'b', 'c', 'd', 'e' }};    /* array of arrays of chars */
	cout << cff[2][2] << endl;

	char *cfp[5];      /* array of pointers to chars */
	char **cpp;         /* pointer to pointer to char ("double pointer") */
	char(*cpf)[5];    /* pointer to array(s) of chars */
	char *cpF();        /* function which returns a pointer to char(s) */
	char(*CFp)();      /* pointer to a function which returns a char */
	char(*cfpF())[5]; /* function which returns pointer to an array of chars */
	char(*cpFf[5])();  /* an array of pointers to functions which return a char */

	str (*cb)(mess);
	mess m("test");
	cb = f;
	cout <<  cb(m).display() << endl;

    return 0;
}

