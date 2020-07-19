// �����������, ��� ���������� �������������,
// ������� �������� �� 10 �������� ������� �� ������ ���������� ������� ����.
// ���������� ��� ������� ����� ������ ���� �������� � ��������� ���� ��������� � ���,
// ��� ��������� ������ �����: ������ ��������������, ������� ��� �� ������� ��������������.
// ��� ������� ������ ������ ���� ���������� �������� � ��������� ���� ���������� � ������� ���������� ������� ����
// (������ � ������ ���������� ������� ����).

#include <Windows.h>
#include <tchar.h>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM); //�������� ������� ���������
TCHAR szClassWindow[] = TEXT("��������� ����������");

/*��� ������ ����*/
INT WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG Msg;
	WNDCLASSEX wcl;

	/* 1. ����������� ������ ���� */
	wcl.cbSize = sizeof(wcl); // ������ ��������� WNDCLASSEX
	wcl.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS; // ���� ������ �������� ��������� � ������� ������ (DBLCLK)
	wcl.lpfnWndProc = WindowProc; // ����� ������� ���������
	wcl.cbClsExtra = 0; // ������������ Windows
	wcl.cbWndExtra = 0; // ������������ Windows
	wcl.hInstance = hInst; // ���������� ������� ����������
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION); // �������� ����������� ������
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW); // �������� ������������ �������
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // ���������� ���� ����� ������
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
		TEXT("������ Windows ����������"), //��������� ����
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
	HDC hdc; //������ �������� ����������
	PAINTSTRUCT ps; //������ ��������� ��������� ������������ ������
	RECT ClientRect;
	GetClientRect(hWnd, &ClientRect);
	HBRUSH hBrush = CreateSolidBrush(RGB(240, 240, 240));
	switch (uMessage)
	{
	case WM_LBUTTONUP:
		if ((LOWORD(lParam) > 10 && HIWORD(lParam) > 10) && (LOWORD(lParam) < ClientRect.right - 10 && HIWORD(lParam) < ClientRect.bottom - 10))
			wsprintf(str, TEXT("������ ����� ��������� ������ ��������������"));
		else if ((LOWORD(lParam) < 10 || LOWORD(lParam) > ClientRect.right - 10 && LOWORD(lParam) < ClientRect.right) ||
				((HIWORD(lParam) < 10 || HIWORD(lParam) > ClientRect.bottom - 10 && HIWORD(lParam) < ClientRect.bottom)))
			wsprintf(str, TEXT("������ ����� ��������� ������� ��������������"));
		else
			wsprintf(str, TEXT("������ ����� ��������� �� ������� ��������������"));
		SetWindowText(hWnd, str); // ������ ��������� � ��������� ����
		break;
	case WM_RBUTTONUP:
		wsprintf(str, TEXT("������ ���������� ������� ����: %d � %d"), ClientRect.right, ClientRect.bottom);
		SetWindowText(hWnd, str); // ������ ��������� � ��������� ����
		break;
		//��������� ���������
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		//������ ����� �������������
		SelectObject(hdc, hBrush);
		Rectangle(hdc, 10, 10, ClientRect.right - 10, ClientRect.bottom - 10);

		ValidateRect(hWnd, NULL);
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY: // ��������� � ���������� ���������
		PostQuitMessage(0); // ������� ��������� WM_QUIT
		DeleteObject(hBrush);
		break;
	default:
		// ��� ���������, ������� �� �������������� � ������ ������� ������� ������������ ������� Windows �� ��������� �� ���������
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
	}
	return 0;
}