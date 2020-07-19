// 1. Программа запрашивает у пользователя путь к файлу с символами Unicode.
// После чего программа копирует содержимое файла в новый файл,
// преобразовывая исходное содержимое в формат ANSI.

// 2. Посчитать количество названий фруктов в файле.
// Названия фруктов и путь к файлу пользователь вводит с клавиатуры.
// Названия фруктов и содержимое файла в формате Unicode.

#define _CRT_SECURE_NO_WARNINGS
#include <algorithm>
#include <chrono>
#include <fcntl.h>
#include <fstream>
#include <iomanip>
#include <iostream>
#include <io.h>
#include <locale>
#include <vector>
#include <Windows.h>

using namespace std;

void Task01()
{
	char* fn = new char[255]{ 0 };
	cout << "Введите имя файла с символами Unicode: "; cin.getline(fn, 255);
	//fn = strcpy(fn, "file.txt");
		
	char* ptr = strrchr(fn, '.');
	char* fn2 = strcat(strncpy(new char[strlen(fn) + 3]{ 0 }, fn, ptr - fn), strcat(new char[3]{ '_', '2', '\0' }, ptr));
	
	ifstream fin(fn, ios::in | ios::binary);
	fin.seekg(0, ios::end);
	size_t len = fin.tellg();
	fin.seekg(0, ios::beg);
	vector<char> strUtf8(len);
	fin.read(&strUtf8[0], strUtf8.size());

	len = MultiByteToWideChar(CP_UTF8, 0, &strUtf8[0], strUtf8.size(), 0, 0);
	vector<wchar_t> strUtf16(len);
	len = MultiByteToWideChar(CP_UTF8, 0, &strUtf8[0], strUtf8.size(), &strUtf16[0], strUtf16.size());
	if (len == 0)
		return;

	len = WideCharToMultiByte(CP_ACP, WC_COMPOSITECHECK | WC_DEFAULTCHAR, &strUtf16[0], strUtf16.size(), 0, 0, 0, 0);
	vector<char> strAnsi(len);
	len = WideCharToMultiByte(CP_ACP, WC_COMPOSITECHECK | WC_DEFAULTCHAR, &strUtf16[0], strUtf16.size(), &strAnsi[0], strAnsi.size(), 0, 0);
	if (len == 0)
		return;
	
	ofstream fout(fn2, ios::out | ios::trunc | ios::binary);
	size_t pos = strUtf16[0] == 0xfeff ? 1 : 0;
	
	for (int i = pos; i < len - pos; ++i)
		if (strAnsi[i] != 13)
			fout << strAnsi[i];
		
	fin.close();
	fout.close();

	cout << "\nИсходное содержимое успешно преобразовано в формат ANSI\nи записано в файл " << fn2 << endl;
	
	delete[]fn2;
	delete[]fn;
}

void Task02()
{
	char* fn = new char[255]{ 0 };
	cout << "Введите имя файла с названиями фруктов в формате Unicode: ";
	cin.getline(fn, 255);
	//fn = strcpy(fn, "fruits.txt");

	wchar_t* substr = new wchar_t[255]{ 0 };
	cout << "Введите название фрукта: ";
	
	_setmode(_fileno(stdout), _O_WTEXT);
	_setmode(_fileno(stdin), _O_WTEXT);
	wcin.getline(substr, 255);
	//substr = wcscpy(substr, L"БаНАн");
	
	auto start = chrono::high_resolution_clock::now();

	int substrLen = wcslen(substr);
	setlocale(LC_CTYPE, "");
	int i = 0;
	while (substr[i])
		iswupper(substr[i]) ? substr[i++] = tolower(substr[i], locale("")) : i++;
		
	ifstream fin(fn, ios::in | ios::binary);
	fin.seekg(0, ios::end);
	size_t len = fin.tellg();
	fin.seekg(0, ios::beg);
	vector<char> strUtf8(len);
	fin.read(&strUtf8[0], strUtf8.size());

	len = MultiByteToWideChar(CP_UTF8, 0, &strUtf8[0], strUtf8.size(), 0, 0);
	vector<wchar_t> strUtf16(len);
	len = MultiByteToWideChar(CP_UTF8, 0, &strUtf8[0], strUtf8.size(), &strUtf16[0], strUtf16.size());
	if (len == 0)
		return;

	transform(strUtf16.begin(), strUtf16.end(), strUtf16.begin(),
		[](wchar_t c) { return iswupper(c) ? tolower(c, locale("")) : c; });
	
	size_t count = 0;
	auto it = search(strUtf16.begin(), strUtf16.end(), substr, substr + substrLen);
	while (it != strUtf16.end()) {
		it = search(it + substrLen, strUtf16.end(), substr, substr + substrLen);
		count++;
	}
		
	wcout << L"\nВ указанном файле " << substr << L" встречается " << count << L" раз." << endl;

	fin.close();
	delete[]substr;
	delete[]fn;

	auto stop = chrono::high_resolution_clock::now();
	auto duration = chrono::duration_cast<chrono::duration<double>>(stop - start);
	wcout << "\nruntime = " << setprecision(3) << duration.count() << " s" << endl;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	Task01();
	Task02();

	return 0;
}