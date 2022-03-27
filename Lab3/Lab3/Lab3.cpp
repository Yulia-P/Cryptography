// crypto3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <Math.h>
#include <cstring>
#include <string>

using namespace std;

int Prost[] = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };

// Поиск простых чисел
int REi(int a, int b) {
	for (int x = 1; x < INT32_MAX; x++)
		if ((a * x) % b == 1) return x;
	return 0;
}


// НОД 2 3 чисел
int Evklid(int a, int b)
{
	while (a != b)
	{
		if (a > b)
		{
			long tmp = a;
			a = b;
			b = tmp;
		}
		b = b - a;
	}
	return a;
}


int Evklid_3(int a, int b, int c)
{
	return Evklid(Evklid(a, b), c);
}

//kn + xy = 1(mod n)

/*int Big_Evklid(int a, int b)
{
	int r1 = 1;
	int r2 = 1;
	int t1 = 1, t2 = 1, k = 0;
	do
	{
		k++;
		if (k == 1)
		{
			r1 = ceil(-((b / a) % b));
			t1 = b % a;
		}
		else if (k == 2)
		{
			r2 = (int)ceil((1 - r1 * a / t1) - 1) % b;
			t2 = a % t1;
		}
		else if (k % 2 == 1)
		{
			r1 = ceil((r1 - r2 * t1 / t2) % b);
			t1 = t1 % t2;
		}
		else if (k % 2 == 0)
		{
			r2 = (int)(ceil((r2 - r1 * t2 / t1)) - 1) % b;
			t2 = t2 % t1;
		}
	} while ((t1 != 0) && (t2 != 0));
	if (k % 2 == 0) if (t1 != 1) return 0;
	else return r2;
	else if (t2 != 1) return 0;
	else return r1;
}*/


int Big_Evklid(int a, int b, int* x, int* y)
{
	if (a == 0) {
		*x = 0;
		*y = 1;
		return b;
	}

	int d = Big_Evklid(b % a, a, x, y);
	*x = *y - (b / a) * (*x);
	*y = *x;
	return d;
}

int RE(int a, int b)
{
	int x, y;
	int g = Big_Evklid(a, b, &x, &y);
	if (g != 1) return 0;
	return (x % b + b) % b;

}

string Resheto(int m, int n)
{
	int kol = 0;
	double kor = sqrt(n);

	int* mass = new int[1000];
	string otv = "";
	int s = Prost[0];

	for (int i = m; i <= n; i++) // выпишем ц.ч. [m;n]
	{
		mass[i - m] = i;
	}

	for (int k = 0; Prost[k] < kor; k++)
	{
		s = Prost[k];	//2,3,5,7... v477

		for (int i = 0; i < n - m; i++)
		{
			if (mass[i] == s) continue;		// от 2s
			if (mass[i] % s == 0) mass[i] = 0;
		}
	}
	for (int i = 0; i < n - m; i++)
	{
		if (mass[i] != 0) {
			kol++;
			otv += to_string(mass[i]) + "; ";
		}
	}
	cout << "\n Количество простых чисел на промежутке - " << kol;
	cout << "\n n/ln(n) = " << n / log(n) << "\n";
	delete[] mass;
	return otv;
}

int main()
{
	setlocale(0, "russian");

	int a, b, c, n, m;
	int x, y;

	
	cout << "Задание 1: Найт простые числа в интервале [2; n] n - из вариантат \n";
	cout << "Введите n: \n";
	cin >> n;
	cout << "Простые числа на промежутке:  " << Resheto(2, n) << "\n";

	cout << "Задание 2: Найти простые числа на интервале [m; n] m и n - числа из варианта \n";
	cout << "Введите m: \n";
	cin >> m;
	cout << "Простые числа на промежутке:  " << Resheto(m, n) << "\n";

	cout << "Задание 6: Найт НОД \n";
	cout << "НОД 2-х чисел: \n";
	cout << "Введите a: \n";
	cin >> a;
	cout << "Введите b: \n";
	cin >> b;
	cout << "НОД двух чисел= " << Evklid(a, b) << "\n";

	cout << "НОД 3-х чисел: \n";
	cout << "Введите a: \n";
	cin >> a;
	cout << "Введите b: \n";
	cin >> b;	
	cout << "Введите c: \n";
	cin >> c;
	cout << "НОД трех чисел= " << Evklid_3(a, b, c) << "\n";
	

	
	/*cout << "Введите коэфициенты для нахождения обратного числа по модулю: \n";
	cin >> a >> b;
	cout << to_string(a) + "y = 1 mod " << to_string(b);
	cout << "\nНайдем число, обратное " << to_string(a) << " по модулю " << to_string(b);
	cout << "\nОно равно = " << REi(a, b) << "\n";*/


	system("pause");
	return 0;
}