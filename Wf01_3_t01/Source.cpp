// Написать приложение, в котором ведётся подсчёт количества «кликов»
// левой, правой и средней кнопки мыши.
// Обновляемую статистику необходимо выводить в заголовок окна.

#include <Windows.h>
#include <tchar.h>

//прототип оконной процедуры
LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);
TCHAR szClassWindow[] = TEXT("Каркасное приложение");
int left = 0, middle = 0, right = 0;

/*Имя класса окна*/
INT WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG Msg;
	WNDCLASSEX wcl;
	
	/* 1. Определение класса окна */
	wcl.cbSize = sizeof(wcl); // размер структуры WNDCLASSEX
	wcl.style = CS_HREDRAW | CS_VREDRAW; // окно сможет получать сообщения о двойном щелчке (DBLCLK)
	wcl.lpfnWndProc = WindowProc; // адрес оконной процедуры
	wcl.cbClsExtra = 0; // используется Windows
	wcl.cbWndExtra = 0; // используется Windows
	wcl.hInstance = hInst; // дескриптор данного приложения
	
						   // загрузка стандартной иконки
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	// загрузка стандартного курсора
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	// заполнение окна белым цветом
	wcl.hbrBackground = (HBRUSH)
		GetStockObject(WHITE_BRUSH);
	wcl.lpszMenuName = NULL; // приложение не содержит меню
	wcl.lpszClassName = szClassWindow; // имя класса окна
	wcl.hIconSm = NULL; // отсутствие маленькой иконки
	
	/* 2. Регистрация класса окна */
	if (!RegisterClassEx(&wcl)) return 0; // при неудачной регистрации - выход
									  
	/* 3. Создание окна */
	// создается окно и переменной hWnd присваивается дескриптор окна
	hWnd = CreateWindowEx(
		0, // расширенный стиль окна
		szClassWindow, // имя класса окна
		TEXT("Left: 0, Middle: 0, Right: 0"),
		//заголовок окна
		/* Заголовок, рамка, позволяющая менять размеры, системное меню, кнопки развёртывания и свёртывания окна*/
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, // х-координата левого верхнего угла окна
		CW_USEDEFAULT, // y-координата левого верхнего угла окна
		CW_USEDEFAULT, // ширина окна
		CW_USEDEFAULT, // высота окна
		NULL, // дескриптор родительского окна
		NULL, // дескриптор меню окна
		hInst, // идентификатор приложения, создавшего окно
		NULL); // указатель на область данных приложения
	
	/* 4. Отображение окна */
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); // перерисовка окна
						
	/* 5. Запуск цикла обработки сообщений */
	// получение очередного сообщения из очереди сообщений
	while (GetMessage(&Msg, NULL, 0, 0))
	{
		TranslateMessage(&Msg);// трансляция сообщения
		DispatchMessage(&Msg); // диспетчеризация сообщений
	}
	return Msg.wParam;
}

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam)
{
	TCHAR str[50];
	
	switch (uMessage)
	{
	case WM_LBUTTONUP:
		wsprintf(str, TEXT("Left: %d, Middle: %d, Right: %d"), ++left, middle, right);
		SetWindowText(hWnd, str);
		break;
	case WM_RBUTTONUP:
		wsprintf(str, TEXT("Left: %d, Middle: %d, Right: %d"), left, middle, ++right);
		SetWindowText(hWnd, str);
		break;
	case WM_MBUTTONUP:
		wsprintf(str, TEXT("Left: %d, Middle: %d, Right: %d"), left, ++middle, right);
		SetWindowText(hWnd, str);
		break;
	case WM_DESTROY: // сообщение о завершении программы
		PostQuitMessage(0); // посылка сообщения WM_QUIT
		break;
	default:
		// все сообщения, которые не обрабатываются в данной оконной функции направляются обратно Windows на обработку по умолчанию
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
	}
	return 0;
}