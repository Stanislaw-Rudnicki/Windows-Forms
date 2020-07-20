// �������� ����������, � ������� ������ ������� ���������� �������
// �����, ������ � ������� ������ ����.
// ����������� ���������� ���������� �������� � ��������� ����.

#include <Windows.h>
#include <tchar.h>

//�������� ������� ���������
LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);
TCHAR szClassWindow[] = TEXT("��������� ����������");
int left = 0, middle = 0, right = 0;

/*��� ������ ����*/
INT WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG Msg;
	WNDCLASSEX wcl;
	
	/* 1. ����������� ������ ���� */
	wcl.cbSize = sizeof(wcl); // ������ ��������� WNDCLASSEX
	wcl.style = CS_HREDRAW | CS_VREDRAW; // ���� ������ �������� ��������� � ������� ������ (DBLCLK)
	wcl.lpfnWndProc = WindowProc; // ����� ������� ���������
	wcl.cbClsExtra = 0; // ������������ Windows
	wcl.cbWndExtra = 0; // ������������ Windows
	wcl.hInstance = hInst; // ���������� ������� ����������
	
						   // �������� ����������� ������
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	// �������� ������������ �������
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	// ���������� ���� ����� ������
	wcl.hbrBackground = (HBRUSH)
		GetStockObject(WHITE_BRUSH);
	wcl.lpszMenuName = NULL; // ���������� �� �������� ����
	wcl.lpszClassName = szClassWindow; // ��� ������ ����
	wcl.hIconSm = NULL; // ���������� ��������� ������
	
	/* 2. ����������� ������ ���� */
	if (!RegisterClassEx(&wcl)) return 0; // ��� ��������� ����������� - �����
									  
	/* 3. �������� ���� */
	// ��������� ���� � ���������� hWnd ������������� ���������� ����
	hWnd = CreateWindowEx(
		0, // ����������� ����� ����
		szClassWindow, // ��� ������ ����
		TEXT("Left: 0, Middle: 0, Right: 0"),
		//��������� ����
		/* ���������, �����, ����������� ������ �������, ��������� ����, ������ ������������ � ���������� ����*/
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, // �-���������� ������ �������� ���� ����
		CW_USEDEFAULT, // y-���������� ������ �������� ���� ����
		CW_USEDEFAULT, // ������ ����
		CW_USEDEFAULT, // ������ ����
		NULL, // ���������� ������������� ����
		NULL, // ���������� ���� ����
		hInst, // ������������� ����������, ���������� ����
		NULL); // ��������� �� ������� ������ ����������
	
	/* 4. ����������� ���� */
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); // ����������� ����
						
	/* 5. ������ ����� ��������� ��������� */
	// ��������� ���������� ��������� �� ������� ���������
	while (GetMessage(&Msg, NULL, 0, 0))
	{
		TranslateMessage(&Msg);// ���������� ���������
		DispatchMessage(&Msg); // ��������������� ���������
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
	case WM_DESTROY: // ��������� � ���������� ���������
		PostQuitMessage(0); // ������� ��������� WM_QUIT
		break;
	default:
		// ��� ���������, ������� �� �������������� � ������ ������� ������� ������������ ������� Windows �� ��������� �� ���������
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
	}
	return 0;
}